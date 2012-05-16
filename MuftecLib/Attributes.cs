using System;

namespace MuftecLib
{
	/// <summary>
	/// Attribute applied to Muftec Class Libraries
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class MuftecClassLibraryAttribute : Attribute
	{
	    public string Name { get; set; }

	    public MuftecClassLibraryAttribute(string name)
		{
		    Name = name;
		}
	}

	/// <summary>
	/// Attribute applied to opcodes
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class OpCodeAttribute : Attribute
	{
	    public string OpCodeName { get; set; }

	    /// <summary>
		/// Sets the OpCode name for this function.
		/// </summary>
		/// <param name="opCodeName">Name of OpCode</param>
		public OpCodeAttribute(string opCodeName)
		{
			OpCodeName = opCodeName;
		}
	}
}
