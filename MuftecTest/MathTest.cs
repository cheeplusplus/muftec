using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for MathTest and is intended
    ///to contain all MathTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MathTest
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
        ///A test for AbsoluteVal
        ///</summary>
        [TestMethod]
        public void AbsoluteValTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-2);
            Math.AbsoluteVal(data);
            runtimeStack.Push(5);
            Math.AbsoluteVal(data);
            runtimeStack.Push(5f);
            Math.AbsoluteVal(data);
            runtimeStack.Push(-5.8);
            Math.AbsoluteVal(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push(5);
            runtimeStackExpected.Push(5f);
            runtimeStackExpected.Push(5.8);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod]
        public void AddTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3);
            runtimeStack.Push(9);
            Math.Add(data);
            runtimeStack.Push(3.1);
            runtimeStack.Push(9);
            Math.Add(data);
            runtimeStack.Push(3.25);
            runtimeStack.Push(9.25);
            Math.Add(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(12);
            runtimeStackExpected.Push(12.1);
            runtimeStackExpected.Push(12.5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }



        /// <summary>
        ///A test for Divide
        ///</summary>
        [TestMethod]
        public void DivideTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(8);
            runtimeStack.Push(2);
            Math.Divide(data);
            runtimeStack.Push(10);
            runtimeStack.Push(2.5);
            Math.Divide(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(4);
            runtimeStackExpected.Push(4f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Exponent
        ///</summary>
        [TestMethod]
        public void ExponentTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3);
            runtimeStack.Push(2);
            Math.Exponent(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(9f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for MinusMinus
        ///</summary>
        [TestMethod]
        public void MinusMinusTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(5);
            Math.MinusMinus(data);
            runtimeStack.Push(10.5);
            Math.MinusMinus(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(4);
            runtimeStackExpected.Push(9.5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Modulus
        ///</summary>
        [TestMethod]
        public void ModulusTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3);
            runtimeStack.Push(2);
            Math.Modulus(data);
            runtimeStack.Push(10.5);
            runtimeStack.Push(2.5);
            Math.Modulus(data);
            runtimeStack.Push(3);
            runtimeStack.Push(2.5);
            Math.Modulus(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(1);
            runtimeStackExpected.Push(0.5);
            runtimeStackExpected.Push(0.5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Multiply
        ///</summary>
        [TestMethod]
        public void MultiplyTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3);
            runtimeStack.Push(4);
            Math.Multiply(data);
            runtimeStack.Push(3.5);
            runtimeStack.Push(4);
            Math.Multiply(data);
            runtimeStack.Push(10.5);
            runtimeStack.Push(4.5);
            Math.Multiply(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(12);
            runtimeStackExpected.Push(14f);
            runtimeStackExpected.Push(47.25);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for PlusPlus
        ///</summary>
        [TestMethod]
        public void PlusPlusTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3);
            Math.PlusPlus(data);
            runtimeStack.Push(9.5);
            Math.PlusPlus(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(4);
            runtimeStackExpected.Push(10.5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Sign
        ///</summary>
        [TestMethod]
        public void SignTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-10);
            Math.Sign(data);
            runtimeStack.Push(-10.5);
            Math.Sign(data);
            runtimeStack.Push(0);
            Math.Sign(data);
            runtimeStack.Push(0.0f);
            Math.Sign(data);
            runtimeStack.Push(7);
            Math.Sign(data);
            runtimeStack.Push(7.5);
            Math.Sign(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(-1);
            runtimeStackExpected.Push(-1);
            runtimeStackExpected.Push(0);
            runtimeStackExpected.Push(0);
            runtimeStackExpected.Push(1);
            runtimeStackExpected.Push(1);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Subtract
        ///</summary>
        [TestMethod]
        public void SubtractTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(9);
            runtimeStack.Push(2);
            Math.Subtract(data);
            runtimeStack.Push(9.5);
            runtimeStack.Push(2);
            Math.Subtract(data);
            runtimeStack.Push(9.5);
            runtimeStack.Push(2.4);
            Math.Subtract(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(7);
            runtimeStackExpected.Push(7.5);
            runtimeStackExpected.Push(7.1);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for GetRandomSeed
        ///</summary>
        [TestMethod]
        public void GetRandomSeedTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Math.GetRandomSeed(data);
            runtimeStack.Push("abracadabra");
            Math.SetRandomSeed(data);
            Math.GetRandomSeed(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("");
            runtimeStackExpected.Push("abracadabra");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for SetRandomSeed
        ///</summary>
        [TestMethod]
        public void SetRandomSeedTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("abracadabra");
            Math.SetRandomSeed(data);
            Math.GetRandomSeed(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("abracadabra");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        /// A test for SeededRandom
        /// </summary>
        [TestMethod]
        public void SeededRandomTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("abracadabra");
            Math.SetRandomSeed(data);
            Math.SeededRandom(data);
            Math.SeededRandom(data);

            Assert.AreEqual(runtimeStack.Count, 2);

            // For now just make sure it returned two integers and they're not the same
            var firstVal = runtimeStack.Pop();
            Assert.AreEqual(firstVal.Type, MuftecType.Integer);
            var secondVal = runtimeStack.Pop();
            Assert.AreEqual(secondVal.Type, MuftecType.Integer);

            Assert.AreNotEqual((int)firstVal.Item, (int)secondVal.Item);
        }

        /// <summary>
        /// A test for Random
        /// </summary>
        [TestMethod]
        public void RandomTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Math.Random(data);
            Math.Random(data);

            Assert.AreEqual(runtimeStack.Count, 2);

            // For now just make sure it returned two integers and they're not the same
            var firstVal = runtimeStack.Pop();
            Assert.AreEqual(firstVal.Type, MuftecType.Integer);
            var secondVal = runtimeStack.Pop();
            Assert.AreEqual(secondVal.Type, MuftecType.Integer);

            Assert.AreNotEqual((int)firstVal.Item, (int)secondVal.Item);
        }
    }
}
