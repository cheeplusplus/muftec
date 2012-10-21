using System;
using System.Linq;

namespace MuftecLib.CompilerStates
{
    class EvaluatorState : ICompilerState
    {
        public ApplicationCore Core { get; set; }
        private ICompilerState CurrentMachine { get; set; }
        private bool IsFunction { get; set; }
        public string LastFunction { get; set; }

        public EvaluatorState(ApplicationCore core, bool isFunction = false)
        {
            Core = core;
            IsFunction = isFunction;
        }

        public bool EvaluateToken(string token)
        {
            if (CurrentMachine != null)
            {
                if (!CurrentMachine.EvaluateToken(token))
                {
                    var fState = CurrentMachine as FunctionState;
                    if (fState != null)
                    {
                        LastFunction = fState.Name;
                    }

                    CurrentMachine = null;
                }

                return true;
            }

            // Comments
            if (token.StartsWith("("))
            {
                CurrentMachine = new StringState(Core, "(", ")");
                CurrentMachine.EvaluateToken(token);
                return true;
            }

            // Variable initialization (var varname)
            if (token == "var")
            {
                if (IsFunction)
                    throw new MuftecCompilerException("Can't instance a global variable inside a function.", Core.LineNumber);

                CurrentMachine = new VariableState(Core);
                return true;
            }

            // Functions
            if (token == ":")
            {
                if (IsFunction)
                    throw new MuftecCompilerException("Can't start a function inside a function.", Core.LineNumber);

                CurrentMachine = new FunctionState(Core);
                return true;
            }

            // Only allow item types that use the queue after this point
            if (!IsFunction)
                throw new MuftecCompilerException("Invalid token outside of a function: \"" + token + "\"", Core.LineNumber);

            // Strings
            if (token.StartsWith("\""))
            {
                CurrentMachine = new StringState(Core, "\"");
                CurrentMachine.EvaluateToken(token);
                return true;
            }

            // Floats
            double floatVal;
            if (double.TryParse(token, out floatVal))
            {
                if (token.Contains("."))
                {
                    Core.Queue.Enqueue(new MuftecStackItem(floatVal));
                    return true;
                }
            }

            // Integers
            int intVal;
            if (int.TryParse(token, out intVal))
            {
                Core.Queue.Enqueue(new MuftecStackItem(intVal));
                return true;
            }

            // Symbols
            if (Core.Variables.Contains(token))
            {
                Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Variable));
                return true;
            }

            if (Core.Functions.ContainsKey(token))
            {
                Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Function));
                return true;
            }

            // OpCodes - assume any remaining value is an opcode, don't need to check
            Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.OpCode));
            return true;
        }
    }
}
