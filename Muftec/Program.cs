using System;
using System.Collections.Generic;
using System.Text;

namespace Muftec
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Muftec 1.0");
				Console.WriteLine("Put some help documentation here, eventually.");
				Console.WriteLine("----------------------------------------");
				Console.WriteLine("muftec -x <source file>   -- Execute a source file");
				Console.WriteLine("muftec -c <source file>   -- Compiles a source file to a executable");
				Console.WriteLine("	   -o <out file>	  -- (Optional) Define the output filename");
			}
			else if (args[0] == "-x")
			{
				// Run a program
			}
			else if (args[0] == "-c")
			{
				// Compile a program
				var comp = new Compiler(args[1]);
			}
			else
			{
				Console.WriteLine("Invalid switch specified.");
			}
		}
	}
}
