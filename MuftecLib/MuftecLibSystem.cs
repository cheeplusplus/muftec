using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Muftec.Lib
{
	public delegate void OpCodePointer(Stack<MuftecStackItem> stack);

	public class MuftecLibSystem
	{
	    private readonly Dictionary<string, OpCodePointer> _opcodeCache = new Dictionary<string, OpCodePointer>();
	    private readonly Dictionary<string, MuftecStackItem> _globalVariableList = new Dictionary<string, MuftecStackItem>();
        private readonly Dictionary<string, Queue<MuftecStackItem>> _globalFunctionList = new Dictionary<string, Queue<MuftecStackItem>>();
		private readonly List<Assembly> _libraryList = new List<Assembly>();
		
		/// <summary>
		/// Register special opcodes that must be handled from inside THIS class
		/// </summary>
		public MuftecLibSystem()
		{
			_opcodeCache.Add("@", ReadVariable);
			_opcodeCache.Add("!", SetVariable);
			_opcodeCache.Add("loadlibdll", LoadLibraryDLL);
		}

		[OpCode("!")]
		private void ReadVariable(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			
            if (item1.Type == MuftecType.Variable)
			{
				if (_globalVariableList.ContainsKey(item1.Item.ToString()))
				{
					runtimeStack.Push(_globalVariableList[item1.Item.ToString()]);
				}
				else
				{
					throw new MuftecInvalidStackItemTypeException(runtimeStack);
				}
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		[OpCode("@")]
		private void SetVariable(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			var item2 = Shared.Pop(runtimeStack);
			
            if (item1.Type == MuftecType.Variable)
			{
				_globalVariableList.Add((string)item1.Item, item2);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		[OpCode("loadlibdll")]
		private void LoadLibraryDLL(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);

			if (item1.Type == MuftecType.String)
			{
				AddLibrary((string)item1.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

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

                    try
                    {
                        _opcodeCache.Add(code.OpCodeName, opc);
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

		public void ExecOpCode(string opCode, Stack<MuftecStackItem> runtimeStack)
		{
			if (!_opcodeCache.ContainsKey(opCode))
			{
				throw new MuftecGeneralException(runtimeStack);
			}

            if (Shared.IsDebug())
            {
                //MuftecGeneralException.MuftecStackTrace(runtimeStack);
            }

		    // Handle exception catching inside the language here
		    _opcodeCache[opCode].Invoke(runtimeStack);
		}

		public void Run(Queue<MuftecStackItem> execStack, Stack<MuftecStackItem> runtimeStack, IEnumerable<string> variableList = null, IEnumerable<KeyValuePair<string, Queue<MuftecStackItem>>> functionList = null)
		{
            if (variableList != null)
            {
                foreach (var variable in variableList.Where(w => !_globalVariableList.ContainsKey(w)))
                {
                    _globalVariableList.Add(variable, null);
                }
            }

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

		    while (execStack.Count > 0)
			{
			    var currStackItem = execStack.Dequeue();

                if (currStackItem.Type == MuftecType.Function)
                {
                    var funcName = currStackItem.Item.ToString();

                    if (_globalFunctionList.ContainsKey(funcName))
                    {
                        // Make a copy of the function as it will be popped to execute
                        var queue = new Queue<MuftecStackItem>(_globalFunctionList[funcName]);

                        // TODO: Support local variables
                        Run(queue, runtimeStack, variableList);
                    }
                    else
                    {
                        throw new MuftecInvalidStackItemTypeException(runtimeStack);
                    }
                }
			    else if (currStackItem.Type == MuftecType.OpCode)
				{
					ExecOpCode(currStackItem.Item.ToString(), runtimeStack);
				}
				else
				{
					runtimeStack.Push(currStackItem);
				}
			}
		}
	}
}