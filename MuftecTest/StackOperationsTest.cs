using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for StackOperationsTest and is intended
    ///to contain all StackOperationsTest Unit Tests
    ///</summary>
    [TestClass]
    public class StackOperationsTest
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
        ///A test for StackDepth
        ///</summary>
        [TestMethod]
        public void StackDepthTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            StackOperations.StackDepth(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(2);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemDup
        ///</summary>
        [TestMethod]
        public void StackItemDupTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            StackOperations.StackItemDup(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(1.99);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemDupN
        /// </summary>
        [TestMethod]
        public void StackItemDupNTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(4);
            runtimeStack.Push(1.99);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(2);
            StackOperations.StackItemDupN(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(4);
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemPop
        ///</summary>
        [TestMethod]
        public void StackItemPopTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            StackOperations.StackItemPop(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemPopN
        ///</summary>
        [TestMethod]
        public void StackItemPopNTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push("Class action");
            runtimeStack.Push(2);
            StackOperations.StackItemPopN(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemSwap
        ///</summary>
        [TestMethod]
        public void StackItemSwapTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            StackOperations.StackItemSwap(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemOver
        /// </summary>
        [TestMethod]
        public void StackItemOverTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            StackOperations.StackItemOver(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemRot
        ///</summary>
        [TestMethod]
        public void StackItemRotTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(2);
            StackOperations.StackItemRot(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StackItemRotate
        ///</summary>
        [TestMethod]
        public void StackItemRotateTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(2);
            runtimeStack.Push("pizza");
            runtimeStack.Push(4);
            StackOperations.StackItemRotate(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push("pizza");
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemPick
        /// </summary>
        [TestMethod]
        public void StackItemPickTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(5);
            runtimeStack.Push(3);
            StackOperations.StackItemPick(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(5);
            runtimeStackExpected.Push("Alfredo");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemPut
        /// </summary>
        [TestMethod]
        public void StackItemPutTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(5);
            runtimeStack.Push(7.7);
            runtimeStack.Push(2);
            StackOperations.StackItemPut(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(7.7);
            runtimeStackExpected.Push(5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemReverse
        /// </summary>
        [TestMethod]
        public void StackItemReverseTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(5);
            runtimeStack.Push(2);
            StackOperations.StackItemReverse(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(5);
            runtimeStackExpected.Push(1.99);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for StackItemLReverse
        /// </summary>
        [TestMethod]
        public void StackItemLReverseTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("Alfredo");
            runtimeStack.Push(1.99);
            runtimeStack.Push(5);
            runtimeStack.Push(2);
            StackOperations.StackItemLReverse(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("Alfredo");
            runtimeStackExpected.Push(5);
            runtimeStackExpected.Push(1.99);
            runtimeStackExpected.Push(2);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
    }
}
