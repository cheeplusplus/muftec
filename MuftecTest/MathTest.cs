using MuftecBCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuftecLib;
using System.Collections.Generic;

namespace MuftecTest
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
			runtimeStack.Push(new MuftecStackItem(-2));
			Math.AbsoluteVal(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			Math.AbsoluteVal(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5f));
			Math.AbsoluteVal(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-5.8));
			Math.AbsoluteVal(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(2));
			runtimeStackExpected.Push(new MuftecStackItem(5));
			runtimeStackExpected.Push(new MuftecStackItem(5f));
			runtimeStackExpected.Push(new MuftecStackItem(5.8));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Add
		///</summary>
		[TestMethod]
		public void AddTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3));
			runtimeStack.Push(new MuftecStackItem(9));
			Math.Add(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3.1));
			runtimeStack.Push(new MuftecStackItem(9));
			Math.Add(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3.25));
			runtimeStack.Push(new MuftecStackItem(9.25));
			Math.Add(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(12));
			runtimeStackExpected.Push(new MuftecStackItem(12.1));
			runtimeStackExpected.Push(new MuftecStackItem(12.5));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Ceiling
		///</summary>
		[TestMethod]
		public void CeilingTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3.2));
			Math.Ceiling(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(4f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Divide
		///</summary>
		[TestMethod]
		public void DivideTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(8));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Divide(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10));
			runtimeStack.Push(new MuftecStackItem(2.5));
			Math.Divide(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(4));
			runtimeStackExpected.Push(new MuftecStackItem(4f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Exponent
		///</summary>
		[TestMethod]
		public void ExponentTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Exponent(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(9f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Floor
		///</summary>
		[TestMethod]
		public void FloorTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3.8));
			Math.Floor(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(3f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for MinusMinus
		///</summary>
		[TestMethod]
		public void MinusMinusTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			Math.MinusMinus(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10.5));
			Math.MinusMinus(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(4));
			runtimeStackExpected.Push(new MuftecStackItem(9.5));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Modulus
		///</summary>
		[TestMethod]
		public void ModulusTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Modulus(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10.5));
			runtimeStack.Push(new MuftecStackItem(2.5));
			Math.Modulus(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3));
			runtimeStack.Push(new MuftecStackItem(2.5));
			Math.Modulus(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0.5));
			runtimeStackExpected.Push(new MuftecStackItem(0.5));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Multiply
		///</summary>
		[TestMethod]
		public void MultiplyTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3));
			runtimeStack.Push(new MuftecStackItem(4));
			Math.Multiply(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3.5));
			runtimeStack.Push(new MuftecStackItem(4));
			Math.Multiply(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10.5));
			runtimeStack.Push(new MuftecStackItem(4.5));
			Math.Multiply(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(12));
			runtimeStackExpected.Push(new MuftecStackItem(14f));
			runtimeStackExpected.Push(new MuftecStackItem(47.25));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for PlusPlus
		///</summary>
		[TestMethod]
		public void PlusPlusTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3));
			Math.PlusPlus(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(9.5));
			Math.PlusPlus(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(4));
			runtimeStackExpected.Push(new MuftecStackItem(10.5));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Round
		///</summary>
		[TestMethod]
		public void RoundTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(3.239));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Round(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3.9));
			runtimeStack.Push(new MuftecStackItem(0));
			Math.Round(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(3f));
			runtimeStack.Push(new MuftecStackItem(0));
			Math.Round(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(3.24));
			runtimeStackExpected.Push(new MuftecStackItem(4f));
			runtimeStackExpected.Push(new MuftecStackItem(3f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Sign
		///</summary>
		[TestMethod]
		public void SignTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(-10));
			Math.Sign(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(-10.5));
			Math.Sign(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			Math.Sign(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0.0f));
			Math.Sign(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(7));
			Math.Sign(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(7.5));
			Math.Sign(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(-1));
			runtimeStackExpected.Push(new MuftecStackItem(-1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for SquareRoot
		///</summary>
		[TestMethod]
		public void SquareRootTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(9));
			Math.SquareRoot(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(9f));
			Math.SquareRoot(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(3f));
			runtimeStackExpected.Push(new MuftecStackItem(3f));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for Subtract
		///</summary>
		[TestMethod]
		public void SubtractTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(9));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Subtract(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(9.5));
			runtimeStack.Push(new MuftecStackItem(2));
			Math.Subtract(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(9.5));
			runtimeStack.Push(new MuftecStackItem(2.4));
			Math.Subtract(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(7));
			runtimeStackExpected.Push(new MuftecStackItem(7.5));
			runtimeStackExpected.Push(new MuftecStackItem(7.1));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}
	}
}
