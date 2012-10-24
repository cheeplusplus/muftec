using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Muftec.Lib
{
    public delegate void OpCodePointer(OpCodeData stack);

    public class MuftecLibSystem
    {
        class OpCodeItem
        {
            public OpCodeAttribute Attribute { get; set; }
            public OpCodePointer Pointer { get; set; }
        }

        private readonly Dictionary<string, OpCodeItem> _opcodeCache = new Dictionary<string, OpCodeItem>();
        private readonly Dictionary<string, MuftecStackItem> _globalVariableList = new Dictionary<string, MuftecStackItem>();
        private readonly Dictionary<string, Queue<MuftecStackItem>> _globalFunctionList = new Dictionary<string, Queue<MuftecStackItem>>();
        private readonly List<Assembly> _libraryList = new List<Assembly>();
        
        /// <summary>
        /// Register special opcodes that must be handled from inside THIS class
        /// </summary>
        public MuftecLibSystem()
        {
            var internalOps = new OpCodePointer[] {ReadVariable, SetVariable, LoadLibraryDLL, Abort, Exit};
            AddOpToCache(internalOps);
        }

        #region Opcode cache functions
        /// <summary>
        /// Add an opcode to the cache.
        /// </summary>
        /// <param name="item">Opcode item to add.</param>
        private void AddOpToCache(OpCodeItem item)
        {
            _opcodeCache.Add(item.Attribute.OpCodeName, item);
        }

        /// <summary>
        /// Add an opcode to the cache.
        /// </summary>
        /// <param name="pointer">Opcode pointer to add.</param>
        private void AddOpToCache(OpCodePointer pointer)
        {
            var newItem = new OpCodeItem
            {
                Pointer = pointer,
                Attribute = pointer.Method.GetCustomAttributes(typeof(OpCodeAttribute), false).FirstOrDefault() as OpCodeAttribute
            };

            AddOpToCache(newItem);
        }

        /// <summary>
        /// Add multiple opcodes to the cache.
        /// </summary>
        /// <param name="pointers">Opcode pointers to add.</param>
        private void AddOpToCache(IEnumerable<OpCodePointer> pointers)
        {
            foreach (var pointer in pointers)
            {
                AddOpToCache(pointer);
            }
        }
        #endregion

        #region Internal opcodes
        [OpCode("!")]
        private void ReadVariable(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            
            if (item1.Type == MuftecType.Variable)
            {
                if (_globalVariableList.ContainsKey(item1.Item.ToString()))
                {
                    data.RuntimeStack.Push(_globalVariableList[item1.Item.ToString()]);
                }
                else
                {
                    throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
                }
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        [OpCode("@")]
        private void SetVariable(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            var item2 = Shared.Pop(data.RuntimeStack);
            
            if (item1.Type == MuftecType.Variable)
            {
                _globalVariableList.Add((string)item1.Item, item2);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        [OpCode("loadlibdll")]
        private void LoadLibraryDLL(OpCodeData data)
        {
            var library = Shared.PopStr(data.RuntimeStack);
            AddLibrary(library);
        }

        [OpCode("abort", Magic = MagicOpcodes.Abort)]
        private void Abort(OpCodeData data)
        {
            var message = Shared.PopStr(data.RuntimeStack);
            Console.WriteLine("ABORT (line {0}): {1}", data.LineNumber, message);
        }

        [OpCode("exit", Magic = MagicOpcodes.Exit)]
        private void Exit(OpCodeData data)
        {
            // Let magic do its magic
        }
        #endregion

        #region Library functions
        /// <summary>
        /// Add an external library DLL that inherits <see>IMuftecClassLibrary</see>
        /// </summary>
        /// <param name="path"></param>
        public void AddLibrary(string path)
        {
            AddLibrary(Assembly.LoadFile(path));
        }

        /// <summary>
        /// Add a library inherited from <see>IMuftecClassLibrary</see>
        /// </summary>
        /// <param name="classLibrary">Class containing opcodes</param>
        public void AddLibrary(IMuftecClassLibrary classLibrary)
        {
            var classAssembly = classLibrary.GetType().Assembly;
            AddLibrary(classAssembly);
        }

        /// <summary>
        /// Add an assembly containing classes inheriting <see>IMuftecClassLibraryCollection</see>
        /// </summary>
        /// <param name="classAssembly"></param>
        public void AddLibrary(Assembly classAssembly)
        {
            // Ignore if already loaded
            if (_libraryList.Contains(classAssembly)) return;

            // Get all opcode methods
            var methods = classAssembly.GetTypes().SelectMany(t => t.GetMethods()).Where(m => m.GetCustomAttributes(typeof(OpCodeAttribute), false).Length > 0);

            // Add opcodes to index
            foreach (var info in methods)
            {
                var code = info.GetCustomAttributes(typeof(OpCodeAttribute), false).FirstOrDefault() as OpCodeAttribute;
                if (code != null)
                {
                    var opc = (OpCodePointer)Delegate.CreateDelegate(typeof(OpCodePointer), info);
                    var opi = new OpCodeItem {Attribute = code, Pointer = opc};

                    try
                    {
                        AddOpToCache(opi);
                    }
                    catch (ArgumentException)
                    {
                        // OpCode already exists, ignore
                        if (!Shared.IsDebug()) continue;
                    }
                }

                Console.WriteLine();
            }

            // Add to library list
            _libraryList.Add(classAssembly);
        }
        #endregion

        #region Execution functions
        /// <summary>
        /// Execute an opcode.
        /// </summary>
        /// <param name="opCode">Opcode name to execute.</param>
        /// <param name="data">Opcode data to pass.</param>
        /// <returns>The magic opcode used, if any.</returns>
        public MagicOpcodes ExecOpCode(string opCode, OpCodeData data)
        {
            if (!_opcodeCache.ContainsKey(opCode))
            {
                throw new MuftecGeneralException(data.RuntimeStack, "Unknown symbol '" + opCode + "' on line " + data.LineNumber);
            }

            if (Shared.IsDebug())
            {
                //MuftecGeneralException.MuftecStackTrace(runtimeStack);
            }

            // Get the opcode pointer
            var opCodeItem = _opcodeCache[opCode];

            // Handle exception catching inside the language here
            opCodeItem.Pointer(data);

            return opCodeItem.Attribute.Magic;
        }

        /// <summary>
        /// Run an execution stack.
        /// </summary>
        /// <param name="execStack">Execution stack to run.</param>
        /// <param name="runtimeStack">Runtime stack to use.</param>
        /// <param name="variableList">List of variables.</param>
        /// <param name="functionList">List of defined functions.</param>
        /// <returns>Stop execution if true.</returns>
        public bool Run(Queue<MuftecStackItem> execStack, Stack<MuftecStackItem> runtimeStack, IEnumerable<string> variableList = null, IEnumerable<KeyValuePair<string, Queue<MuftecStackItem>>> functionList = null)
        {
            // Add variables to global variable list
            if (variableList != null)
            {
                foreach (var variable in variableList.Where(w => !_globalVariableList.ContainsKey(w)))
                {
                    _globalVariableList.Add(variable, null);
                }
            }

            // Add functions to function list
            if (functionList != null)
            {
                foreach (var function in functionList)
                {
                    if (_globalFunctionList.ContainsKey(function.Key))
                    {
                        _globalFunctionList[function.Key] = function.Value;
                    }
                    else
                    {
                        _globalFunctionList.Add(function.Key, function.Value);
                    }
                }

            }

            // Iterate through each item on the execution stack
            while (execStack.Count > 0)
            {
                var currStackItem = execStack.Dequeue();

                switch (currStackItem.Type)
                {
                    // Run a user defined function
                    case MuftecType.Function:
                        var funcName = currStackItem.Item.ToString();

                        if (_globalFunctionList.ContainsKey(funcName))
                        {
                            // Make a copy of the function as it will be popped to execute
                            var queue = new Queue<MuftecStackItem>(_globalFunctionList[funcName]);

                            // TODO: Support local variables
                            if (Run(queue, runtimeStack))
                                return true;
                        }
                        else
                        {
                            throw new MuftecInvalidStackItemTypeException(runtimeStack);
                        }

                        break;

                        // Execute a library opcode
                    case MuftecType.OpCode:
                        // Collect opcode data
                        var data = new OpCodeData(runtimeStack, currStackItem.LineNumber);

                        // Execute the opcode
                        var magic = ExecOpCode(currStackItem.Item.ToString(), data);

                        // Handle post-execution magic
                        switch (magic)
                        {
                            case MagicOpcodes.Abort:
                                // Abort by exiting loop with true
                                return true;
                            case MagicOpcodes.Exit:
                                // Exit by returning from this run depth
                                return false;
                        }
                        break;

                    // Handle a conditional container
                    case MuftecType.Conditional:
                        var container = currStackItem.Item as ConditionalContainer;
                        if (container == null)
                            throw new MuftecGeneralException(runtimeStack, "Unable to process conditional statement.");

                        var check = Shared.PopInt(runtimeStack);
                        var queueToExecute = (check > 0) ? container.TrueQueue : container.FalseQueue;
                        
                        if (Run(queueToExecute, runtimeStack))
                            return true;

                        break;

                    // Add item to runtime stack
                    default:
                        runtimeStack.Push(currStackItem);
                        break;
                }
            }

            return false;
        }
        #endregion
    }
}