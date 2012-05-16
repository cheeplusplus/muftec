using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class StackOperations : IOpCode
    {
        /// <summary>
        /// depth ( -- str1)
        /// Returns the number of items currently on the stack.
        /// </summary>
        /// <example>
        /// 1 2 "c" depth ( returns ) 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("depth")]
        public static void StackDepth(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Result = new MuftecStackItem();
            Result.Type = MuftecType.Integer;
            Result.Item = RuntimeStack.Count;

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// dup ( x -- x x )
        /// Duplicates the item at the top of the stack.
        /// </summary>
        /// <example>
        /// 2 dup ( leaves ) 2 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("dup")]
        public static void StackItemDup(ref Stack<MuftecStackItem> RuntimeStack)
        {
            RuntimeStack.Push(RuntimeStack.Peek());
        }

        /// <summary>
        /// pop ( x..X -- )
        /// Pops the top of the stack into nothing.
        /// </summary>
        /// <example>
        /// 1 2 3 pop ( leaves ) 1 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("pop")]
        public static void StackItemPop(ref Stack<MuftecStackItem> RuntimeStack)
        {
            Shared.Pop(ref RuntimeStack);
        }

        /// <summary>
        /// popn ( x..X n1 -- )
        /// Pops the top n1 items out the stack.
        /// </summary>
        /// <example>
        /// 1 2 3 2 popn ( leaves ) 1
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("popn")]
        public static void StackItemPopN(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            for (int i = 0; i < (int)Item1.Item; i++)
            {
                Shared.Pop(ref RuntimeStack);
            }

            // Call TrimExcess in case we got rid of a lot of elements
            RuntimeStack.TrimExcess();
        }

        /// <summary>
        /// swap ( x y -- y x )
        /// Takes objects x and y on the stack and reverses their order.
        /// </summary>
        /// <example>
        /// 1 2 3 swap ( returns ) 1 3 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("swap")]
        public static void StackItemSwap(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack);
            RuntimeStack.Push(Item2);
            RuntimeStack.Push(Item1);
        }
    }
}
