using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MuftecBCL;
using MuftecLib;

namespace Muftec
{
	public class Program
	{
		public static void Main(string[] args)
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
                var text = File.ReadAllText(args[1]);
                var output = Compiler.ParseString(text);

                var system = new MuftecLibSystem();
                var bcl = new MuftecBaseClassLibrary();
                system.AddLibrary(bcl);

                var runtime = new Stack<MuftecStackItem>();
                system.Run(output.Queue, runtime, output.Variables, output.Functions);
			}
			else if (args[0] == "-c")
			{
				// Compile a program
			    var text = File.ReadAllText(args[1]);
			    var output = Compiler.ParseString(text);
                Compiler.SaveAssembly(output.Queue, args[1] + ".exe");
			}
			else
			{
				Console.WriteLine("Invalid switch specified.");
			}
		}
	}
}
