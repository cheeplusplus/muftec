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

        public MagicOpcodes Magic { get; set; }

	    /// <summary>
		/// Sets the OpCode name for this function.
		/// </summary>
		/// <param name="opCodeName">Name of OpCode</param>
		public OpCodeAttribute(string opCodeName)
		{
			OpCodeName = opCodeName;
		}
	}

    public enum MagicOpcodes
    {
        None,
        Abort,
        Exit
    }
}
