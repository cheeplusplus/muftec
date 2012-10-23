using System;

namespace Muftec.Lib.CompilerStates
{
    class ConditionalFunctionEvaluatorState : FunctionEvaluatorState
    {
        public enum ConditionalStatusType
        {
            None,
            Else,
            Then
        }

        public ConditionalStatusType ConditionalStatus { get; set; }

        public ConditionalFunctionEvaluatorState(ApplicationCore core) : base(core) { }

        protected override bool EvaluateSuperToken(string token)
        {
            if (token.ToLower() == "else")
            {
                // Already inside an if statement, so drop out
                ConditionalStatus = ConditionalStatusType.Else;
                return true;
            }
            if (token.ToLower() == "then")
            {
                // Already inside an if statement, so drop out
                ConditionalStatus = ConditionalStatusType.Then;
                return true;
            }

            // Reset conditional status
            ConditionalStatus = ConditionalStatusType.None;
            return false;
        }
    }
}
