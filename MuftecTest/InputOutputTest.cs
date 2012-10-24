using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for InputOutputTest and is intended
    ///to contain all InputOutputTest Unit Tests
    ///</summary>
    [TestClass]
    public class InputOutputTest
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
        ///A test for ReadLine
        ///</summary>
        [TestMethod]
        public void ReadLineTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            InputOutput.ReadLine(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(null));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Print
        ///</summary>
        [TestMethod]
        public void PrintTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("Sample string"));
            InputOutput.Print(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
    }
}
