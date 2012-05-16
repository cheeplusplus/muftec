using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.Types
{
	interface IMuftecStackItem
	{
		MuftecType type;
		object value;
	}

	/// <summary>
	/// The type of item in the stack.
	/// </summary>
	public enum MuftecType
	{
		/// <summary>
		/// Integer (ex. 24)
		/// </summary>
		Integer,

		/// <summary>
		/// Float (ex. 1.234)
		/// </summary>
		Float,

		/// <summary>
		/// String (ex. "Joy")
		/// </summary>
		String,

		/// <summary>
		/// Opcode (ex. concat)
		/// </summary>
		OpCode,

		/// <summary>
		/// Variable (ex. @somevar or !somevar)
		/// </summary>
		Variable
	}
}
