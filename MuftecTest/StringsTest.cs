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
			runtimeStack.Push(new MuftecStackItem("lowercase"));
			Strings.StrToUpper(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("UPPERCASE"));
			Strings.StrToUpper(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("lowercase"));
			Strings.StrToLower(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("UPPERCASE"));
			Strings.StrToLower(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem(5));
			Strings.StrRight(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem(4));
			runtimeStack.Push(new MuftecStackItem(5));
			Strings.StrMid(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			Strings.StrLen(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem(5));
			Strings.StrLeft(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("  teststring  "));
			Strings.StripTailing(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("  teststring"));
			Strings.StripTailing(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring  "));
			Strings.StripTailing(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("  teststring  "));
			Strings.StripLeading(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("  teststring"));
			Strings.StripLeading(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring  "));
			Strings.StripLeading(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("  teststring  "));
			Strings.Strip(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("  teststring"));
			Strings.Strip(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring  "));
			Strings.Strip(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("teststring"));
			Strings.StringCompare(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("TESTSTRiNG"));
			Strings.StringCompare(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("sototallywrong"));
			Strings.StringCompare(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("teststring"));
			Strings.StringCompareI(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("TESTSTRiNG"));
			Strings.StringCompareI(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("sototallywrong"));
			Strings.StringCompareI(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem(3));
			Strings.StrCut(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("s"));
			Strings.SplitReverse(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("s"));
			Strings.Split(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("s"));
			Strings.InStrReverse(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("z"));
			Strings.InStrReverse(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("s"));
			Strings.InStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem("z"));
			Strings.InStr(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("test:string"));
			runtimeStack.Push(new MuftecStackItem(":"));
			Strings.Explode(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("teststring"));
			runtimeStack.Push(new MuftecStackItem(":"));
			Strings.Explode(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("test_string"));
			runtimeStack.Push(new MuftecStackItem(" "));
			runtimeStack.Push(new MuftecStackItem("_"));
			Strings.Substitute(runtimeStack);

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
			runtimeStack.Push(new MuftecStackItem("test"));
			runtimeStack.Push(new MuftecStackItem("string"));
			Strings.Concatenate(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("teststring"));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}
	}
}
