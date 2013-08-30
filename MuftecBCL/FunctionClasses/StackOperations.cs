using System.Collections.Generic;
using System.Linq;
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
        /// dupn ( ?n..?1 i -- ?n..?1 ?n..?1 )
        /// Duplicates the top i stack items.
        /// </summary>
        /// <example>
        /// 4 5 6 2 dupn ( leaves ) 4 5 6 5 6
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("dupn")]
        public static void StackItemDupN(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();
            if (count == 0) return;
            if (count < 0)
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);

            var topItems = data.RuntimeStack.Take(count).Reverse().ToList();
            foreach (var item in topItems)
            {
                data.RuntimeStack.Push(item);
            }
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

        /// <summary>
        /// over ( x y -- x y x )
        /// Duplicates the second-to-top thing on the stack. This is the same as 2 pick.
        /// </summary>
        /// <example>
        /// 1 2 over ( returns ) 1 2 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("over")]
        public static void StackItemOver(OpCodeData data)
        {
            data.RuntimeStack.Push(new MuftecStackItem(2));
            StackItemPick(data);
        }

        /// <summary>
        /// rot ( x y z -- y z x )
        /// Rotates the top three things on the stack. This is equivalent to 3 rotate.
        /// </summary>
        /// <example>
        /// 1 2 3 rot ( returns ) 2 3 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("rot")]
        public static void StackItemRot(OpCodeData data)
        {
            data.RuntimeStack.Push(new MuftecStackItem(3));
            StackItemRotate(data);
        }

        /// <summary>
        /// rotate ( ni ... n1 i -- n(i-1) ... n1 ni )
        /// Rotates the top i things on the stack. Using a negative rotational value rotates backwards.
        /// </summary>
        /// <example>
        /// 1 2 3 4 4 rotate ( returns ) 2 3 4 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("rotate")]
        public static void StackItemRotate(OpCodeData data)
        {
            var position = data.RuntimeStack.PopInt();
            if (position == 0) return; // nop

            var popped = new List<MuftecStackItem>();

            // Get all items in stack
            for (var i = 0; i < position; i++)
            {
                var val = data.RuntimeStack.Pop();
                popped.Add(val);
            }

            // Re-add in original order
            var remaining = popped.Take(popped.Count - 1).Reverse();

            foreach (var item in remaining)
            {
                data.RuntimeStack.Push(item);
            }

            // Add rotated item last
            data.RuntimeStack.Push(popped.Last());
        }

        /// <summary>
        /// pick ( ni ... n1 i -- ni ... n1 ni )
        /// Takes the i'th thing from the top of the stack and pushes it on the top.
        /// 1 pick is equivalent to dup, and 2 pick is equivalent to over.
        /// </summary>
        /// <example>
        /// 1 2 3 3 pick ( returns ) 1 2 3 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("pick")]
        public static void StackItemPick(OpCodeData data)
        {
            var position = data.RuntimeStack.PopInt();
            if (position == 0) return;
            if (position < 0)
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);

            var item = data.RuntimeStack.Skip(position - 1).Take(1).Single();
            data.RuntimeStack.Push(item);
        }

        /// <summary>
        /// put ( nx...n1 ni i -- nx...ni...n1 )
        /// Replaces the i'th item from the top of the stack with the value of ni.
        /// The command sequence '1 put' is equivalent to 'swap pop'.
        /// </summary>
        /// <example>
        /// 1 2 3 2 put ( returns ) 1 3 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("put")]
        public static void StackItemPut(OpCodeData data)
        {
            var position = data.RuntimeStack.PopInt();
            if (position <= 0)
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);

            var putItem = Shared.Pop(data.RuntimeStack);

            // Get all items in stack
            var popped = new List<MuftecStackItem>();
            for (var i = 0; i < position - 1; i++)
            {
                var poppedItem = data.RuntimeStack.Pop();
                popped.Add(poppedItem);
            }

            // Remove last item
            data.RuntimeStack.Pop();

            // Put moved item in its place
            data.RuntimeStack.Push(putItem);

            // Re-add rest in original order
            popped.Reverse();
            foreach (var item in popped)
            {
                data.RuntimeStack.Push(item);
            }
        }

        /// <summary>
        /// reverse ( ?n..?1 i -- ?1..?n )
        /// Reverses the order of the top i items on the stack.
        /// </summary>
        /// <example>
        /// 1 2 3 4 3 reverse ( returns ) 1 4 3 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("reverse")]
        public static void StackItemReverse(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();
            if (count == 0) return;
            if (count < 0)
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);

            // Take n items
            var popped = new List<MuftecStackItem>();

            for (var i = 0; i < count; i++)
            {
                var item = data.RuntimeStack.Pop();
                popped.Add(item);
            }

            // Push in reverse order
            foreach (var item in popped)
            {
                data.RuntimeStack.Push(item);
            }
        }

        /// <summary>
        /// lreverse ( ?n..?1 i -- ?1..?n i )
        /// Reverses the order of the top i stack items, leaving i.
        /// </summary>
        /// <example>
        /// 1 2 3 4 3 reverse ( returns ) 1 4 3 2 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("lreverse")]
        public static void StackItemLReverse(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();
            if (count == 0) return;
            if (count < 0)
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);

            // Take n items
            var popped = new List<MuftecStackItem>();

            for (var i = 0; i < count; i++)
            {
                var item = data.RuntimeStack.Pop();
                popped.Add(item);
            }

            // Push in reverse order
            foreach (var item in popped)
            {
                data.RuntimeStack.Push(item);
            }

            // Re-add count
            data.RuntimeStack.Push(new MuftecStackItem(count));
        }
    }
}
