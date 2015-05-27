using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Muftec.Lib
{
    /// <summary>
    /// This structure holds an item in the stack, and its type.
    /// </summary>
    public struct MuftecStackItem : IEqualityComparer<MuftecStackItem>, IEquatable<MuftecStackItem>
    {
        private readonly MuftecType _type;
        private readonly object _item;
        private readonly int _lineNumber;

        public MuftecType Type
        {
            get { return _type; }
        }

        public object Item
        {
            get { return _item; }
        }

        public int LineNumber
        {
            get { return _lineNumber; }
        }

        private MuftecStackItem(object value, MuftecType type, int lineNumber = 0)
        {
            _type = type;
            _item = value;
            _lineNumber = lineNumber;
        }

        public MuftecStackItem(int value, int lineNumber = 0) : this(value, MuftecType.Integer, lineNumber) { }

        public static implicit operator MuftecStackItem(int value) { return new MuftecStackItem(value); }

        public MuftecStackItem(bool value, int lineNumber = 0) : this(value ? 1 : 0, MuftecType.Integer, lineNumber) { }

        public static implicit operator MuftecStackItem(bool value) { return new MuftecStackItem(value); }

        public MuftecStackItem(double value, int lineNumber = 0) : this(value, MuftecType.Float, lineNumber) { }

        public static implicit operator MuftecStackItem(double value) { return new MuftecStackItem(value); }

        public MuftecStackItem(string value, int lineNumber = 0) : this(value, MuftecType.String, lineNumber) { }

        public static implicit operator MuftecStackItem(string value) { return new MuftecStackItem(value); }
        
        public MuftecStackItem(IEnumerable<MuftecStackItem> list, int lineNumber = 0) : this(new MuftecList(list), MuftecType.List, lineNumber) { }

        public MuftecStackItem(MuftecList list, int lineNumber = 0) : this(list, MuftecType.List, lineNumber) { }

        public static implicit operator MuftecStackItem(MuftecList value) { return new MuftecStackItem(value); }

        public MuftecStackItem(IDictionary<MuftecStackItem, MuftecStackItem> dict, int lineNumber = 0) : this(new MuftecDict(dict), MuftecType.Dictionary, lineNumber) { }

        public MuftecStackItem(MuftecDict dict, int lineNumber = 0) : this(dict, MuftecType.Dictionary, lineNumber) { }

        public static implicit operator MuftecStackItem(MuftecDict value) { return new MuftecStackItem(value); }

        internal MuftecStackItem(ConditionalContainer container, int lineNumber = 0) : this(container, MuftecType.Conditional, lineNumber) { }

        public MuftecStackItem(string value, MuftecAdvType type, int lineNumber = 0)
        {
            if (type == MuftecAdvType.OpCode)
            {
                _type = MuftecType.OpCode;
            }
            else if (type == MuftecAdvType.Variable)
            {
                _type = MuftecType.Variable;
            }
            else if (type == MuftecAdvType.Function)
            {
                _type = MuftecType.Function;
            }
            else
            {
                throw new ArgumentException("Invalid advanced type.", "type");
            }

            _item = value;
            _lineNumber = lineNumber;
        }

        public static MuftecStackItem CreateArrayMarker(int lineNumber = 0)
        {
            return new MuftecStackItem(null, MuftecType.ArrayMarker, lineNumber);
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as MuftecStackItem?;
            if (tmp == null) return false;

            return Equals(tmp.Value);
        }

        public bool Equals(MuftecStackItem x, MuftecStackItem y)
        {
            return x.Equals(y);
        }

        public bool Equals(MuftecStackItem other)
        {
            if (Type != other.Type) return false;

            switch (Type)
            {
                case MuftecType.Integer:
                    return (int) Item == ((int) other.Item);
                case MuftecType.Float:
                    var f1 = (double) Item;
                    var f2 = (double) other.Item;

                    // Special cases since the math won't work
                    if ((double.IsPositiveInfinity(f1) && double.IsPositiveInfinity(f2)) ||
                        (double.IsNaN(f1) && double.IsNaN(f2)))
                        return true;

                    return Math.Abs(f1 - f2) < EPSILON;
                case MuftecType.String:
                case MuftecType.OpCode:
                case MuftecType.Variable:
                case MuftecType.Function:
                    return (string) Item == ((string) other.Item);
                case MuftecType.ArrayMarker:
                    return true;
                case MuftecType.List:
                    var list1 = (MuftecList) Item;
                    var list2 = (MuftecList) other.Item;
                    return list1.SequenceEqual(list2);
                case MuftecType.Dictionary:
                    var dict1 = (MuftecDict) Item;
                    var dict2 = (MuftecDict) other.Item;
                    return dict1.SequenceEqual(dict2);
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Item.GetHashCode();
        }
        
        public int GetHashCode(MuftecStackItem obj)
        {
            return obj.GetHashCode();
        }

        public override string ToString()
        {
            return Item.ToString();
        }

        public string ToDebugString()
        {
            if (Type == MuftecType.String)
            {
                return "\"" + Item + "\"";
            }

            return Item.ToString();
        }

        public bool AsBool()
        {
            if (Type == MuftecType.Integer)
            {
                return (int)Item == 1;
            }

            if (Type == MuftecType.Float)
            {
                return Math.Abs((double) Item - 1) < EPSILON;
            }

            return false;
        }

        public double AsDouble()
        {
            if (Type == MuftecType.Integer)
            {
                return Convert.ToDouble((int)Item);
            }

            if (Type == MuftecType.Float)
            {
                return (double) Item;
            }

            throw new MuftecInvalidConversionException(null, null);
        }

        public MuftecStackItem Clone()
        {
            switch (Type)
            {
                case MuftecType.List:
                    return new MuftecStackItem(((MuftecList)Item).Clone());
                case MuftecType.Dictionary:
                    return new MuftecStackItem(((MuftecDict)Item).Clone());
                default:
                    // Soft reference immutable types
                    return this;
            }
        }

        public const double EPSILON = 0.00000001;

        public static readonly MuftecStackItem Null = new MuftecStackItem(null, MuftecType.String);
    }

    /// <summary>
    /// List type.
    /// </summary>
    public class MuftecList : List<MuftecStackItem>
    {
        public MuftecList() { }
        public MuftecList(int capacity) : base(capacity) { }
        public MuftecList(IEnumerable<MuftecStackItem> list) : base(list) { }

        public MuftecDict ToDict()
        {
            return new MuftecDict(this.Select((s, idx) => new {s, idx}).ToDictionary(s => new MuftecStackItem(s.idx), s => s.s));
        }

        public override string ToString()
        {
            return "{" + String.Join(",", this.Select(e => e.ToDebugString())) + "}";
        }

        public MuftecList Clone()
        {
            var newList = this.Select(s => s.Clone()).ToList();
            return new MuftecList(newList);
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as List<MuftecStackItem>;
            if (tmp == null) return false;

            return base.Equals(tmp);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Dictionary type.
    /// </summary>
    public class MuftecDict : Dictionary<MuftecStackItem, MuftecStackItem>
    {
        public MuftecDict() { }
        public MuftecDict(int capacity) : base(capacity) { }
        public MuftecDict(IDictionary<MuftecStackItem, MuftecStackItem> dict) : base(dict) { }

        public MuftecList ToList()
        {
            return new MuftecList(this.Select(s => s.Value));
        }

        public override string ToString()
        {
            return "{" + String.Join(",", this.Select(e => e.Key.ToDebugString() + ":" + e.Value.ToDebugString())) + "}";
        }

        public MuftecDict Clone()
        {
            var newDict = this.ToDictionary(k => k.Key.Clone(), k => k.Value.Clone());
            return new MuftecDict(newDict);
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as Dictionary<MuftecStackItem, MuftecStackItem>;
            if (tmp == null) return false;

            return base.Equals(tmp);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}