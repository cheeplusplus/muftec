namespace Muftec.Lib.CompilerStates
{
    class FunctionEvaluatorState : EvaluatorState
    {
        public FunctionEvaluatorState(ApplicationCore core) : base(core)
        {
            IsFunction = true;
        }

        public new bool EvaluateToken(string token)
        {
            if (EvaluateAllToken(token))
                return true;

            // Strings
            if (token.StartsWith("\""))
            {
                CurrentMachine = new StringState("\"");
                if (!CurrentMachine.EvaluateToken(token))
                {
                    var ss = CurrentMachine as StringState;
                    Core.Queue.Enqueue(ss.ResultString);
                    CurrentMachine = null;
                }
                return true;
            }

            // Conditionals
            if (token.ToLower() == "if")
            {
                CurrentMachine = new ConditionalState(Core);
                return true;
            }

            if (EvaluateSuperToken(token))
            {
                return true;
            }

            // Floats
            double floatVal;
            if (double.TryParse(token, out floatVal))
            {
                if (token.Contains("."))
                {
                    Core.Queue.Enqueue(floatVal);
                    return true;
                }
            }

            // Integers
            int intVal;
            if (int.TryParse(token, out intVal))
            {
                Core.Queue.Enqueue(intVal);
                return true;
            }

            // Symbols
            if (Core.Variables.Contains(token))
            {
                Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Variable, Core.LineNumber));
                return true;
            }

            if (Core.Functions.ContainsKey(token))
            {
                Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Function, Core.LineNumber));
                return true;
            }

            // OpCodes - assume any remaining value is an opcode, don't need to check
            Core.Queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.OpCode, Core.LineNumber));
            return true;
        }

        protected virtual bool EvaluateSuperToken(string token)
        {
            return false;
        }
    }
}
