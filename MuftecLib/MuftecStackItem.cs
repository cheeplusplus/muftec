using System;

namespace Muftec.Lib
{
    /// <summary>
    /// This structure holds an item in the stack, and its type.
    /// </summary>
    public class MuftecStackItem
    {
        public MuftecType Type { get; private set; }
        public object Item { get; private set; }
        public int LineNumber { get; private set; }

        private MuftecStackItem(object value, MuftecType type, int lineNumber = 0)
        {
            Type = type;
            Item = value;
            LineNumber = lineNumber;
        }

        public MuftecStackItem(int value, int lineNumber = 0) : this(value, MuftecType.Integer, lineNumber) { }

        public MuftecStackItem(bool value, int lineNumber = 0) : this(value ? 1 : 0, MuftecType.Integer, lineNumber) { }

        public MuftecStackItem(double value, int lineNumber = 0) : this(value, MuftecType.Float, lineNumber) { }

        public MuftecStackItem(string value, int lineNumber = 0) : this(value, MuftecType.String, lineNumber) { }

        internal MuftecStackItem(ConditionalContainer container, int lineNumber = 0) : this(container, MuftecType.Conditional, lineNumber) { }

        public MuftecStackItem(string value, MuftecAdvType type, int lineNumber = 0)
        {
            if (type == MuftecAdvType.OpCode)
            {
                Type = MuftecType.OpCode;
            }
            else if (type == MuftecAdvType.Variable)
            {
                Type = MuftecType.Variable;
            }
            else if (type == MuftecAdvType.Function)
            {
                Type = MuftecType.Function;
            }

            Item = value;
            LineNumber = lineNumber;
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as MuftecStackItem;
            if (tmp == null) return false;

            return ((Type == tmp.Type) && (Item == tmp.Item));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Item.ToString();
        }

        public bool AsBool()
        {
            if (Type == MuftecType.Integer)
            {
                return (int)Item == 1;
            }

            return false;
        }

        public double AsDouble()
        {
            if (Type == MuftecType.Integer)
            {
                return Convert.ToDouble((int)Item);
            }
            
            return (double)Item;
        }
    };
}