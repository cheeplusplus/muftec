using System;
using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Conversion
    {
        /// <summary>
        /// itof (n1 -- float1)
        /// Converts an integer to a float.
        /// </summary>
        /// <example>
        /// 2 itof ( returns ) 2.0
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("itof", "float")]
        public static void IntToFloat(OpCodeData data)
        {
            var item1 = Shared.PopInt(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem(Convert.ToDouble(item1)));
        }

        /// <summary>
        /// itos (n1 -- str1)
        /// Converts an integer to a string.
        /// </summary>
        /// <example>
        /// 2 itos ( returns ) "2"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("itos")]
        public static void IntToString(OpCodeData data)
        {
            var item1 = Shared.PopStringify(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem(item1));
        }

        /// <summary>
        /// ftoi (float1 -- n1)
        /// Converts an float to an integer by truncating.
        /// </summary>
        /// <example>
        /// 2.7 ftoi ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("ftoi")]
        public static void FloatToIntTruncate(OpCodeData data)
        {
            var item1 = Shared.PopFloat(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem(Convert.ToInt32(item1)));
        }

        /// <summary>
        /// ftoir (float1 -- n1)
        /// Converts an float to an integer by rounding.
        /// </summary>
        /// <example>
        /// 2.7 ftoir ( returns ) 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("ftior")]
        public static void FloatToIntRound(OpCodeData data)
        {
            var item1 = Shared.PopFloat(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem((int)System.Math.Round(item1, 0)));
        }

        /// <summary>
        /// ftos (n1 -- str1)
        /// Converts an float to a string.
        /// </summary>
        /// <example>
        /// 2.7 ftos ( returns ) "2.7"
        /// </example>
        /// <remarks>ftostr and ftostrc may not behave for compatibility.</remarks>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("ftos", "ftostr", "ftostrc")]
        public static void FloatToString(OpCodeData data)
        {
            var item1 = Shared.PopStringify(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem(item1));
        }

        /// <summary>
        /// stoi (str1 -- n1)
        /// Converts an string to an integer.
        /// </summary>
        /// <example>
        /// "2" stoi ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("stoi")]
        public static void StringToInt(OpCodeData data)
        {
            var item1 = Shared.PopStr(data.RuntimeStack);
            MuftecStackItem result;
            int outVal;

            if (int.TryParse(item1, out outVal))
            {
                result = new MuftecStackItem(outVal);
            }
            else
            {
                throw new MuftecInvalidConversionException(data.RuntimeStack, "Could not convert from type String to Integer.");
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// stof (str1 -- float1)
        /// Converts an string to a float.
        /// </summary>
        /// <example>
        /// "2.2" stof ( returns ) 2.2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("stof", "strtof")]
        public static void StringToFloat(OpCodeData data)
        {
            var item1 = Shared.PopStr(data.RuntimeStack);
            MuftecStackItem result;
            float outVal;

            if (float.TryParse(item1, out outVal))
            {
                result = new MuftecStackItem(outVal);
            }
            else
            {
                throw new MuftecInvalidConversionException(data.RuntimeStack, "Could not convert from type String to Float");
            }

            data.RuntimeStack.Push(result);
        }
    }
}
