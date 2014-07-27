using System;

namespace Muftec.Lib
{
    /// <summary>
    /// Attribute applied to opcodes
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OpCodeAttribute : Attribute
    {
        public string OpCodeName { get; private set; }

        public string[] Aliases { get; private set; }

        public MagicOpcodes Magic { get; set; }

        public bool Extern { get; set; }

        /// <summary>
        /// Sets the OpCode name for this function.
        /// </summary>
        /// <param name="opCodeName">Name of OpCode</param>
        public OpCodeAttribute(string opCodeName)
        {
            OpCodeName = opCodeName;
        }

        public OpCodeAttribute(string opCodeName, params string[] opCodeNames)
        {
            OpCodeName = opCodeName;
            Aliases = opCodeNames;
        }
    }

    public enum MagicOpcodes
    {
        None,
        Abort,
        Exit
    }
}
