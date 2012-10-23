using System;

namespace Muftec.Lib.CompilerStates
{
    class FunctionEvaluatorState : EvaluatorState
    {
        public FunctionEvaluatorState(ApplicationCore core) : base(core)
        {
            IsFunction = true;
        }

        public override bool EvaluateToken(string token)
        {
            if (EvaluateAllToken(token))
                return true;

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
