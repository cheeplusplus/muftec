using System;
using System.Collections.Generic;
using MuftecLib;

namespace MuftecBCL.FunctionClasses
{
    public class Conversion : IMuftecGroup
	{
		/// <summary>
		/// itof (n1 -- float1)
		/// Converts an integer to a float.
		/// </summary>
		/// <example>
		/// 2 itof ( returns ) 2.0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("itof")]
		public static void IntToFloat(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(Convert.ToDouble(item1)));
		}

		/// <summary>
		/// itos (n1 -- str1)
		/// Converts an integer to a string.
		/// </summary>
		/// <example>
		/// 2 itos ( returns ) "2"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("itos")]
		public static void IntToString(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStringify(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1));
		}

		/// <summary>
		/// ftoi (float1 -- n1)
		/// Converts an float to an integer by truncating.
		/// </summary>
		/// <example>
		/// 2.7 ftoi ( returns ) 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("ftoi")]
		public static void FloatToIntTruncate(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(Convert.ToInt32(item1)));
		}

		/// <summary>
		/// ftoir (float1 -- n1)
		/// Converts an float to an integer by rounding.
		/// </summary>
		/// <example>
		/// 2.7 ftoir ( returns ) 3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("ftior")]
		public static void FloatToIntRound(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem((int)System.Math.Round(item1, 0)));
		}

		/// <summary>
		/// ftos (n1 -- str1)
		/// Converts an float to a string.
		/// </summary>
		/// <example>
		/// 2.7 ftos ( returns ) "2.7"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("ftos")]
		public static void FloatToString(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStringify(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1));
		}

		/// <summary>
		/// stoi (str1 -- n1)
		/// Converts an string to an integer.
		/// </summary>
		/// <example>
		/// "2" stoi ( returns ) 2
		/// </example>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("stoi")]
		public static void StringToInt(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			MuftecStackItem result;
		    int outVal;

            if (int.TryParse(item1, out outVal))
            {
                result = new MuftecStackItem(outVal);
            }
            else
            {
                throw new MuftecInvalidConversionException(runtimeStack, "Could not convert from type String to Integer.");
            }

			runtimeStack.Push(result);
		}

		/// <summary>
		/// stof (str1 -- float1)
		/// Converts an string to a float.
		/// </summary>
		/// <example>
		/// "2.2" stof ( returns ) 2.2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("stof")]
		public static void StringToFloat(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			MuftecStackItem result;
            float outVal;

            if (float.TryParse(item1, out outVal))
            {
                result = new MuftecStackItem(outVal);
            }
            else
            {
                throw new MuftecInvalidConversionException(runtimeStack, "Could not convert from type String to Float");
            }

			runtimeStack.Push(result);
		}
	}
}
