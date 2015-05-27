using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Muftec.Lib;
using Sigil;
using Muftec.BCL;

namespace Muftec
{
    class Fabricator
    {
        public bool IsDebug { get; set; }

        private readonly Compiler.CompilerOutput _output;
        private Dictionary<string, Emit<MuftecFunction>> _funcCache;
        private readonly MuftecLibSystem _system;

        public Fabricator(Compiler.CompilerOutput output)
        {
            _output = output;
            _funcCache = new Dictionary<string, Emit<MuftecFunction>>();

            // Create a BCL-based system for compile-time opcode referencing
            _system = new MuftecLibSystem();
            var bcl = new MuftecBaseClassLibrary();
            _system.AddLibrary(bcl);
        }

        private MethodInfo Generate(String assemblyName, ModuleBuilder moduleBuilder)
        {
            var tb = moduleBuilder.DefineType(assemblyName + ".Program", TypeAttributes.Class | TypeAttributes.Public);
            var main = Emit<Action<string[]>>.BuildStaticMethod(tb, "Main", MethodAttributes.Public);

            // Create the runtime stack
            var runtime = main.DeclareLocal<Stack<MuftecStackItem>>("runtime");
            main.NewObject<Stack<MuftecStackItem>>();
            main.StoreLocal(runtime);

            // Populate variables list
            /*var variables = main.DeclareLocal<string[]>("vars");
            main.LoadConstant(_output.Variables.Count);
            main.NewArray<string>();
            main.StoreLocal(variables);

            var i = 0;
            foreach (var variable in _output.Variables)
            {
                main.LoadConstant(variable);
                main.LoadConstant(i);
                main.LoadLocal(variables);
                main.StoreElement<string>();
                i++;
            }*/

            // Create dummy functions
            foreach (var func in _output.Functions)
            {
                DebugMsg("Creating bare function for '{0}'", func.Key);
                _funcCache.Add(func.Key, Emit<MuftecFunction>.BuildStaticMethod(tb, "func_" + func.Key, MethodAttributes.Private));
            }
            
            // Populate function content
            foreach (var func in _funcCache)
            {
                var origFunc = _output.Functions[func.Key];
                DebugMsg("Creating full method for function '{0}'", func.Key);
                var funcDef = func.Value;

                // Store the RuntimeStack in a local variable
                var runtimeStack = funcDef.DeclareLocal<Stack<MuftecStackItem>>("runtimeStack");
                funcDef.LoadArgument(0);
                funcDef.Call(typeof(OpCodeData).GetProperty("RuntimeStack").GetGetMethod());
                funcDef.StoreLocal(runtimeStack);

                GenerateFunctionInner(funcDef, origFunc, runtimeStack);
                funcDef.Return();
                funcDef.CreateMethod();
            }

            DebugMsg("Finishing!");

            // Call the main function
            main.LoadLocal(runtime);
            main.LoadConstant(0);
            main.NewObject<OpCodeData, Stack<MuftecStackItem>, int>();

            var mainFunc = _funcCache[_output.MainFunctionName];
            main.Call(mainFunc);
            main.Return();
            
            var mi = main.CreateMethod();
            tb.CreateType();
            return mi;
        }

        private delegate void MuftecFunction(OpCodeData data);
        
        private void GenerateFunctionInner(Emit<MuftecFunction> funcDef, Queue<MuftecStackItem> execStack, Local runtimeStack, MuftecStackItem lastItem = default(MuftecStackItem))
        {
            DebugMsg("- Call stack -> {0}", String.Join(", ", execStack.ToArray()));

            var stackPush = typeof (Stack<MuftecStackItem>).GetMethod("Push");

            while (execStack.Count > 0)
            {
                var currStackItem = execStack.Dequeue();
                DebugMsg("- Popping stack item: " + currStackItem.ToDebugString());

                switch (currStackItem.Type)
                {
                    // Run a user defined function
                    case MuftecType.Function:
                        // Find the function and create an IL call
                        var funcName = currStackItem.Item.ToString();
                        DebugMsg(" -- Call function {0}", funcName);
                        var func = _funcCache[funcName];
                        funcDef.LoadArgument(0); // Load OpCodeData into stack
                        funcDef.Call(func);
                        break;

                    // Execute a library opcode
                    case MuftecType.OpCode:
                        // Translate opcode into direct call
                        var opCodeName = currStackItem.Item.ToString();
                        DebugMsg(" >> Call opcode {0}", opCodeName);
                        var opCode = _system.FindOpCode(opCodeName);

                        // If this is an internal opcode, we need to handle it at this level
                        if (opCode.Attribute.Extern)
                        {
                            switch (opCode.Attribute.OpCodeName)
                            {
                                case "!":
                                case "@":
                                    throw new MuftecCompilerException("Variables not supported in the fabricator at line " + currStackItem.LineNumber);
                                case "loadlibdll":
                                    funcDef.LoadLocal(runtimeStack);
                                    funcDef.Call(typeof (Shared).GetMethod("PopStr"));
                                    _system.AddLibrary(lastItem.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            funcDef.LoadArgument(0); // Load OpCodeData into the stack
                            funcDef.Call(opCode.Pointer.Method); // Call OpCode function
                        }

                        // Handle post-execution magic
                        var magic = opCode.Attribute.Magic;
                        switch (magic)
                        {
                            case MagicOpcodes.Abort:
                                // End exeuction
                                DebugMsg(" ---- Abort");
                                funcDef.LoadConstant(0);
                                funcDef.Call(typeof (Environment).GetMethod("Exit"));
                                return;
                            case MagicOpcodes.Exit:
                                DebugMsg(" ---- Exit");
                                // Exit out of this loop
                                return;
                        }
                        break;

                    // Handle a conditional container
                    case MuftecType.Conditional:
                        var container = currStackItem.Item as ConditionalContainer;
                        if (container == null)
                            throw new MuftecCompilerException("Unable to process conditional statement at line " + currStackItem.LineNumber);

                        DebugMsg(" -- Container");
                        var ltLabel = funcDef.DefineLabel();
                        var endLabel = funcDef.DefineLabel();
                        funcDef.LoadLocal(runtimeStack); // Get the RuntimeStack
                        funcDef.Call(typeof (Shared).GetMethod("PopInt")); // Call PopInt on RuntimeStack
                        funcDef.BranchIfFalse(ltLabel);

                        // GT operations
                        DebugMsg(" -- Starting true condition");
                        GenerateFunctionInner(funcDef, container.TrueQueue, runtimeStack, lastItem);
                        funcDef.Branch(endLabel);

                        // LT operations
                        funcDef.MarkLabel(ltLabel);
                        DebugMsg(" -- Starting false condition");
                        GenerateFunctionInner(funcDef, container.FalseQueue, runtimeStack, lastItem);

                        funcDef.MarkLabel(endLabel);
                        DebugMsg(" -- Conditions done");
                        break;

                    // Add item to the runtime stack
                    case MuftecType.Integer:
                        DebugMsg(" -- Pushing int {0} to RS", currStackItem.ToString());
                        funcDef.LoadLocal(runtimeStack); // Get the RuntimeStack
                        funcDef.LoadConstant((int)currStackItem.Item);
                        funcDef.LoadConstant(currStackItem.LineNumber);
                        funcDef.NewObject<MuftecStackItem, int, int>();
                        funcDef.Call(stackPush);
                        break;
                    case MuftecType.Float:
                        DebugMsg(" -- Pushing float {0} to RS", currStackItem.ToString());
                        funcDef.LoadLocal(runtimeStack); // Get the RuntimeStack
                        funcDef.LoadConstant((double)currStackItem.Item);
                        funcDef.LoadConstant(currStackItem.LineNumber);
                        funcDef.NewObject<MuftecStackItem, double, int>();
                        funcDef.Call(stackPush);
                        break;
                    case MuftecType.String:
                        DebugMsg(" -- Pushing string {0} to RS", currStackItem.ToString());
                        funcDef.LoadLocal(runtimeStack); // Get the RuntimeStackp =
                        funcDef.LoadConstant((string)currStackItem.Item);
                        funcDef.LoadConstant(currStackItem.LineNumber);
                        funcDef.NewObject<MuftecStackItem, string, int>();
                        funcDef.Call(stackPush);
                        break;
                    case MuftecType.ArrayMarker:
                        DebugMsg(" -- Pushing array marker to RS");
                        funcDef.LoadLocal(runtimeStack); // Get the RuntimeStack
                        funcDef.LoadConstant((int)currStackItem.Item);
                        funcDef.Call(typeof(MuftecStackItem).GetMethod("CreateArrayMarker"));
                        funcDef.Call(stackPush);
                        break;
                }

                lastItem = currStackItem;
            }
        }

        public void Save(string filename)
        {
            if (filename == null) return;
            var name = System.IO.Path.GetFileNameWithoutExtension(filename);
            if (name == null) return;
            name = name.Replace('.', '_');
            name = new Regex("[^a-zA-Z0-9_]").Replace(name, ""); // Strip nonalphanumeric
            var assemblyName = "Muftec.Fabricated." + name + "_muf";

            var builder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Save);
            var mod = builder.DefineDynamicModule(name + "_muf.exe", filename);
            var main = Generate(assemblyName, mod);
            builder.SetEntryPoint(main);
            builder.Save(filename);
        }

        public static void SaveAssembly(Compiler.CompilerOutput output, string filename, bool isDebug = false)
        {
            var fab = new Fabricator(output);
            fab.IsDebug = isDebug;
            fab.Save(filename);
        }

        private void DebugMsg(string message, params object[] args)
        {
            if (!IsDebug) return;

            Console.WriteLine(message, args);
        }
    }
}
