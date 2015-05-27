using System.Collections.Generic;
using System.Linq;

namespace Muftec.Lib
{
    public static class Shared
    {
        /// <summary>
        /// Pop the next item from the stack
        /// </summary>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
        /// <param name="itemTypes">The expected types of the next stack item</param>
        /// <returns>The next stack item</returns>
        public static MuftecStackItem Pop(this Stack<MuftecStackItem> runtimeStack, params MuftecType[] itemTypes)
        {
            if (runtimeStack.Count == 0)
            {
                throw new MuftecStackUnderflowException();
            }

            if ((itemTypes != null) && (itemTypes.Length > 0) && (!itemTypes.Contains(MuftecType.None)) && (!itemTypes.Contains(runtimeStack.Peek().Type)))
            {
                throw new MuftecInvalidStackItemTypeException(runtimeStack);
            }

            return runtimeStack.Pop();
        }

        /// <summary>
        /// Pop the next item from the stack and coerce to a string
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static string PopStringify(this Stack<MuftecStackItem> runtimeStack)
        {
            return Pop(runtimeStack).ToString();
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is a string
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static string PopStr(this Stack<MuftecStackItem> runtimeStack)
        {
            return (string)Pop(runtimeStack, MuftecType.String).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is an integer
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static int PopInt(this Stack<MuftecStackItem> runtimeStack)
        {
            return (int)Pop(runtimeStack, MuftecType.Integer).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is a float
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static double PopFloat(this Stack<MuftecStackItem> runtimeStack)
        {
            return (double)Pop(runtimeStack, MuftecType.Float).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is a number
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static MuftecStackItem PopNumber(this Stack<MuftecStackItem> runtimeStack)
        {
            return Pop(runtimeStack, MuftecType.Integer, MuftecType.Float);
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is an array
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static MuftecList PopArray(this Stack<MuftecStackItem> runtimeStack)
        {
            return (MuftecList)Pop(runtimeStack, MuftecType.List).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is an dictionary
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static MuftecDict PopDictionary(this Stack<MuftecStackItem> runtimeStack)
        {
            return (MuftecDict)Pop(runtimeStack, MuftecType.Dictionary).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is an array, then convert it to a dictionary
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static MuftecDict PopAsDictionary(this Stack<MuftecStackItem> runtimeStack)
        {
            var peek = runtimeStack.Peek();
            if (peek.Type == MuftecType.Dictionary)
                return runtimeStack.PopDictionary();

            return runtimeStack.PopArray().ToDict();
        }

        public static void Push(this Stack<MuftecStackItem> runtimeStack, IEnumerable<MuftecStackItem> value)
        {
            runtimeStack.Push(new MuftecList(value));
        }

        public static void Push(this Stack<MuftecStackItem> runtimeStack, IDictionary<MuftecStackItem, MuftecStackItem> value)
        {
            runtimeStack.Push(new MuftecDict(value));
        }
        
        /// <summary>
        /// Convert a boolean value into an integer
        /// </summary>
        /// <param name="value">Boolean value to convert</param>
        /// <returns>1 if true, 0 if false</returns>
        public static int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Returns true on debug, false on release
        /// </summary>
        /// <returns>True on debug, false on release</returns>
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}