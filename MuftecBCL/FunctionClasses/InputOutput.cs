using System;
using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
	public static class InputOutput
	{
		/// <summary>
		/// print (a1 -- )
		/// Print a value to the console.
		/// </summary>
		/// <example>
		/// "Hello, world!" print ( -- )
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("print")]
		public static void Print(Stack<MuftecStackItem> runtimeStack)
		{
			Console.WriteLine(Shared.PopStringify(runtimeStack));
		}

		/// <summary>
		/// read ( -- str1)
		/// Read a string from stdin.
		/// </summary>
		/// <example>
		/// read ( returns ) "Hello!"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("read")]
		public static void ReadLine(Stack<MuftecStackItem> runtimeStack)
		{
			runtimeStack.Push(new MuftecStackItem(Console.ReadLine()));
		}
	}
}
