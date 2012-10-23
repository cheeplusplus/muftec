using System;
using System.Collections.Generic;

namespace Muftec.Lib
{
    /// <summary>
    /// Class that contains data for each opcode.
    /// </summary>
    public class OpCodeData
    {
        public Stack<MuftecStackItem> RuntimeStack { get; private set; }
        public int LineNumber { get; private set; }

        public OpCodeData(Stack<MuftecStackItem> runtimeStack, int lineNumber = 0)
        {
            RuntimeStack = runtimeStack;
            LineNumber = lineNumber;
        }
    }
}
