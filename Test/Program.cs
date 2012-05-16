using System;
using System.Collections.Generic;
using MuftecLib;
using MuftecBCL;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var system = new MuftecLibSystem();
			var bcl = new MuftecBaseClassLibrary();
			system.AddLibrary(bcl);

			var execQueue = new Queue<MuftecStackItem>();
			execQueue.Enqueue(new MuftecStackItem(6));
			execQueue.Enqueue(new MuftecStackItem(4));
			execQueue.Enqueue(new MuftecStackItem("-", MuftecAdvType.OpCode));
			execQueue.Enqueue(new MuftecStackItem("print", MuftecAdvType.OpCode));

			var runStack = new Stack<MuftecStackItem>();

			try
			{
				system.Run(ref execQueue, runStack);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
			}
		}
	}
}
