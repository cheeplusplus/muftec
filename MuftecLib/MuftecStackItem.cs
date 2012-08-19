using System;

namespace MuftecLib
{
    /// <summary>
    /// This structure holds an item in the stack, and its type.
    /// </summary>
    public class MuftecStackItem
    {
        public MuftecType Type { get; private set; }
        public object Item { get; private set; }

        public MuftecStackItem(int value)
        {
            Type = MuftecType.Integer;
            Item = value;
        }

        public MuftecStackItem(bool value)
        {
            Type = MuftecType.Integer;
            Item = value ? 1 : 0;
        }

        public MuftecStackItem(double value)
        {
            Type = MuftecType.Float;
            Item = value;
        }

        public MuftecStackItem(string value)
        {
            Type = MuftecType.String;
            Item = value;
        }

        public MuftecStackItem(string value, MuftecAdvType type)
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