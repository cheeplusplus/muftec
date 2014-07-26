using System.Collections.Generic;

namespace Muftec.Lib.CompilerStates
{
    class ApplicationCore
    {
        public Queue<MuftecStackItem> Queue { get; set; }
        public List<string> Variables { get; set; }
        public Dictionary<string, Queue<MuftecStackItem>> Functions { get; set; }
        public Dictionary<string, string> Defines { get; set; }
        public int LineNumber { get; internal set; }

        public ApplicationCore(List<string> variables, Dictionary<string, Queue<MuftecStackItem>> functions, Dictionary<string, string> defines, Queue<MuftecStackItem> queue = null, int lineNumber = 0)
        {
            Queue = queue;
            Variables = variables;
            Functions = functions;
            Defines = defines;
            LineNumber = lineNumber;
        }
    }
}