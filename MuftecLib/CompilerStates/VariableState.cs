namespace MuftecLib.CompilerStates
{
    class VariableState : ICompilerState
    {
        public ApplicationCore Core { get; set; }

        public VariableState(ApplicationCore core)
        {
            Core = core;
        }

        public bool EvaluateToken(string token)
        {
            if (Core.Variables.Contains(token))
                throw new MuftecCompilerException("Variable list already includes " + token, Core.LineNumber);

            Core.Variables.Add(token);
            return false;
        }
    }
}