﻿using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muftec.Lib;
using System.Collections.Generic;

namespace Muftec.Test
{
    /// <summary>
    ///This is a test class for LogicTest and is intended
    ///to contain all LogicTest Unit Tests
    ///</summary>
	[TestClass]
	public class LogicTest
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
		///A test for LogicalXor
		///</summary>
		[TestMethod]
		public void LogicalXorTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(1));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalXor(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalXor(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for LogicalOr
		///</summary>
		[TestMethod]
		public void LogicalOrTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(1));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalOr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalOr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			runtimeStack.Push(new MuftecStackItem(0));
			Logic.LogicalOr(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for LogicalNot
		///</summary>
		[TestMethod]
		public void LogicalNotTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalNot(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			Logic.LogicalNot(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for LogicalAnd
		///</summary>
		[TestMethod]
		public void LogicalAndTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(1));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalAnd(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.LogicalAnd(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(0));
			runtimeStack.Push(new MuftecStackItem(0));
			Logic.LogicalAnd(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for LessThanOrEqualTo
		///</summary>
		[TestMethod]
		public void LessThanOrEqualToTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(10));
			Logic.LessThanOrEqualTo(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.LessThanOrEqualTo(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.LessThanOrEqualTo(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for LessThan
		///</summary>
		[TestMethod]
		public void LessThanTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(10));
			Logic.LessThan(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.LessThan(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.LessThan(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IsBool
		///</summary>
		[TestMethod]
		public void IsBoolTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Test"));
			Logic.IsBool(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(1));
			Logic.IsBool(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.IsBool(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10f));
			Logic.IsBool(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsBool(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsBool(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IsString
		///</summary>
		[TestMethod]
		public void IsStringTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Test"));
			Logic.IsString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.IsString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10f));
			Logic.IsString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsString(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsString(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IsInt
		///</summary>
		[TestMethod]
		public void IsIntTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Test"));
			Logic.IsInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.IsInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10f));
			Logic.IsInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsInt(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsInt(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for IsFloat
		///</summary>
		[TestMethod]
		public void IsFloatTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem("Test"));
			Logic.IsFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.IsFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10f));
			Logic.IsFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsFloat(runtimeStack);
			runtimeStack.Push(new MuftecStackItem("fake", MuftecAdvType.OpCode));
			Logic.IsFloat(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for GreaterThanOrEqualTo
		///</summary>
		[TestMethod]
		public void GreaterThanOrEqualToTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(10));
			Logic.GreaterThanOrEqualTo(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.GreaterThanOrEqualTo(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.GreaterThanOrEqualTo(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for GreaterThan
		///</summary>
		[TestMethod]
		public void GreaterThanTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(10));
			Logic.GreaterThan(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.GreaterThan(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(10));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.GreaterThan(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}

		/// <summary>
		///A test for EqualTo
		///</summary>
		[TestMethod]
		public void EqualToTest()
		{
			var runtimeStack = new Stack<MuftecStackItem>();
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(10));
			Logic.EqualTo(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(5));
			runtimeStack.Push(new MuftecStackItem(5));
			Logic.EqualTo(runtimeStack);

			var runtimeStackExpected = new Stack<MuftecStackItem>();
			runtimeStackExpected.Push(new MuftecStackItem(0));
			runtimeStackExpected.Push(new MuftecStackItem(1));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
		}
	}
}
