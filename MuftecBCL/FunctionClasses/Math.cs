using System;
using System.Collections.Generic;
using MuftecLib;

namespace MuftecBCL.FunctionClasses
{
	public static class Math
	{
		/// <summary>
		/// + (n1 n2 -- n3)
		/// Perform the addition operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 2 3 + ( returns ) 5
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("+")]
		public static void Add(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() + item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item + (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// - (n1 n2 -- n3)
		/// Perform the subtraction operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 5 2 - ( returns ) 3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		/// <exception cref="MuftecInvalidStackItemTypeException">Raised when values other than a float or integer are used</exception>
		[OpCode("-")]
		public static void Subtract(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() - item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item - (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// * (n1 n2 -- n3)
		/// Perform the multiplication operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 2 3 * ( returns ) 6
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("*")]
		public static void Multiply(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() * item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item * (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// / (n1 n2 -- n3)
		/// Perform the division operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 5 10 / ( returns ) 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("/")]
		public static void Divide(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() / item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item / (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// % (n1 n2 -- n3)
		/// Perform the modulus operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 2 3 % ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("%")]
		public static void Modulus(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() % item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item % (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// ^ (n1 n2 -- float3)
		/// Perform the modulus operation on the first two numbers in the stack.
		/// </summary>
		/// <example>
		/// 4 5 ^ ( returns ) 1024.0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("^")]
		public static void Exponent(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (((item1.Type == MuftecType.Float) || (item1.Type == MuftecType.Integer)) &&
				((item2.Type == MuftecType.Float) || (item2.Type == MuftecType.Integer)))
			{
				result = new MuftecStackItem(System.Math.Pow(item1.AsDouble(), item2.AsDouble()));
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// ++ (n1 -- n2)
		/// Add one to the number on top of the stack.
		/// </summary>
		/// <example>
		/// 3 ++ ( returns ) 4
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("++")]
		public static void PlusPlus(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Float)
			{
				result = new MuftecStackItem((item1.AsDouble()) + 1);
			}
			else if (item1.Type == MuftecType.Integer)
			{
				result = new MuftecStackItem(((int)item1.Item) + 1);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// -- (n1 -- n2)
		/// Subtract one from the number on top of the stack.
		/// </summary>
		/// <example>
		/// 3 -- ( returns ) 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("--")]
		public static void MinusMinus(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Float)
			{
				result = new MuftecStackItem((item1.AsDouble()) - 1);
			}
			else if (item1.Type == MuftecType.Integer)
			{
				result = new MuftecStackItem(((int)item1.Item) - 1);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// abs (n1 -- n2)
		/// Returns the absolute number of the number on top of the stack.
		/// </summary>
		/// <example>
		/// -3 abs ( returns ) -3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("abs")]
		public static void AbsoluteVal(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Float)
			{
				result = new MuftecStackItem(System.Math.Abs(item1.AsDouble()));
			}
			else if (item1.Type == MuftecType.Integer)
			{
				result = new MuftecStackItem(System.Math.Abs((int)item1.Item));
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// sign (n1 -- n2)
		/// Given a number, return 1 if positive, 0 if 0, and -1 if negitive.
		/// </summary>
		/// <example>
		/// -3 sign ( returns ) -1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("sign")]
		public static void Sign(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Float)
			{
				result = new MuftecStackItem(System.Math.Sign(item1.AsDouble()));
			}
			else if (item1.Type == MuftecType.Integer)
			{
				result = new MuftecStackItem(System.Math.Sign((int)item1.Item));
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// floor (float1 -- float2)
		/// Round a float to the lowest integer, returned as a float.
		/// </summary>
		/// <example>
		/// 2.7 floor ( returns ) 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("floor")]
		public static void Floor(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack, MuftecType.Float);
			runtimeStack.Push(new MuftecStackItem(System.Math.Floor(item1.AsDouble())));
		}

		/// <summary>
		/// ceil (float1 -- float2)
		/// Round a float to the highest integer, returned as a float.
		/// </summary>
		/// <example>
		/// 2.2 floor ( returns ) 3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("ceil")]
		public static void Ceiling(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack, MuftecType.Float);
			runtimeStack.Push(new MuftecStackItem(System.Math.Ceiling(item1.AsDouble())));
		}

		/// <summary>
		/// sqrt (float1 -- float2)
		/// Calculate the square root of a number, returned as a float.
		/// </summary>
		/// <example>
		/// 9 sqrt ( returns ) 3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("sqrt")]
		public static void SquareRoot(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);

			if ((item1.Type == MuftecType.Float) || (item1.Type == MuftecType.Integer))
			{
				runtimeStack.Push(new MuftecStackItem(System.Math.Sqrt(item1.AsDouble())));
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		/// <summary>
		/// round (float1 int1 -- float2)
		/// Round a number to a given precision.
		/// </summary>
		/// <example>
		/// 7.899 1 round ( returns ) 7.9
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("round")]
		public static void Round(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack, MuftecType.Integer);
			var item1 = Shared.Pop(runtimeStack, MuftecType.Float);
			runtimeStack.Push(new MuftecStackItem(System.Math.Round(item1.AsDouble(), (int)item2.Item)));
		}
	}
}
