using MuftecBCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuftecLib;
using System.Collections.Generic;

namespace MuftecTest
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
		///A test for StackItemSwap
		///</summary>
		[TestMethod]
		public void StackItemSwapTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Alfredo"));
			runtimeStack.Push(new MuftecStackItem(1.99));
			StackOperations.StackItemSwap(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1.99));
			runtimeStackExpected.Push(new MuftecStackItem("Alfredo"));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for StackItemPopN
		///</summary>
		[TestMethod]
		public void StackItemPopNTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Alfredo"));
			runtimeStack.Push(new MuftecStackItem(1.99));
			runtimeStack.Push(new MuftecStackItem("Class action"));
			runtimeStack.Push(new MuftecStackItem(2));
			StackOperations.StackItemPopN(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("Alfredo"));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for StackItemPop
		///</summary>
		[TestMethod]
		public void StackItemPopTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Alfredo"));
			runtimeStack.Push(new MuftecStackItem(1.99));
			StackOperations.StackItemPop(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("Alfredo"));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for StackItemDup
		///</summary>
		[TestMethod]
		public void StackItemDupTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Alfredo"));
			runtimeStack.Push(new MuftecStackItem(1.99));
			StackOperations.StackItemDup(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem("Alfredo"));
			runtimeStackExpected.Push(new MuftecStackItem(1.99));
			runtimeStackExpected.Push(new MuftecStackItem(1.99));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for StackDepth
		///</summary>
		[TestMethod]
		public void StackDepthTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Alfredo"));
			runtimeStack.Push(new MuftecStackItem(1.99));
			StackOperations.StackDepth(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(new MuftecStackItem("Alfredo"));
            runtimeStackExpected.Push(new MuftecStackItem(1.99));
			runtimeStackExpected.Push(new MuftecStackItem(2));

            Shared.CompareStacks(runtimeStack, runtimeStackExpected);
		}
	}
}
