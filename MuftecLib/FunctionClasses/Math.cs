using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class Math : IOpCode
    {
        /// <summary>
        /// + (n1 n2 -- n3)
        /// Perform the addition operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 + ( returns ) 5
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("+")]
        public static void Add(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item + (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item + (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// - (n1 n2 -- n3)
        /// Perform the subtraction operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 5 2 - ( returns ) 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("-")]
        public static void Subtract(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item - (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item - (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// * (n1 n2 -- n3)
        /// Perform the multiplication operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 * ( returns ) 6
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("*")]
        public static void Multiply(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item * (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item * (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// / (n1 n2 -- n3)
        /// Perform the division operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 5 10 / ( returns ) 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("/")]
        public static void Divide(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item / (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item / (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// % (n1 n2 -- n3)
        /// Perform the modulus operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 % ( returns ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("%")]
        public static void Modulus(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)Item1.Item % (double)Item2.Item;
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)Item1.Item % (int)Item2.Item;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ^ (n1 n2 -- n3)
        /// Perform the modulus operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 4 5 ^ ( returns ) 1024
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("^")]
        public static void Exponent(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if ((Item1.Type == MuftecType.Float) || (Item2.Type == MuftecType.Float))
            {
                Result.Type = MuftecType.Float;
                Result.Item = System.Math.Pow((double)Item1.Item,(double)Item2.Item);
            }
            else if ((Item1.Type == MuftecType.Integer) || (Item2.Type == MuftecType.Integer))
            {
                Result.Type = MuftecType.Integer;
                Result.Item = System.Math.Pow((int)Item1.Item,(int)Item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ++ (n1 -- n2)
        /// Add one to the number on top of the stack.
        /// </summary>
        /// <example>
        /// 3 ++ ( returns ) 4
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("++")]
        public static void PlusPlus(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (Item1.Type == MuftecType.Float)
            {
                Result.Type = MuftecType.Float;
                Result.Item = ((double)Item1.Item)+1;
            }
            else if (Item1.Type == MuftecType.Integer)
            {
                Result.Type = MuftecType.Integer;
                Result.Item = ((int)Item1.Item)+1;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// -- (n1 -- n2)
        /// Subtract one from the number on top of the stack.
        /// </summary>
        /// <example>
        /// 3 -- ( returns ) 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("--")]
        public static void MinusMinus(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (Item1.Type == MuftecType.Float)
            {
                Result.Type = MuftecType.Float;
                Result.Item = ((double)Item1.Item)-1;
            }
            else if (Item1.Type == MuftecType.Integer)
            {
                Result.Type = MuftecType.Integer;
                Result.Item = ((int)Item1.Item)-1;
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// abs (n1 -- n2)
        /// Returns the absolute number of the number on top of the stack.
        /// </summary>
        /// <example>
        /// -3 abs ( returns ) -3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("abs")]
        public static void AbsoluteVal(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (Item1.Type == MuftecType.Float)
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)System.Math.Abs((double)Item1.Item);
            }
            else if (Item1.Type == MuftecType.Integer)
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)System.Math.Abs((int)Item1.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// sign (n1 -- n2)
        /// Given a number, return 1 if positive, 0 if 0, and -1 if negitive.
        /// </summary>
        /// <example>
        /// -3 sign ( returns ) -1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("sign")]
        public static void Sign(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Result = new MuftecStackItem();

            if (Item1.Type == MuftecType.Float)
            {
                Result.Type = MuftecType.Float;
                Result.Item = (double)System.Math.Sign((double)Item1.Item);
            }
            else if (Item1.Type == MuftecType.Integer)
            {
                Result.Type = MuftecType.Integer;
                Result.Item = (int)System.Math.Sign((int)Item1.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(ref RuntimeStack);
            }

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// floor (float1 -- float2)
        /// Round a float to the lowest integer, returned as a float.
        /// </summary>
        /// <example>
        /// 2.7 floor ( returns ) 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("floor")]
        public static void Floor(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            Result.Item = (double)System.Math.Floor((double)Item1.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// ceil (float1 -- float2)
        /// Round a float to the highest integer, returned as a float.
        /// </summary>
        /// <example>
        /// 2.2 floor ( returns ) 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("ceil")]
        public static void Ceiling(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            Result.Item = (double)System.Math.Ceiling((double)Item1.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// sqrt (float1 -- float2)
        /// Calculate the square root of a number, returned as a float.
        /// </summary>
        /// <example>
        /// 9 sqrt ( returns ) 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("sqrt")]
        public static void SquareRoot(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            Result.Item = (double)System.Math.Sqrt((double)Item1.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// round (float1 int1 -- float2)
        /// Round a number to a given precision.
        /// </summary>
        /// <example>
        /// 7.899 1 round ( returns ) 7.9
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("round")]
        public static void Round(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.Float);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Float;
            Result.Item = (double)System.Math.Round((double)Item1.Item,(int)Item2.Item);

            RuntimeStack.Push(Result);
        }
    }
}
