using System;
using System.IO;
using System.Linq;

namespace Muftec
{
	class Compiler
	{
		public Compiler(string filename)
		{
			TextReader reader;

			try
			{
				reader = new StreamReader(filename);
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file {0} could not be found.", filename);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error has occoured while opening the file for reading.");
#if DEBUG
				Console.WriteLine("Error details:");
				Console.WriteLine(" Source: {0}\r\n Message: {1}", ex.Source, ex.Message);
#endif
				return;
			}

		    var tempStr = reader.ReadToEnd();
		    var tokens = tempStr.Split(' ', '\r', '\n');

			foreach (var token in tokens.Where(w => !String.IsNullOrEmpty(w.Trim())))
			{
			    Console.WriteLine("Instruction: {0}", token);
			}
		}
	}
}
