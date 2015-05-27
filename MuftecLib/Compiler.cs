using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Muftec.Lib.CompilerStates;

namespace Muftec.Lib
{
    /// <summary>
    /// Class that describes a Muftec compiler.
    /// </summary>
    public static class Compiler
    {
        /// <summary>
        /// Class that describes compiler output.
        /// </summary>
        public class CompilerOutput
        {
            /// <summary>
            /// Gets or sets the variable list.
            /// </summary>
            public List<string> Variables { get; set; }

            /// <summary>
            /// Gets or sets the function dictionary.
            /// </summary>
            public Dictionary<string, Queue<MuftecStackItem>> Functions { get; set; }

            /// <summary>
            /// Gets or sets the name of the main function.
            /// </summary>
            public string MainFunctionName { get; set; }

            /// <summary>
            /// Gets or sets a stack item pointing to the main function.
            /// </summary>
            public MuftecStackItem MainFunction { get; set; }
        }

        /// <summary>
        /// Parse a file into a stack queue.
        /// </summary>
        /// <param name="text">Text to parse.</param>
        /// <returns>Returns compiler output.</returns>
        public static CompilerOutput ParseString(string text)
        {
            var variables = new List<string>();
            var functions = new Dictionary<string, Queue<MuftecStackItem>>();
            var defines = new Dictionary<string, string>();
            var appState = new ApplicationCore(variables, functions, defines);
            var evaluator = new EvaluatorState(appState);

            var lineNum = 1;
            
            // Get each line to count
            foreach (var line in text.Replace("\r", "").Split('\n'))
            {
                try
                {
                    evaluator.EvaluateLine(line, lineNum);
                    lineNum++;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error parsing at line " + lineNum);
                    Console.WriteLine("-----");
                    Console.WriteLine(line);
                    Console.WriteLine("-----");

#if DEBUG
                    throw;
#else
                    Console.WriteLine(e);
                    Console.WriteLine("-----");

                    return null;
#endif
                }
            }

            // Return compiler output
            return new CompilerOutput { Variables = variables, Functions = functions, MainFunctionName = evaluator.LastFunction, MainFunction = new MuftecStackItem(evaluator.LastFunction, MuftecAdvType.Function) };
        }

        /// <summary>
        /// Save a compiled application into a byte array.
        /// </summary>
        /// <param name="compiled">Compiled application to save.</param>
        /// <returns>Saved queue.</returns>
        public static byte[] SaveApplication(CompilerOutput compiled)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, compiled);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Load a compiled application from a byte array.
        /// </summary>
        /// <param name="data">Saved queue to decode.</param>
        /// <returns>Original queue.</returns>
        public static CompilerOutput LoadApplication(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var bf = new BinaryFormatter();
                var stack = bf.Deserialize(ms) as CompilerOutput;
                return stack;
            }
        }
    }
}
