using System.Collections.Generic;
using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;

namespace Muftec.Test
{
    
    
    /// <summary>
    ///This is a test class for ArrayTest and is intended
    ///to contain all ArrayTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ArraysTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for ArrayStart
        ///</summary>
        [TestMethod]
        public void ArrayStartTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Arrays.ArrayStart(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(MuftecStackItem.CreateArrayMarker());

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
        
        /// <summary>
        ///A test for ArrayEnd
        ///</summary>
        [TestMethod]
        public void ArrayEndTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Arrays.ArrayStart(data);
            Arrays.ArrayEnd(data);
            Arrays.ArrayStart(data);
            runtimeStack.Push(50);
            Arrays.ArrayEnd(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(0);
            runtimeStackExpected.Push(50);
            runtimeStackExpected.Push(1);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayAppendItem
        ///</summary>
        [TestMethod]
        public void ArrayAppendItemTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(6);
            Arrays.ArrayStart(data);
            runtimeStack.Push(5);
            Arrays.ArrayEnd(data);
            Arrays.ArrayMake(data);
            Arrays.ArrayAppendItem(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 5, 6 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayCompare
        ///</summary>
        [TestMethod]
        public void ArrayCompareTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            Arrays.ArrayCompare(data);
            runtimeStack.Push(new MuftecList { 5, "test" });
            runtimeStack.Push(new MuftecList { 3 });
            Arrays.ArrayCompare(data);
            runtimeStack.Push(new MuftecList { 3.3 });
            runtimeStack.Push(new MuftecList { 3.30003 });
            Arrays.ArrayCompare(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(true);
            runtimeStackExpected.Push(false);
            runtimeStackExpected.Push(false);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayCount
        ///</summary>
        [TestMethod]
        public void ArrayCountTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            Arrays.ArrayCount(data);
            runtimeStack.Push(new MuftecList());
            Arrays.ArrayCount(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3);
            runtimeStackExpected.Push(0);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayCut
        ///</summary>
        [TestMethod]
        public void ArrayCutTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(2);
            Arrays.ArrayCut(data);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(0);
            Arrays.ArrayCut(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 5, "test" });
            runtimeStackExpected.Push(new MuftecList { 0.3 });
            runtimeStackExpected.Push(new MuftecList());
            runtimeStackExpected.Push(new MuftecList { 5, "test", 0.3 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayDeleteItem
        ///</summary>
        [TestMethod]
        public void ArrayDeleteItemTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(1);
            Arrays.ArrayDeleteItem(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 5, 0.3 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayDeleteRange
        ///</summary>
        [TestMethod]
        public void ArrayDeleteRangeTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(1);
            runtimeStack.Push(2);
            Arrays.ArrayDeleteRange(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 5 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayDiff
        ///</summary>
        [TestMethod]
        public void ArrayDiffTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push(new MuftecList { "test", 0.3, 2 });
            Arrays.ArrayDiff(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 2 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayExcludeValue
        ///</summary>
        [TestMethod]
        public void ArrayExcludeValueTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test", 0.3 });
            runtimeStack.Push("test");
            Arrays.ArrayExcludeValue(data);
            runtimeStack.Push(new MuftecList { 1, 2 });
            runtimeStack.Push("test");
            Arrays.ArrayExcludeValue(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 5, 0.3 });
            runtimeStackExpected.Push(new MuftecList { 1, 2 });

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayExplode
        ///</summary>
        [TestMethod]
        public void ArrayExplodeTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, "test" });
            Arrays.ArrayExplode(data);
            runtimeStack.Push(new MuftecDict {{"k", "v"}});
            Arrays.ArrayExplode(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(0);
            runtimeStackExpected.Push(5);
            runtimeStackExpected.Push(1);
            runtimeStackExpected.Push("test");
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push("k");
            runtimeStackExpected.Push("v");
            runtimeStackExpected.Push(1);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayExtract
        ///</summary>
        [TestMethod]
        public void ArrayExtractTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecDict { { 5, "test" }, { "a", "b" } });
            runtimeStack.Push(new MuftecList { 5 });
            Arrays.ArrayExtract(data);
            runtimeStack.Push(new MuftecDict { { 5, "test" }, { "a", "b" } });
            runtimeStack.Push(new MuftecList());
            Arrays.ArrayExtract(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecDict { { 5, "test" } });
            runtimeStackExpected.Push(new MuftecDict());

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayFindVal
        ///</summary>
        [TestMethod]
        public void ArrayFindValTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecList { 5, 10, 5 });
            runtimeStack.Push(5);
            Arrays.ArrayFindVal(data);
            runtimeStack.Push(new MuftecList { 5, 10, 5 });
            runtimeStack.Push(3);
            Arrays.ArrayFindVal(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecList { 0, 2 });
            runtimeStackExpected.Push(new MuftecList());

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ArrayFirst
        ///</summary>
        [TestMethod()]
        public void ArrayFirstTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayFirst(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayGetItem
        ///</summary>
        [TestMethod()]
        public void ArrayGetItemTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayGetItem(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayGetRange
        ///</summary>
        [TestMethod()]
        public void ArrayGetRangeTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayGetRange(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayInsertItem
        ///</summary>
        [TestMethod()]
        public void ArrayInsertItemTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayInsertItem(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayInsertRange
        ///</summary>
        [TestMethod()]
        public void ArrayInsertRangeTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayInsertRange(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayJoin
        ///</summary>
        [TestMethod()]
        public void ArrayJoinTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayJoin(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayKeys
        ///</summary>
        [TestMethod()]
        public void ArrayKeysTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayKeys(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayLast
        ///</summary>
        [TestMethod()]
        public void ArrayLastTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayLast(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayMake
        ///</summary>
        [TestMethod()]
        public void ArrayMakeTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayMake(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayMakeDict
        ///</summary>
        [TestMethod()]
        public void ArrayMakeDictTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayMakeDict(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArrayPrint
        ///</summary>
        [TestMethod()]
        public void ArrayPrintTest()
        {
            OpCodeData data = null; // TODO: Initialize to an appropriate value
            Arrays.ArrayPrint(data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
