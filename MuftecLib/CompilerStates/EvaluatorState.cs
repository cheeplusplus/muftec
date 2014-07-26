using System;
using System.Linq;

namespace Muftec.Lib.CompilerStates
{
    class EvaluatorState : ICompilerState
    {
        public ApplicationCore Core { get; private set; }
        protected ICompilerState CurrentMachine { get; set; }
        protected bool IsFunction { get; set; }
        public string LastFunction { get; private set; }

        public EvaluatorState(ApplicationCore core)
        {
            Core = core;
        }

        public void EvaluateLine(string line, int lineNum)
        {
            Core.LineNumber = lineNum;

            var splitTokens = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            var handled = false;

            if (splitTokens.Count() > 1)
            {
                // TODO: Add proper error handling
                switch (splitTokens[0])
                {
                    case "var":
                        Core.Variables.Add(splitTokens[1]);
                        handled = true;
                        break;
                    case "$def":
                    case "$define":
                        var name = splitTokens[1];
                        var opers = splitTokens.Skip(2).ToList();
                        Core.Defines.Add(name, String.Join(" ", opers));
                        handled = true;
                        break;
                }
            }

            if (!handled)
            {
                // Split tokens in line
                foreach (var token in splitTokens)
                {
                    EvaluateToken(token);
                }
            }
        }

        public bool EvaluateToken(string token)
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
                var result = CurrentMachine.EvaluateToken(token);

                if (!result)
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

            // Perform define replacement
            if (Core.Defines.ContainsKey(token))
            {
                token = Core.Defines[token];
            }

            // Comments
            if (token.StartsWith("("))
            {
                CurrentMachine = new StringState("(", ")", true, true);
                CurrentMachine.EvaluateToken(token);
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
