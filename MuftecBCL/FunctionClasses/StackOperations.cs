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
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("depth")]
		public static void StackDepth(Stack<MuftecStackItem> runtimeStack)
		{
			runtimeStack.Push(new MuftecStackItem(runtimeStack.Count));
		}

		/// <summary>
		/// dup ( x -- x x )
		/// Duplicates the item at the top of the stack.
		/// </summary>
		/// <example>
		/// 2 dup ( leaves ) 2 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("dup")]
		public static void StackItemDup(Stack<MuftecStackItem> runtimeStack)
		{
			runtimeStack.Push(runtimeStack.Peek());
		}

		/// <summary>
		/// pop ( x..X -- )
		/// Pops the top of the stack into nothing.
		/// </summary>
		/// <example>
		/// 1 2 3 pop ( leaves ) 1 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("pop")]
		public static void StackItemPop(Stack<MuftecStackItem> runtimeStack)
		{
			Shared.Pop(runtimeStack);
		}

		/// <summary>
		/// popn ( x..X n1 -- )
		/// Pops the top n1 items out the stack.
		/// </summary>
		/// <example>
		/// 1 2 3 2 popn ( leaves ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("popn")]
		public static void StackItemPopN(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			for (var i = 0; i < (int)item1.Item; i++)
			{
				Shared.Pop(runtimeStack);
			}

			// Call TrimExcess in case we got rid of a lot of elements
			runtimeStack.TrimExcess();
		}

		/// <summary>
		/// swap ( x y -- y x )
		/// Takes objects x and y on the stack and reverses their order.
		/// </summary>
		/// <example>
		/// 1 2 3 swap ( returns ) 1 3 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("swap")]
		public static void StackItemSwap(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.Pop(runtimeStack);
			var item1 = Shared.Pop(runtimeStack);
			runtimeStack.Push(item2);
			runtimeStack.Push(item1);
		}
	}
}
