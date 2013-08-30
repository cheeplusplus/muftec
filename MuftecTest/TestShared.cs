using System.Collections.Generic;
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
                        var expectedStr = (string) expectedArr[i].Item;
                        var actualStr = (string) actualArr[i].Item;
                        Assert.AreEqual(expectedStr, actualStr);
                        break;
                    default:
                        Assert.AreEqual(expectedArr[i].Item, actualArr[i].Item);
                        break;
                }
            }
        }
    }
}
