using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.BCL.FunctionClasses;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for StringsTest and is intended
    ///to contain all StringsTest Unit Tests
    ///</summary>
    [TestClass]
    public class StringsTest
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
        ///A test for StrToUpper
        ///</summary>
        [TestMethod]
        public void StrToUpperTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("lowercase"));
            Strings.StrToUpper(data);
            runtimeStack.Push(new MuftecStackItem("UPPERCASE"));
            Strings.StrToUpper(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("LOWERCASE"));
            runtimeStackExpected.Push(new MuftecStackItem("UPPERCASE"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrToLower
        ///</summary>
        [TestMethod]
        public void StrToLowerTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("lowercase"));
            Strings.StrToLower(data);
            runtimeStack.Push(new MuftecStackItem("UPPERCASE"));
            Strings.StrToLower(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("lowercase"));
            runtimeStackExpected.Push(new MuftecStackItem("uppercase"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrRight
        ///</summary>
        [TestMethod]
        public void StrRightTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem(5));
            Strings.StrRight(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("tring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrMid
        ///</summary>
        [TestMethod]
        public void StrMidTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem(4));
            runtimeStack.Push(new MuftecStackItem(5));
            Strings.StrMid(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("tring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrLen
        ///</summary>
        [TestMethod]
        public void StrLenTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            Strings.StrLen(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(10));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrLeft
        ///</summary>
        [TestMethod]
        public void StrLeftTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem(5));
            Strings.StrLeft(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("tests"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StripTailing
        ///</summary>
        [TestMethod]
        public void StripTailingTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("  teststring  "));
            Strings.StripTailing(data);
            runtimeStack.Push(new MuftecStackItem("  teststring"));
            Strings.StripTailing(data);
            runtimeStack.Push(new MuftecStackItem("teststring  "));
            Strings.StripTailing(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("  teststring"));
            runtimeStackExpected.Push(new MuftecStackItem("  teststring"));
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StripLeading
        ///</summary>
        [TestMethod]
        public void StripLeadingTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("  teststring  "));
            Strings.StripLeading(data);
            runtimeStack.Push(new MuftecStackItem("  teststring"));
            Strings.StripLeading(data);
            runtimeStack.Push(new MuftecStackItem("teststring  "));
            Strings.StripLeading(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("teststring  "));
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));
            runtimeStackExpected.Push(new MuftecStackItem("teststring  "));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Strip
        ///</summary>
        [TestMethod]
        public void StripTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("  teststring  "));
            Strings.Strip(data);
            runtimeStack.Push(new MuftecStackItem("  teststring"));
            Strings.Strip(data);
            runtimeStack.Push(new MuftecStackItem("teststring  "));
            Strings.Strip(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StringCompare
        ///</summary>
        [TestMethod]
        public void StringCompareTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("teststring"));
            Strings.StringCompare(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("TESTSTRiNG"));
            Strings.StringCompare(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("sototallywrong"));
            Strings.StringCompare(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(1));
            runtimeStackExpected.Push(new MuftecStackItem(0));
            runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StringCompareI
        ///</summary>
        [TestMethod]
        public void StringCompareITest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("teststring"));
            Strings.StringCompareI(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("TESTSTRiNG"));
            Strings.StringCompareI(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("sototallywrong"));
            Strings.StringCompareI(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(1));
            runtimeStackExpected.Push(new MuftecStackItem(1));
            runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for StrCut
        ///</summary>
        [TestMethod]
        public void StrCutTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem(3));
            Strings.StrCut(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("tes"));
            runtimeStackExpected.Push(new MuftecStackItem("tstring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for SplitReverse
        ///</summary>
        [TestMethod]
        public void SplitReverseTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("s"));
            Strings.SplitReverse(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("test"));
            runtimeStackExpected.Push(new MuftecStackItem("string"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Split
        ///</summary>
        [TestMethod]
        public void SplitTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("s"));
            Strings.Split(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("te"));
            runtimeStackExpected.Push(new MuftecStackItem("ststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for InStrReverse
        ///</summary>
        [TestMethod]
        public void InStrReverseTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("s"));
            Strings.InStrReverse(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("z"));
            Strings.InStrReverse(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(4));
            runtimeStackExpected.Push(new MuftecStackItem(-1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for InStr
        ///</summary>
        [TestMethod]
        public void InStrTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("s"));
            Strings.InStr(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem("z"));
            Strings.InStr(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(2));
            runtimeStackExpected.Push(new MuftecStackItem(-1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Explode
        ///</summary>
        [TestMethod]
        public void ExplodeTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("test:string"));
            runtimeStack.Push(new MuftecStackItem(":"));
            Strings.Explode(data);
            runtimeStack.Push(new MuftecStackItem("teststring"));
            runtimeStack.Push(new MuftecStackItem(":"));
            Strings.Explode(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem(2));
            runtimeStackExpected.Push(new MuftecStackItem("test"));
            runtimeStackExpected.Push(new MuftecStackItem("string"));
            runtimeStackExpected.Push(new MuftecStackItem(1));
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Substitute
        ///</summary>
        [TestMethod]
        public void SubstituteTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("test_string"));
            runtimeStack.Push(new MuftecStackItem(" "));
            runtimeStack.Push(new MuftecStackItem("_"));
            Strings.Substitute(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("test string"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Concatenate
        ///</summary>
        [TestMethod]
        public void ConcatenateTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(new MuftecStackItem("test"));
            runtimeStack.Push(new MuftecStackItem("string"));
            Strings.Concatenate(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("teststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
    }
}
