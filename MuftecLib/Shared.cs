using System.Collections.Generic;

namespace Muftec.Lib
{
    public static class Shared
    {
        /// <summary>
        /// Pop the next item from the stack
        /// </summary>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
        /// <returns>The next stack item</returns>
        public static MuftecStackItem Pop(Stack<MuftecStackItem> runtimeStack)
        {
            if (runtimeStack.Count == 0)
            {
                throw new MuftecStackUnderflowException();
            }
            
            return runtimeStack.Pop();
        }

        /// <summary>
        /// Pop the next item from the stack and check its type
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <param name="itemType">The expected type of the next stack item</param>
        /// <returns>The next stack item</returns>
        public static MuftecStackItem Pop(Stack<MuftecStackItem> runtimeStack, MuftecType itemType)
        {
            if (runtimeStack.Peek().Type != itemType)
            {
                throw new MuftecInvalidStackItemTypeException(runtimeStack);
            }
            
            return Pop(runtimeStack);
        }

        /// <summary>
        /// Pop the next item from the stack and coerce to a string
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static string PopStringify(Stack<MuftecStackItem> runtimeStack)
        {
            return Pop(runtimeStack).ToString();
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is a string
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static string PopStr(Stack<MuftecStackItem> runtimeStack)
        {
            return (string)Pop(runtimeStack, MuftecType.String).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is an integer
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static int PopInt(Stack<MuftecStackItem> runtimeStack)
        {
            return (int)Pop(runtimeStack, MuftecType.Integer).Item;
        }

        /// <summary>
        /// Pop the next item from the stack and ensure it is a float
        /// </summary>
        /// <param name="runtimeStack">The current execution stack</param>
        /// <returns>The next stack item</returns>
        public static double PopFloat(Stack<MuftecStackItem> runtimeStack)
        {
            return (double)Pop(runtimeStack, MuftecType.Float).Item;
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