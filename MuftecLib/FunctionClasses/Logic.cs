using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class Logic : IOpCode
    {
        /// <summary>
        /// = (n1 n2 -- n3)
        /// Determine if n1 is equal to n2. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 2 3 = ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("=")]
        public static void EqualTo(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item == (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item == (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// &lt; (n1 n2 -- n3)
        /// Determine if n1 is less than n2. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 2 3 &lt; ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("<")]
        public static void LessThan(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item < (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item < (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// &lt;= (n1 n2 -- n3)
        /// Determine if n1 is less than or equal to n2. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 2 3 &lt;= ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("<=")]
        public static void LessThanOrEqualTo(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item <= (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item <= (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// &gt; (n1 n2 -- n3)
        /// Determine if n1 is greater than n2. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 2 3 &gt; ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode(">")]
        public static void GreaterThan(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item > (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item > (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// &gt;= (n1 n2 -- n3)
        /// Determine if n1 is greater than or equal to n2. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 2 3 &gt;= ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode(">=")]
        public static void GreaterThanOrEqualTo(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item >= (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item >= (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// and (n1 n2 -- n3)
        /// Determine if n1 and n2 are both true. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1 1 and ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("and")]
        public static void LogicalAnd(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (((Item1.Type == MuftecType.Integer) || (Item1.Type == MuftecType.Float)) && 
                ((Item2.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Float)))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (bool)Item1.Item & (bool)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// or (n1 n2 -- n3)
        /// Determine if either n1 or n2 are true. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1 0 or ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("or")]
        public static void LogicalOr(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (((Item1.Type == MuftecType.Integer) || (Item1.Type == MuftecType.Float)) &&
                ((Item2.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Float)))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (bool)Item1.Item | (bool)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// xor (n1 n2 -- n3)
        /// Determine if either n1 or n2 are true, but not both. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1 1 xor ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("xor")]
        public static void LogicalXor(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (((Item1.Type == MuftecType.Integer) || (Item1.Type == MuftecType.Float)) &&
                ((Item2.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Float)))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (((bool)Item1.Item && !(bool)Item2.Item) || ((bool)Item2.Item && !(bool)Item1.Item));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// not (n1 -- n2)
        /// Return true if n1 is false, return false if n1 is true. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1 not ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("not")]
        public static void LogicalNot(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Integer) || (Item1.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = !(bool)Item1.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// int? (x -- n1)
        /// Return true if x is an integer. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// "Blah" int? ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("int?")]
        public static void IsInt(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            if (Item1.Type == MuftecType.Integer)
            {
                Result.Item = 1;
            }
            else
            {
                Result.Item = 0;
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// float? (x -- n1)
        /// Return true if x is a float. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1.23 float? ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("float?")]
        public static void IsFloat(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            if (Item1.Type == MuftecType.Float)
            {
                Result.Item = 1;
            }
            else
            {
                Result.Item = 0;
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// string? (x -- n1)
        /// Return true if x is a string. 0=false, 1=true.
        /// </summary>
        /// <example>
        /// 1.23 string? ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("string?")]
        public static void IsString(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            if (Item1.Type == MuftecType.String)
            {
                Result.Item = 1;
            }
            else
            {
                Result.Item = 0;
            }

            RuntimeStack.Push(Result);
        }
    }
}
