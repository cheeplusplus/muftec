using MuftecBCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuftecLib;
using System.Collections.Generic;

namespace MuftecTest
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
			runtimeStack.Push(new MuftecStackItem("2"));
			Conversion.StringToInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("-10"));
			Conversion.StringToInt(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2));
			runtimeStackExpected.Push(new MuftecStackItem(-10));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for StringToFloat
		///</summary>
		[TestMethod]
		public void StringToFloatTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("2"));
			Conversion.StringToFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("2.5"));
			Conversion.StringToFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("-10.5"));
			Conversion.StringToFloat(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2f));
			runtimeStackExpected.Push(new MuftecStackItem(2.5));
			runtimeStackExpected.Push(new MuftecStackItem(-10.5));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IntToString
		///</summary>
		[TestMethod]
		public void IntToStringTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(2));
			Conversion.IntToString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10));
			Conversion.IntToString(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("2"));
			runtimeStackExpected.Push(new MuftecStackItem("-10"));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IntToFloat
		///</summary>
		[TestMethod]
		public void IntToFloatTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(2));
			Conversion.IntToFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10));
			Conversion.IntToFloat(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2f));
			runtimeStackExpected.Push(new MuftecStackItem(-10f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for FloatToString
		///</summary>
		[TestMethod]
		public void FloatToStringTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(2f));
			Conversion.FloatToString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(2.5));
			Conversion.FloatToString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10.5));
			Conversion.FloatToString(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("2"));
			runtimeStackExpected.Push(new MuftecStackItem("2.5"));
			runtimeStackExpected.Push(new MuftecStackItem("-10.5"));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for FloatToIntTruncate
		///</summary>
		[TestMethod]
		public void FloatToIntTruncateTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(2f));
			Conversion.FloatToIntTruncate(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(2.5));
			Conversion.FloatToIntTruncate(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10.5));
			Conversion.FloatToIntTruncate(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2));
			runtimeStackExpected.Push(new MuftecStackItem(2));
			runtimeStackExpected.Push(new MuftecStackItem(-10));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for FloatToIntRound
		///</summary>
		[TestMethod]
		public void FloatToIntRoundTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(2f));
			Conversion.FloatToIntRound(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(2.6));
			Conversion.FloatToIntRound(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10.6));
			Conversion.FloatToIntRound(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2));
			runtimeStackExpected.Push(new MuftecStackItem(3));
			runtimeStackExpected.Push(new MuftecStackItem(-11));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}
	}
}
