namespace Muftec.Lib.CompilerStates
{
    interface ICompilerState
    {
        ApplicationCore Core { get; }

        /// <summary>
        /// Evaluate a token.
        /// </summary>
        /// <param name="token">Token to evaluate.</param>
        /// <returns>Returns true if evaluation should continue with this machine, or false if not.</returns>
        bool EvaluateToken(string token);
    }
}