using System;

namespace Muftec.Lib.CompilerStates
{
    class FunctionEvaluatorState : EvaluatorState
    {
        internal enum ConditionalStatusType
        {
            None,
            Else,
            Then
        }

        private readonly bool _insideConditional;
        internal ConditionalStatusType ConditionalStatus { get; set; }

        public FunctionEvaluatorState(ApplicationCore core, bool insideConditional = false) : base(core)
        {
            IsFunction = true;
            _insideConditional = insideConditional;
        }

        public new bool EvaluateToken(string token)
        {
            if (EvaluateAllToken(token))
                return true;

            // Strings
            if (token.StartsWith("\""))
            {
                CurrentMachine = new StringState(Core, "\"");
                if (!CurrentMachine.EvaluateToken(token))
                {
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
            if (token.ToLower() == "else")
            {
                if (!_insideConditional)
                    throw new MuftecCompilerException("Encountered else outside of if", Core.LineNumber);

                // Already inside an if statement, so drop out
                ConditionalStatus = ConditionalStatusType.Else;
                return true;
            }
            if (token.ToLower() == "then")
            {
                if (!_insideConditional)
                    throw new MuftecCompilerException("Encountered then outside of if", Core.LineNumber);

                // Already inside an if statement, so drop out
                ConditionalStatus = ConditionalStatusType.Then;
                return true;
            }
            
            // Reset conditional status
            ConditionalStatus = ConditionalStatusType.None;

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
