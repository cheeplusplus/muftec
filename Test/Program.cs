using System;
using System.Collections.Generic;
using Muftec.BCL;
using Muftec.Lib;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Create Muftec base system ////
            var system = new MuftecLibSystem();
            var bcl = new MuftecBaseClassLibrary();
            system.AddLibrary(bcl);

            var execQueue = new Queue<MuftecStackItem>();
            var variables = new List<string>();
            var functions = new Dictionary<string, Queue<MuftecStackItem>>();

            //// Sample code ////
            Console.WriteLine("Running sample code.");

            execQueue.Enqueue(new MuftecStackItem(6));
            execQueue.Enqueue(new MuftecStackItem(4));
            execQueue.Enqueue(new MuftecStackItem("-", MuftecAdvType.OpCode));
            execQueue.Enqueue(new MuftecStackItem("print", MuftecAdvType.OpCode));

            var runStack = new Stack<MuftecStackItem>();

            try
            {
                system.Run(execQueue, runStack);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine();

            //// Compiler ////
            Console.WriteLine("Running compiler.");

            var text = System.IO.File.ReadAllText("Sample.muf");

            try
            {
                var output = Compiler.ParseString(text);
                variables = output.Variables;
                functions = output.Functions;
                execQueue = new Queue<MuftecStackItem>();
                execQueue.Enqueue(new MuftecStackItem(output.MainFunction, MuftecAdvType.Function));
            }
            catch (MuftecCompilerException ex)
            {
                Console.WriteLine("Compiler exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Executing compiled code.");
                runStack = new Stack<MuftecStackItem>();

                try
                {
                    system.Run(execQueue, runStack, variables, functions);
                }
                catch (MuftecGeneralException ex)
                {
                    Console.WriteLine("Muftec exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Complete.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key.");
            Console.ReadKey(true);
        }
    }
}
