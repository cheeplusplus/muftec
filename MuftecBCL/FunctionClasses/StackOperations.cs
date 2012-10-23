using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class StackOperations
	{
		/// <summary>
		/// depth ( -- str1)
		/// Returns the number of items currently on the stack.
		/// </summary>
		/// <example>
		/// 1 2 "c" depth ( returns ) 3
		/// </example>
		/// <param name="data">Opcode reference data.</param>
		[OpCode("depth")]
		public static void StackDepth(OpCodeData data)
		{
			data.RuntimeStack.Push(new MuftecStackItem(data.RuntimeStack.Count));
		}

		/// <summary>
		/// dup ( x -- x x )
		/// Duplicates the item at the top of the stack.
		/// </summary>
		/// <example>
		/// 2 dup ( leaves ) 2 2
		/// </example>
		/// <param name="data">Opcode reference data.</param>
		[OpCode("dup")]
		public static void StackItemDup(OpCodeData data)
		{
			data.RuntimeStack.Push(data.RuntimeStack.Peek());
		}

		/// <summary>
		/// pop ( x..X -- )
		/// Pops the top of the stack into nothing.
		/// </summary>
		/// <example>
		/// 1 2 3 pop ( leaves ) 1 2
		/// </example>
		/// <param name="data">Opcode reference data.</param>
		[OpCode("pop")]
		public static void StackItemPop(OpCodeData data)
		{
			Shared.Pop(data.RuntimeStack);
		}

		/// <summary>
		/// popn ( x..X n1 -- )
		/// Pops the top n1 items out the stack.
		/// </summary>
		/// <example>
		/// 1 2 3 2 popn ( leaves ) 1
		/// </example>
		/// <param name="data">Opcode reference data.</param>
		[OpCode("popn")]
		public static void StackItemPopN(OpCodeData data)
		{
			var item1 = Shared.Pop(data.RuntimeStack);
			for (var i = 0; i < (int)item1.Item; i++)
			{
				Shared.Pop(data.RuntimeStack);
			}

			// Call TrimExcess in case we got rid of a lot of elements
			data.RuntimeStack.TrimExcess();
		}

		/// <summary>
		/// swap ( x y -- y x )
		/// Takes objects x and y on the stack and reverses their order.
		/// </summary>
		/// <example>
		/// 1 2 3 swap ( returns ) 1 3 2
		/// </example>
		/// <param name="data">Opcode reference data.</param>
		[OpCode("swap")]
		public static void StackItemSwap(OpCodeData data)
		{
			var item2 = Shared.Pop(data.RuntimeStack);
			var item1 = Shared.Pop(data.RuntimeStack);
			data.RuntimeStack.Push(item2);
			data.RuntimeStack.Push(item1);
		}
	}
}
