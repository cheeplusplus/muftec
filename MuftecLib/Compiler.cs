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
            /// Gets or sets the main function.
            /// </summary>
            public string MainFunction { get; set; }
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
            var appState = new ApplicationCore(variables, functions);
            var evaluator = new EvaluatorState(appState);

            var lineNum = 1;
            
            // Get each line to count
            foreach (var lines in text.Replace("\r", "").Split('\n'))
            {
                evaluator.Core.LineNumber = lineNum;

                // Split tokens in line
                foreach (var token in lines.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()))
                {
                    evaluator.EvaluateToken(token);
                }

                lineNum++;
            }

            // Return compiler output
            return new CompilerOutput { Variables = variables, Functions = functions, MainFunction = evaluator.LastFunction };
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

        /// <summary>
        /// Compile a compiled application into an assembly.
        /// </summary>
        /// <param name="compiled"></param>
        /// <param name="filename"></param>
        public static void SaveAssembly(CompilerOutput compiled, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
