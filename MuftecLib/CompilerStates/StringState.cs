using System.Text;

namespace Muftec.Lib.CompilerStates
{
    class StringState : ICompilerState
    {
        public ApplicationCore Core { get; set; }

        public string StartKey { get; private set; }
        public string EndKey { get; private set; }

        private StringBuilder Builder { get; set; }

        public StringState(ApplicationCore core, string startKey) : this(core, startKey, startKey)
        {
        }

        public StringState(ApplicationCore core, string startKey, string endKey)
        {
            Core = core;
            StartKey = startKey;
            EndKey = endKey;
            Builder = new StringBuilder();
        }

        public bool EvaluateToken(string token)
        {
            if (Builder.Length > 0)
                Builder.Append(' ');

            Builder.Append(token);

            if (token.EndsWith(EndKey))
            {
                var item = new MuftecStackItem(Builder.ToString(StartKey.Length, Builder.Length - StartKey.Length - EndKey.Length));
                Core.Queue.Enqueue(item);
                return false;
            }

            return true;
        }
    }
}