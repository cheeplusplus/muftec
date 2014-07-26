using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Muftec.BCL;
using Muftec.Lib;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var evalCount = 100000;

            var appRun = new StringBuilder();
            appRun.AppendLine(": main");
            for (var i = 0; i < evalCount; i++)
            {
                appRun.Append("100 100 + pop ");
            }
            appRun.AppendLine();
            appRun.AppendLine(";");
            var runStr = appRun.ToString();

            var buildTimer = new Stopwatch();
            buildTimer.Start();

            //// Create Muftec base system ////
            var system = new MuftecLibSystem();
            var bcl = new MuftecBaseClassLibrary();
            system.AddLibrary(bcl);

            var execStack = new Queue<MuftecStackItem>();
            var runStack = new Stack<MuftecStackItem>();
            var variables = new List<string>();
            var functions = new Dictionary<string, Queue<MuftecStackItem>>();

            var output = Compiler.ParseString(runStr);
            variables = output.Variables;
            functions = output.Functions;
            execStack.Enqueue(output.MainFunction);

            buildTimer.Stop();
            Console.WriteLine("Build stage took: {0} ticks", buildTimer.Elapsed);

            var runTimer = new Stopwatch();
            runTimer.Start();

            system.Run(execStack, runStack, variables, functions);

            runTimer.Stop();
            Console.WriteLine("Execution stage took: {0} ticks", runTimer.Elapsed);

            var stickTimer = new Stopwatch();
            stickTimer.Start();
            var outval = 0;

            for (var i = 0; i < evalCount; i++)
            {
                outval += 100 + 100;
            }

            stickTimer.Stop();
            Console.WriteLine("Comparison stage took: {0} ticks", stickTimer.Elapsed);

            /*
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
            }*/

            Console.WriteLine();
            Console.WriteLine("Press any key.");
            Console.ReadKey(true);
        }
    }
}
