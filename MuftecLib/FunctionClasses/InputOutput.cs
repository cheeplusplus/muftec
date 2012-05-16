using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class InputOutput : IOpCode
    {
        /// <summary>
        /// print (str1 -- )
        /// Print a string to the console.
        /// </summary>
        /// <example>
        /// "Hello, world!" print ( -- )
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("print")]
        public static void Print(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            Console.WriteLine((string)Item1.Item);
        }

        /// <summary>
        /// read (str1 -- )
        /// Read a string from stdin.
        /// </summary>
        /// <example>
        /// read ( returns ) "Hello!"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("read")]
        public static void ReadLine(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Result = new MuftecStackItem();
            Result.Type = MuftecType.String;
            Result.Item = Console.ReadLine();

            RuntimeStack.Push(Result);
        }
    }
}
