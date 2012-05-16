using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuftecLib;

namespace MuftecTest
{
    public static class Shared
    {
        public static void CompareStacks(Stack<MuftecStackItem> runtimeStack, Stack<MuftecStackItem> runtimeStackExpected)
        {
            var actualArr = runtimeStack.ToArray();
            var expectedArr = runtimeStackExpected.ToArray();
            Assert.AreEqual(expectedArr.Length, actualArr.Length);

            for (var i = 0; i < expectedArr.Length; i++)
            {
                Assert.AreEqual(expectedArr[i].Type, actualArr[i].Type);
                Assert.AreEqual(expectedArr[i].Item, actualArr[i].Item);
            }
        }
    }
}
