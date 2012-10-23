using System.Text;

namespace Muftec.Lib.CompilerStates
{
    class StringState : ICompilerState
    {
        public ApplicationCore Core { get; set; }

        public string StartKey { get; private set; }
        public string EndKey { get; private set; }
        public bool Discard { get; private set; }

        private StringBuilder Builder { get; set; }

        public StringState(ApplicationCore core, string startKey, bool discard = false) : this(core, startKey, startKey, discard)
        {
        }

        public StringState(ApplicationCore core, string startKey, string endKey, bool discard = false)
        {
            Core = core;
            StartKey = startKey;
            EndKey = endKey;
            Discard = discard;
            Builder = new StringBuilder();
        }

        public bool EvaluateToken(string token)
        {
            if (Builder.Length > 0)
                Builder.Append(' ');

            Builder.Append(token);

            if (token.EndsWith(EndKey))
            {
                if (!Discard)
                {
                    var item = new MuftecStackItem(Builder.ToString(StartKey.Length, Builder.Length - StartKey.Length - EndKey.Length));
                    Core.Queue.Enqueue(item);
                }

                return false;
            }

            return true;
        }
    }
}