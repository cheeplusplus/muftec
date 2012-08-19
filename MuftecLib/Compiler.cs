using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace MuftecLib
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
            /// Gets or sets the execution queue.
            /// </summary>
            public Queue<MuftecStackItem> Queue { get; set; }

            /// <summary>
            /// Gets or sets the variable list.
            /// </summary>
            public List<string> Variables { get; set; }

            /// <summary>
            /// Gets or sets the function dictionary.
            /// </summary>
            public Dictionary<string, Queue<MuftecStackItem>> Functions { get; set; }
        }

        /// <summary>
        /// Parse a file into a stack queue.
        /// </summary>
        /// <param name="text">Text to parse.</param>
        /// <returns>Returns compiler output.</returns>
        public static CompilerOutput ParseString(string text)
        {
            var queue = new Queue<MuftecStackItem>();

            var tokens = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // TODO: Find sections () "" :;
            var variables = new List<string>();
            var functions = new Dictionary<string, Queue<MuftecStackItem>>();

            // Parse sections
			foreach (var token in tokens.Select(s => s.Trim()))
			{
                // Comments
                // Discard

                // Variable initialization (var varname)

                // Functions
                // TODO: Figure out parsing : function ... ;

                // Strings
                // TODO: Figure out how to parse "test text"

			    // Floats
                double floatVal;
                if (double.TryParse(token, out floatVal))
			    {
                    if (token.Contains("."))
                    {
                        queue.Enqueue(new MuftecStackItem(floatVal));
                        continue;
                    }			        
			    }

			    // Integers
			    int intVal;
			    if (int.TryParse(token, out intVal))
			    {
			        queue.Enqueue(new MuftecStackItem(intVal));
			        continue;
			    }
                
			    // Symbols
                if (variables.Contains(token))
                {
                    queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Variable));
                    continue;
                }

                if (functions.ContainsKey(token))
                {
                    queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.Function));
                }

			    // OpCodes - assume any remaining value is an opcode, don't need to check
                queue.Enqueue(new MuftecStackItem(token, MuftecAdvType.OpCode));
			}

            return new CompilerOutput { Queue = queue, Variables = variables, Functions = functions };
        }

        private enum CompilerRegion
        {
            Comment,
            String,
            Function
        }

        /// <summary>
        /// Save a stack queue into a byte array.
        /// </summary>
        /// <param name="queue">Queue to save.</param>
        /// <returns>Saved queue.</returns>
        public static byte[] SaveStack(Queue<MuftecStackItem> queue)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, queue);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Load a stack queue from a byte array.
        /// </summary>
        /// <param name="data">Saved queue to decode.</param>
        /// <returns>Original queue.</returns>
        public static Queue<MuftecStackItem> LoadStack(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var bf = new BinaryFormatter();
                var stack = bf.Deserialize(ms) as Queue<MuftecStackItem>;
                return stack;
            }
        }

        /// <summary>
        /// Compile a stack queue into an assembly.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="filename"></param>
        public static void SaveAssembly(Queue<MuftecStackItem> queue, string filename)
        {
            throw new NotImplementedException();
        }
	}
}
