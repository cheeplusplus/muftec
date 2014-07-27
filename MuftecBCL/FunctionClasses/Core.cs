using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Core
    {
        [OpCode("abort", Magic = MagicOpcodes.Abort)]
        public static void Abort(OpCodeData data)
        {
            var message = data.RuntimeStack.PopStr();
            Console.WriteLine("ABORT (line {0}): {1}", data.LineNumber, message);
        }

        [OpCode("exit", Magic = MagicOpcodes.Exit)]
        public static void Exit(OpCodeData data)
        {
            // Let magic do its magic
        }
    }
}
