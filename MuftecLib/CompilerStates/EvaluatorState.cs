namespace Muftec.Lib.CompilerStates
{
    class EvaluatorState : ICompilerState
    {
        public ApplicationCore Core { get; set; }
        protected ICompilerState CurrentMachine { get; set; }
        protected bool IsFunction { get; set; }
        public string LastFunction { get; set; }

        public EvaluatorState(ApplicationCore core)
        {
            Core = core;
        }

        public virtual bool EvaluateToken(string token)
        {
            if (!EvaluateAllToken(token))
            {
                // Only allow item types that use the queue after this point
                throw new MuftecCompilerException("Invalid token outside of a function: \"" + token + "\"", Core.LineNumber);
            }

            return true;
        }

        /// <summary>
        /// Evaluate a token on all global operations.
        /// </summary>
        /// <param name="token">Token to evaluate.</param>
        /// <returns>True if an evaluation occoured, false if not.</returns>
        protected bool EvaluateAllToken(string token)
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
                CurrentMachine = new StringState(Core, "(", ")", true);
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

            return false;
        }
    }
}
