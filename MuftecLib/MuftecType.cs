namespace Muftec.Lib
{
    /// <summary>
    /// The type of item in the stack.
    /// </summary>
    public enum MuftecType
    {
        /// <summary>
        /// Invalid state!
        /// </summary>
        None,

        /// <summary>
        /// Integer (ex. 24)
        /// </summary>
        Integer,

        /// <summary>
        /// Float (ex. 1.234)
        /// </summary>
        Float,

        /// <summary>
        /// String (ex. "Joy")
        /// </summary>
        String,

        /// <summary>
        /// Opcode (ex. concat)
        /// </summary>
        OpCode,

        /// <summary>
        /// Variable (ex. somevar)
        /// </summary>
        Variable,

        /// <summary>
        /// Function
        /// </summary>
        Function,

        /// <summary>
        /// Conditional
        /// </summary>
        Conditional
    }

    /// <summary>
    /// Type of non-string string item to add to the stack.
    /// </summary>
    public enum MuftecAdvType
    {
        /// <summary>
        /// Opcode (ex. concat)
        /// </summary>
        OpCode,

        /// <summary>
        /// Variable (ex. somevar)
        /// </summary>
        Variable,

        /// <summary>
        /// Function
        /// </summary>
        Function
    }
}