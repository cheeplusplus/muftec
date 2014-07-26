using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for ConversionTest and is intended
    ///to contain all ConversionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConversionTest
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
        ///A test for StringToInt
        ///</summary>
        [TestMethod]
        public void StringToIntTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("2");
            Conversion.StringToInt(data);
            runtimeStack.Push("-10");
            Conversion.StringToInt(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push(-10);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StringToFloat
        ///</summary>
        [TestMethod]
        public void StringToFloatTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push("2");
            Conversion.StringToFloat(data);
            runtimeStack.Push("2.5");
            Conversion.StringToFloat(data);
            runtimeStack.Push("-10.5");
            Conversion.StringToFloat(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2f);
            runtimeStackExpected.Push(2.5);
            runtimeStackExpected.Push(-10.5);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for IntToString
        ///</summary>
        [TestMethod]
        public void IntToStringTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2);
            Conversion.IntToString(data);
            runtimeStack.Push(-10);
            Conversion.IntToString(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("2");
            runtimeStackExpected.Push("-10");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for IntToFloat
        ///</summary>
        [TestMethod]
        public void IntToFloatTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2);
            Conversion.IntToFloat(data);
            runtimeStack.Push(-10);
            Conversion.IntToFloat(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2f);
            runtimeStackExpected.Push(-10f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for FloatToString
        ///</summary>
        [TestMethod]
        public void FloatToStringTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2f);
            Conversion.FloatToString(data);
            runtimeStack.Push(2.5);
            Conversion.FloatToString(data);
            runtimeStack.Push(-10.5);
            Conversion.FloatToString(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push("2");
            runtimeStackExpected.Push("2.5");
            runtimeStackExpected.Push("-10.5");

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for FloatToIntTruncate
        ///</summary>
        [TestMethod]
        public void FloatToIntTruncateTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2f);
            Conversion.FloatToIntTruncate(data);
            runtimeStack.Push(2.5);
            Conversion.FloatToIntTruncate(data);
            runtimeStack.Push(-10.5);
            Conversion.FloatToIntTruncate(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push(-10);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for FloatToIntRound
        ///</summary>
        [TestMethod]
        public void FloatToIntRoundTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2f);
            Conversion.FloatToIntRound(data);
            runtimeStack.Push(2.6);
            Conversion.FloatToIntRound(data);
            runtimeStack.Push(-10.6);
            Conversion.FloatToIntRound(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(2);
            runtimeStackExpected.Push(3);
            runtimeStackExpected.Push(-11);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
    }
}
