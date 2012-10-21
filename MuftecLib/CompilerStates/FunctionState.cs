using System.Collections.Generic;

namespace Muftec.Lib.CompilerStates
{
    class FunctionState : ICompilerState
    {
        public ApplicationCore Core { get; set; }
        private ICompilerState InternalMachine { get; set; }
        private ApplicationCore FunctionCore { get; set; }
        public string Name { get; set; }

        public FunctionState(ApplicationCore core)
        {
            Core = core;
            FunctionCore = CreateFunctionCore(core);
            InternalMachine = new EvaluatorState(FunctionCore, true);
        }

        private ApplicationCore CreateFunctionCore(ApplicationCore existingCore)
        {
            var queue = new Queue<MuftecStackItem>();
            return new ApplicationCore(existingCore.Variables, existingCore.Functions, queue);
        }

        public bool EvaluateToken(string token)
        {
            if (Name == null)
            {
                if (Core.Functions.ContainsKey(token))
                    throw new MuftecCompilerException("Function " + token + " already defined.", Core.LineNumber);

                Name = token;
                return true;
            }

            if (token == ";")
            {
                Core.Functions.Add(Name, FunctionCore.Queue);
                return false;
            }

            return InternalMachine.EvaluateToken(token);
        }
    }
}