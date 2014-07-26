using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;

namespace Muftec.Test
{
    public static class TestShared
    {
        public static void CompareStacks(Stack<MuftecStackItem> runtimeStack, Stack<MuftecStackItem> runtimeStackExpected)
        {
            var actualArr = runtimeStack.ToArray();
            var expectedArr = runtimeStackExpected.ToArray();
            
            CompareArrays(actualArr, expectedArr);
        }

        private static void CompareArrays(MuftecStackItem[] actualArr, MuftecStackItem[] expectedArr)
        {
            Assert.AreEqual(expectedArr.Length, actualArr.Length);
            
            for (var i = 0; i < expectedArr.Length; i++)
            {
                Assert.AreEqual(expectedArr[i].Type, actualArr[i].Type);

                // Handle specific AreEqual cases
                switch (expectedArr[i].Type)
                {
                    case MuftecType.Float:
                        var expectedFloat = expectedArr[i].AsDouble();
                        var actualFloat = actualArr[i].AsDouble();
                        Assert.AreEqual(expectedFloat, actualFloat, 0.00000001); // 8 digits of precision
                        break;
                    case MuftecType.String:
                        var expectedStr = (string)expectedArr[i].Item;
                        var actualStr = (string)actualArr[i].Item;
                        Assert.AreEqual(expectedStr, actualStr);
                        break;
                    case MuftecType.List:
                        var expectedList = (MuftecList) expectedArr[i].Item;
                        var actualList = (MuftecList) actualArr[i].Item;
                        Assert.IsTrue(actualList.SequenceEqual(expectedList));
                        break;
                    case MuftecType.Dictionary:
                        var expectedArr3 = MashDict((MuftecDict) expectedArr[i].Item);
                        var actualArr3 = MashDict((MuftecDict) expectedArr[i].Item);
                        CompareArrays(actualArr3, expectedArr3);
                        break;
                    default:
                        Assert.AreEqual(expectedArr[i].Item, actualArr[i].Item);
                        break;
                }
            }

            // Test against expected comperator last since it's useless for test debugging
            Assert.IsTrue(expectedArr.SequenceEqual(actualArr));
        }

        private static MuftecStackItem[] MashDict(MuftecDict dictionary)
        {
            var items = new List<MuftecStackItem>(dictionary.Count * 2);

            foreach (var item in dictionary)
            {
                items.Add(item.Key);
                items.Add(item.Value);
            }

            return items.ToArray();
        }
    }
}
