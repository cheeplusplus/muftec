using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class Conversion : IOpCode
    {
        /// <summary>
        /// itof (n1 -- float1)
        /// Converts an integer to a float.
        /// </summary>
        /// <example>
        /// 2 itof ( returns ) 2.0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("itof")]
        public static void IntToFloat(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            Result.Item = (double)Item1.Item;

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// itos (n1 -- str1)
        /// Converts an integer to a string.
        /// </summary>
        /// <example>
        /// 2 itos ( returns ) "2"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("itos")]
        public static void IntToString(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = Item1.Item.ToString();

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ftoi (float1 -- n1)
        /// Converts an float to an integer by truncating.
        /// </summary>
        /// <example>
        /// 2.7 ftoi ( returns ) 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("ftoi")]
        public static void FloatToIntTruncate(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            Result.Item = (int)Item1.Item;

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ftoir (float1 -- n1)
        /// Converts an float to an integer by rounding.
        /// </summary>
        /// <example>
        /// 2.7 ftoir ( returns ) 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("ftior")]
        public static void FloatToIntRound(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            Result.Item = (int)System.Math.Round((double)Item1.Item,0);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ftos (n1 -- str1)
        /// Converts an float to a string.
        /// </summary>
        /// <example>
        /// 2.7 ftos ( returns ) "2.7"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("ftos")]
        public static void FloatToString(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = Item1.Item.ToString();

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// stoi (str1 -- n1)
        /// Converts an string to an integer.
        /// </summary>
        /// <example>
        /// "2" stoi ( returns ) 2
        /// </example>
        /// <param name="Stack">Reference to the current execution stack</param>
        [OpCode("stoi")]
        public static void StringToInt(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            try
            {
                Result.Item = int.Parse((string)Item1.Item);
            }
#pragma warning disable 168
            catch (FormatException ex)
            {
                throw new MuftecInvalidConversionException(ref RuntimeStack, "Could not convert from type String to Integer.");
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// stof (str1 -- float1)
        /// Converts an string to a float.
        /// </summary>
        /// <example>
        /// "2.2" stof ( returns ) 2.2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("stof")]
        public static void StringToFloat(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            try
            {
                Result.Item = float.Parse((string)Item1.Item);
            }
#pragma warning disable 168
            catch (FormatException ex)
            {
                throw new MuftecInvalidConversionException(ref RuntimeStack, "Could not convert from type String to Float");
            }

            RuntimeStack.Push(Result);
        }
    }
}
