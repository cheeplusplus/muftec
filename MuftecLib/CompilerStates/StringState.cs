using System.Collections.Generic;
using System.Text;

namespace Muftec.Lib.CompilerStates
{
    class StringState : ICompilerState
    {
        public string ResultString { get; private set; }

        public string StartKey { get; private set; }
        public string EndKey { get; private set; }
        public bool Discard { get; private set; }
        public bool Nested { get; private set; }

        private int _nest;

        private StringBuilder Builder { get; set; }

        public StringState(string startKey, bool discard = false, bool nested = false) : this(startKey, startKey, discard, nested)
        {
        }

        public StringState(string startKey, string endKey, bool discard = false, bool nested = false)
        {
            StartKey = startKey;
            EndKey = endKey;
            Discard = discard;
            Nested = nested;
            Builder = new StringBuilder();
        }

        public bool EvaluateToken(string token)
        {
            if (Builder.Length > 0)
                Builder.Append(' ');

            Builder.Append(token);

            // Only count nests if we're nested
            if (Nested && token.StartsWith(StartKey))
                _nest++;

            if (token.EndsWith(EndKey))
            {
                if (!Discard)
                {
                    ResultString = Builder.ToString(StartKey.Length, Builder.Length - StartKey.Length - EndKey.Length);
                }

                _nest--;

                // Only exit if we've unnested
                if (_nest <= 0)
                    return false;
            }

            return true;
        }
    }
}