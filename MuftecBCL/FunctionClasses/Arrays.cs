using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Arrays
    {
        /* Array Manipulation Operators

        array_appenditem          array_compare             array_count
        array_cut                 array_delitem             array_delrange
        array_diff                array_excludeval          array_explode
        array_extract             array_findval             array_first
        array_getitem             array_getrange            array_insertitem
        array_insertrange         array_interpret           array_intersect
        array_join                array_keys                array_last
        array_make                array_make_dict           array_matchkey
        array_matchval            array_ndiff               array_nested_del
        array_nested_get          array_nested_set          array_next
        array_nintersect          array_notify              array_nunion
        array_prev                array_reverse             array_setitem
        array_setrange            array_sort                array_sort_indexed
        array_union               array_vals                }cat
        }dict                     }join                     }list
        }tell     */

        [OpCode("{")]
        public static void ArrayStart(OpCodeData data)
        {
            data.RuntimeStack.Push(MuftecStackItem.CreateArrayMarker());
        }

        [OpCode("}")]
        public static void ArrayEnd(OpCodeData data)
        {
            var tempStack = new Stack<MuftecStackItem>();
            MuftecStackItem item;

            do
            {
                item = data.RuntimeStack.Pop();
                if (item.Type != MuftecType.ArrayMarker)
                {
                    tempStack.Push(item);
                }
                else
                {
                    break;
                }
                
            } while (item.Type != MuftecType.ArrayMarker);

            foreach (var stackItem in tempStack)
            {
                data.RuntimeStack.Push(stackItem);
            }

            data.RuntimeStack.Push(tempStack.Count);
        }

        [OpCode("array_appenditem")]
        public static void ArrayAppendItem(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();
            var item = data.RuntimeStack.Pop();
            array.Add(item);
            data.RuntimeStack.Push(array);
        }

        [OpCode("array_compare")]
        public static void ArrayCompare(OpCodeData data)
        {
            var array2 = data.RuntimeStack.PopArray();
            var array1 = data.RuntimeStack.PopArray();
            
            data.RuntimeStack.Push(array1.SequenceEqual(array2));
        }

        [OpCode("array_count")]
        public static void ArrayCount(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();

            data.RuntimeStack.Push(array.Count);
        }

        [OpCode("array_cut")]
        public static void ArrayCut(OpCodeData data)
        {
            var index = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.Pop(MuftecType.List, MuftecType.Dictionary);

            if (array.Type == MuftecType.List)
            {
                var list = (MuftecList)array.Item;
                data.RuntimeStack.Push(list.Take(index).ToList());
                data.RuntimeStack.Push(list.Skip(index).ToList());
            }
            else if (array.Type == MuftecType.Dictionary)
            {
                var list = (MuftecDict)array.Item;
                data.RuntimeStack.Push(list.Take(index).ToDictionary(p => p.Key, p => p.Value));
                data.RuntimeStack.Push(list.Skip(index).ToDictionary(p => p.Key, p => p.Value));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }
        
        [OpCode("array_delitem")]
        public static void ArrayDeleteItem(OpCodeData data)
        {
            var index = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.PopArray();
            
            array.RemoveAt(index);
            data.RuntimeStack.Push(array);
        }

        [OpCode("array_delrange")]
        public static void ArrayDeleteRange(OpCodeData data)
        {
            var index2 = data.RuntimeStack.PopInt();
            var index1 = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.PopArray().ToList();
            
            array.RemoveRange(index1, index2 - index1 + 1);
            data.RuntimeStack.Push(array);
        }

        [OpCode("array_diff")]
        public static void ArrayDiff(OpCodeData data)
        {
            var array2 = data.RuntimeStack.PopArray();
            var array1 = data.RuntimeStack.PopArray();

            data.RuntimeStack.Push(array2.Except(array1).ToList());
        }

        [OpCode("array_excludeval")]
        public static void ArrayExcludeValue(OpCodeData data)
        {
            var item = data.RuntimeStack.Pop();
            var array = data.RuntimeStack.PopArray();

            data.RuntimeStack.Push(array.Where(w => !w.Equals(item)).ToList());
        }

        [OpCode("array_explode")]
        public static void ArrayExplode(OpCodeData data)
        {
            var dict = data.RuntimeStack.PopAsDictionary();

            foreach (var kvp in dict)
            {
                data.RuntimeStack.Push(kvp.Key);
                data.RuntimeStack.Push(kvp.Value);
            }

            data.RuntimeStack.Push(dict.Count);
        }

        [OpCode("array_extract")]
        public static void ArrayExtract(OpCodeData data)
        {
            var indexArray = data.RuntimeStack.PopArray();
            var valueArray = data.RuntimeStack.PopDictionary();

            var outputDict = valueArray.Where(w => indexArray.Contains(w.Key)).ToDictionary(d => d.Key, d => d.Value);
            data.RuntimeStack.Push(outputDict);
        }

        [OpCode("array_findval")]
        public static void ArrayFindVal(OpCodeData data)
        {
            var item = data.RuntimeStack.Pop();
            var list = data.RuntimeStack.PopArray();
            
            var matches = list.Select((s, idx) => new {s, idx}).Where(w => w.s.Equals(item)).Select(s => new MuftecStackItem(s.idx));
            data.RuntimeStack.Push(matches);
        }

        [OpCode("array_first")]
        public static void ArrayFirst(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();

            if (array.Count == 0)
            {
                data.RuntimeStack.Push(false);
            }
            else
            {
                data.RuntimeStack.Push(array.First());
                data.RuntimeStack.Push(true);
            }
        }

        [OpCode("array_getitem")]
        public static void ArrayGetItem(OpCodeData data)
        {
            var index = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.PopArray();

            data.RuntimeStack.Push(array[index]);
        }

        [OpCode("array_getrange")]
        public static void ArrayGetRange(OpCodeData data)
        {
            var index2 = data.RuntimeStack.PopInt();
            var index1 = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.PopArray();

            data.RuntimeStack.Push(array.Skip(index1).Take(index2 - index1).ToList());
        }

        [OpCode("array_insertitem")]
        public static void ArrayInsertItem(OpCodeData data)
        {
            var index = data.RuntimeStack.PopInt();
            var array = data.RuntimeStack.PopArray();
            var item = data.RuntimeStack.Pop();

            array.Insert(index, item);
            data.RuntimeStack.Push(array);
        }

        [OpCode("array_insertrange")]
        public static void ArrayInsertRange(OpCodeData data)
        {
            var array2 = data.RuntimeStack.PopArray();
            var index = data.RuntimeStack.PopInt();
            var array1 = data.RuntimeStack.PopArray();

            array1.InsertRange(index, array2);
            data.RuntimeStack.Push(array1);
        }

        [OpCode("array_join")]
        public static void ArrayJoin(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();
            var delimiter = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(String.Join(delimiter, array));
        }

        [OpCode("array_keys")]
        public static void ArrayKeys(OpCodeData data)
        {
            var array = data.RuntimeStack.PopDictionary();

            foreach (var item in array.Keys)
            {
                data.RuntimeStack.Push(item);
            }
        }

        [OpCode("array_last")]
        public static void ArrayLast(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();

            if (array.Count > 0)
            {
                data.RuntimeStack.Push(array.Last());
                data.RuntimeStack.Push(true);
            }
            else
            {
                data.RuntimeStack.Push(false);
            }
        }

        [OpCode("array_make")]
        public static void ArrayMake(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();

            var array = new MuftecList(count);
            for (var i = 0; i < count; i++)
            {
                array.Add(data.RuntimeStack.Pop());
            }

            data.RuntimeStack.Push(array);
        }

        [OpCode("array_make_dict")]
        public static void ArrayMakeDict(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();

            var dict = new MuftecDict(count);
            for (var i = 0; i < count; i++)
            {
                var key = data.RuntimeStack.Pop();
                var val = data.RuntimeStack.Pop();
                dict.Add(key, val);
            }

            data.RuntimeStack.Push(dict);
        }

        [OpCode("array_matchkey")]
        public static void ArrayMatchKey(OpCodeData data)
        {
            var pattern = data.RuntimeStack.PopStr();
            var array = data.RuntimeStack.Pop();

            MuftecDict origDict;

            if (array.Type == MuftecType.List)
            {
                origDict = ((MuftecList) array.Item).ToDict();
            }
            else if (array.Type == MuftecType.Dictionary)
            {
                origDict = ((MuftecDict) array.Item); 
            }
            else
            {
                throw new MuftecInvalidOpcodeException(data.RuntimeStack);
            }

            var newDict = new MuftecDict();

            foreach (var item in origDict)
            {
                if (SharedUtil.smatch(item.Key.ToString(), pattern))
                {
                    newDict.Add(item.Key, item.Value);
                }
            }

            data.RuntimeStack.Push(newDict);
        }

        [OpCode("array_matchval")]
        public static void ArrayMatchVal(OpCodeData data)
        {
            var pattern = data.RuntimeStack.PopStr();
            var array = data.RuntimeStack.Pop(MuftecType.List, MuftecType.Dictionary);

            MuftecDict origDict;

            if (array.Type == MuftecType.List)
            {
                origDict = ((MuftecList)array.Item).ToDict();
            }
            else if (array.Type == MuftecType.Dictionary)
            {
                origDict = ((MuftecDict)array.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            var newDict = new MuftecDict();

            foreach (var item in origDict)
            {
                if (SharedUtil.smatch(item.Value.ToString(), pattern))
                {
                    newDict.Add(item.Key, item.Value);
                }
            }

            data.RuntimeStack.Push(newDict);
        }

        [OpCode("array_ndiff")]
        public static void ArrayNDiff(OpCodeData data)
        {
            var count = data.RuntimeStack.PopInt();
            var first = data.RuntimeStack.PopArray();
            count--;

            IEnumerable<MuftecStackItem> result = first;

            for (var i = 0; i < count; i++)
            {
                var array = data.RuntimeStack.PopArray();
                result = result.Except(array);
            }

            data.RuntimeStack.Push(new MuftecList(result));
        }

        [OpCode("array_nested_del")]
        public static void ArrayNestedDel(OpCodeData data)
        {
            var indexes = data.RuntimeStack.PopArray();
            var item = data.RuntimeStack.Pop(MuftecType.List, MuftecType.Dictionary);

            if (indexes.Count < 1)
            {
                data.RuntimeStack.Push(item);
                return;
            }

            if (item.Type == MuftecType.List)
            {
                var array = ((MuftecList) item.Item);
                var indr = indexes.Where(s => s.Type == MuftecType.Integer).Select(s => (int)s.Item).OrderByDescending(s => s);

                foreach (var index in indr)
                {
                    array.RemoveAt(index);
                }

                data.RuntimeStack.Push(array);
            }
            else if (item.Type == MuftecType.Dictionary)
            {
                var dict = ((MuftecDict) item.Item);
                
                foreach (var index in indexes)
                {
                    dict.Remove(index);
                }

                data.RuntimeStack.Push(dict);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        [OpCode("array_nested_get")]
        public static void ArrayNestedGet(OpCodeData data)
        {
            var indexes = data.RuntimeStack.PopArray();
            var item = data.RuntimeStack.Pop(MuftecType.List, MuftecType.Dictionary);

            if (indexes.Count < 1)
            {
                data.RuntimeStack.Push(item);
                return;
            }

            if (item.Type == MuftecType.List)
            {
                var array = ((MuftecList)item.Item);
                var indr = indexes.Where(s => s.Type == MuftecType.Integer).Select(s => (int)s.Item).OrderByDescending(s => s);

                foreach (var index in indr)
                {
                    array.RemoveAt(index);
                }

                data.RuntimeStack.Push(array);
            }
            else if (item.Type == MuftecType.Dictionary)
            {
                var dict = ((MuftecDict)item.Item);

                foreach (var index in indexes)
                {
                    dict.Remove(index);
                }

                data.RuntimeStack.Push(dict);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        /// <summary>
        /// array_print (a1 a2 -- )
        /// Print an array of values to the console.
        /// </summary>
        /// <example>
        /// { "Hello" "world!" }
        /// </example>
        /// <param name="data"></param>
        [OpCode("array_print")]
        public static void ArrayPrint(OpCodeData data)
        {
            var array = data.RuntimeStack.PopArray();
            foreach (var str in array)
            {
                Console.WriteLine(str);
            }
        }
    }
}
