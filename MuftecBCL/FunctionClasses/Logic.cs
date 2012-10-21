using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
	public class Logic : IMuftecGroup
	{
		/// <summary>
		/// = (n1 n2 -- n3)
		/// Determine if n1 is equal to n2. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 2 3 = ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("=")]
		public static void EqualTo(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(System.Math.Abs(item1.AsDouble() - item2.AsDouble()) < 0.00000001);
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item == (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// &lt; (n1 n2 -- n3)
		/// Determine if n1 is less than n2. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 2 3 &lt; ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("<")]
		public static void LessThan(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() < item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item < (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// &lt;= (n1 n2 -- n3)
		/// Determine if n1 is less than or equal to n2. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 2 3 &lt;= ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("<=")]
		public static void LessThanOrEqualTo(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() <= item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item <= (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// &gt; (n1 n2 -- n3)
		/// Determine if n1 is greater than n2. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 2 3 &gt; ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode(">")]
		public static void GreaterThan(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() > item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item > (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// &gt;= (n1 n2 -- n3)
		/// Determine if n1 is greater than or equal to n2. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 2 3 &gt;= ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode(">=")]
		public static void GreaterThanOrEqualTo(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(item1.AsDouble() >= item2.AsDouble());
			}
			else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
			{
				result = new MuftecStackItem((int)item1.Item >= (int)item2.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// and (n1 n2 -- n3)
		/// Determine if n1 and n2 are both true. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1 1 and ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("and")]
		public static void LogicalAnd(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (((item1.Type == MuftecType.Integer) || (item1.Type == MuftecType.Float)) && 
				((item2.Type == MuftecType.Integer) || (item2.Type == MuftecType.Float)))
			{
				result = new MuftecStackItem(item1.AsBool() && item2.AsBool());
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// or (n1 n2 -- n3)
		/// Determine if either n1 or n2 are true. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1 0 or ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("or")]
		public static void LogicalOr(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (((item1.Type == MuftecType.Integer) || (item1.Type == MuftecType.Float)) &&
				((item2.Type == MuftecType.Integer) || (item2.Type == MuftecType.Float)))
			{
				result = new MuftecStackItem(item1.AsBool() || item2.AsBool());
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// xor (n1 n2 -- n3)
		/// Determine if either n1 or n2 are true, but not both. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1 1 xor ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("xor")]
		public static void LogicalXor(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (((item1.Type == MuftecType.Integer) || (item1.Type == MuftecType.Float)) &&
				((item2.Type == MuftecType.Integer) || (item2.Type == MuftecType.Float)))
			{
				result = new MuftecStackItem((item1.AsBool() && !item2.AsBool()) || (item2.AsBool() && !item1.AsBool()));
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// not (n1 -- n2)
		/// Return true if n1 is false, return false if n1 is true. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1 not ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("not")]
		public static void LogicalNot(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if ((item1.Type == MuftecType.Integer) || (item1.Type == MuftecType.Float))
			{
				result = new MuftecStackItem(!item1.AsBool());
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// int? (x -- n1)
		/// Return true if x is an integer. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// "Blah" int? ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("int?")]
		public static void IsInt(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Integer)
			{
				result = new MuftecStackItem(1);
			}
			else
			{
				result = new MuftecStackItem(0);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// bool? (x -- n1)
		/// Return true if x is a boolean. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// "Blah" bool? ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("bool?")]
		public static void IsBool(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			MuftecStackItem result;

			if (item1.Type == MuftecType.Integer)
			{
			    var number = (int) item1.Item;

                if ((number == 0) || (number == 1))
				{
					result = new MuftecStackItem(1);
				}
				else
				{
					result = new MuftecStackItem(0);
				}
			}
			else
			{
				result = new MuftecStackItem(0);
			}

			runtimeStack.Push(result);
		}

		/// <summary>
		/// float? (x -- n1)
		/// Return true if x is a float. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1.23 float? ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("float?")]
		public static void IsFloat(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);

			runtimeStack.Push((item1.Type == MuftecType.Float) ? new MuftecStackItem(1) : new MuftecStackItem(0));
		}

		/// <summary>
		/// string? (x -- n1)
		/// Return true if x is a string. 0=false, 1=true.
		/// </summary>
		/// <example>
		/// 1.23 string? ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("string?")]
		public static void IsString(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);

			runtimeStack.Push((item1.Type == MuftecType.String) ? new MuftecStackItem(1) : new MuftecStackItem(0));
		}
	}
}
