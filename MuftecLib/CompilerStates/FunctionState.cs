using System.Collections.Generic;

namespace Muftec.Lib.CompilerStates
{
    class FunctionState : ICompilerState
    {
        public ApplicationCore Core { get; set; }
        private FunctionEvaluatorState Evaluator { get; set; }
        private ApplicationCore FunctionCore { get; set; }
        public string Name { get; set; }

        public FunctionState(ApplicationCore core)
        {
            Core = core;
            FunctionCore = CreateFunctionCore(core);
            Evaluator = new FunctionEvaluatorState(FunctionCore);
        }

        private ApplicationCore CreateFunctionCore(ApplicationCore existingCore)
        {
            var queue = new Queue<MuftecStackItem>();
            return new ApplicationCore(existingCore.Variables, existingCore.Functions, queue);
        }

        public bool EvaluateToken(string token)
        {
            // Name will be the first arg after the :
            if (Name == null)
            {
                if (Core.Functions.ContainsKey(token))
                    throw new MuftecCompilerException("Function " + token + " already defined.", Core.LineNumber);

                Name = token;
                return true;
            }

            // ; ends a function
            if (token == ";")
            {
                Core.Functions.Add(Name, FunctionCore.Queue);
                return false;
            }

            // Send all other tokens to the evaluator
            return Evaluator.EvaluateToken(token);
        }
    }
}