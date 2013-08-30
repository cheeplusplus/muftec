using System.Collections.Generic;
using Muftec.BCL.FunctionClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Muftec.Lib;
using Math = Muftec.BCL.FunctionClasses.Math;

namespace Muftec.Test
{
    
    
    /// <summary>
    ///This is a test class for FloatTest and is intended
    ///to contain all FloatTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FloatTest
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

        // TODO: Test with actual values instead of Math function results

        /// <summary>
        ///A test for Acosine
        ///</summary>
        [TestMethod]
        public void AcosineTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Acosine(data);
            runtimeStack.Push(0d);
            Float.Acosine(data);
            runtimeStack.Push(0.5d);
            Float.Acosine(data);
            runtimeStack.Push(5d);
            Float.Acosine(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Acos(-5d));
            runtimeStackExpected.Push(System.Math.Acos(0d));
            runtimeStackExpected.Push(System.Math.Acos(0.5d));
            runtimeStackExpected.Push(System.Math.Acos(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Asine
        ///</summary>
        [TestMethod]
        public void AsineTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Acosine(data);
            runtimeStack.Push(0d);
            Float.Acosine(data);
            runtimeStack.Push(0.5d);
            Float.Acosine(data);
            runtimeStack.Push(5d);
            Float.Acosine(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Acos(-5d));
            runtimeStackExpected.Push(System.Math.Acos(0d));
            runtimeStackExpected.Push(System.Math.Acos(0.5d));
            runtimeStackExpected.Push(System.Math.Acos(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Atangent
        ///</summary>
        [TestMethod]
        public void AtangentTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Atangent(data);
            runtimeStack.Push(0d);
            Float.Atangent(data);
            runtimeStack.Push(0.5d);
            Float.Atangent(data);
            runtimeStack.Push(5d);
            Float.Atangent(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Atan(-5d));
            runtimeStackExpected.Push(System.Math.Atan(0d));
            runtimeStackExpected.Push(System.Math.Atan(0.5d));
            runtimeStackExpected.Push(System.Math.Atan(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Atangent2
        ///</summary>
        [TestMethod]
        public void Atangent2Test()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            runtimeStack.Push(3d);
            Float.Atangent2(data);
            runtimeStack.Push(0d);
            runtimeStack.Push(3d);
            Float.Atangent2(data);
            runtimeStack.Push(0.5d);
            runtimeStack.Push(3d);
            Float.Atangent2(data);
            runtimeStack.Push(5d);
            runtimeStack.Push(3d);
            Float.Atangent2(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Atan2(-5d, 3d));
            runtimeStackExpected.Push(System.Math.Atan2(0d, 3d));
            runtimeStackExpected.Push(System.Math.Atan2(0.5d, 3d));
            runtimeStackExpected.Push(System.Math.Atan2(5d, 3d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Ceiling
        ///</summary>
        [TestMethod]
        public void CeilingTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.2);
            Float.Ceiling(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(4f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Cosine
        ///</summary>
        [TestMethod]
        public void CosineTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Cosine(data);
            runtimeStack.Push(0d);
            Float.Cosine(data);
            runtimeStack.Push(0.5d);
            Float.Cosine(data);
            runtimeStack.Push(5d);
            Float.Cosine(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Cos(-5d));
            runtimeStackExpected.Push(System.Math.Cos(0d));
            runtimeStackExpected.Push(System.Math.Cos(0.5d));
            runtimeStackExpected.Push(System.Math.Cos(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Diff3
        ///</summary>
        [TestMethod]
        public void Diff3Test()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(1d);
            runtimeStack.Push(2d);
            runtimeStack.Push(3d);
            runtimeStack.Push(4d);
            runtimeStack.Push(5d);
            runtimeStack.Push(6d);
            Float.Diff3(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(-3d);
            runtimeStackExpected.Push(-3d);
            runtimeStackExpected.Push(-3d);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Dist3D
        ///</summary>
        [TestMethod]
        public void Dist3DTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(1d);
            runtimeStack.Push(2d);
            runtimeStack.Push(3d);
            Float.Dist3D(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3.741657386);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Epsilon
        ///</summary>
        [TestMethod]
        public void EpsilonTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Float.Epsilon(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(Double.Epsilon);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Exp
        ///</summary>
        [TestMethod]
        public void ExpTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            Float.Exp(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Exp(3.8));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Floor
        ///</summary>
        [TestMethod]
        public void FloorTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            Float.Floor(data);
            runtimeStack.Push(3f);
            Float.Floor(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3f);
            runtimeStackExpected.Push(3f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Fmod
        ///</summary>
        [TestMethod]
        public void FmodTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(2f);
            runtimeStack.Push(3.8);
            Float.Fmod(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.IEEERemainder(2f, 3.8));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Frand
        ///</summary>
        [TestMethod]
        public void FrandTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Float.Frand(data);
            Float.Frand(data);

            Assert.AreEqual(runtimeStack.Count, 2);

            // For now just make sure it returned two floats and they're not the same
            var firstVal = runtimeStack.Pop();
            Assert.AreEqual(firstVal.Type, MuftecType.Float);
            var secondVal = runtimeStack.Pop();
            Assert.AreEqual(secondVal.Type, MuftecType.Float);

            Assert.AreNotEqual(firstVal.AsDouble(), secondVal.AsDouble());
        }

        /// <summary>
        ///A test for Gaussian
        ///</summary>
        [TestMethod]
        public void GaussianTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            data.RuntimeStack.Push(3.8);
            data.RuntimeStack.Push(1.1);
            Float.Gaussian(data);
            data.RuntimeStack.Push(3.8);
            data.RuntimeStack.Push(1.1);
            Float.Gaussian(data);

            Assert.AreEqual(runtimeStack.Count, 2);

            // For now just make sure it returned two floats and they're not the same
            var firstVal = runtimeStack.Pop();
            Assert.AreEqual(firstVal.Type, MuftecType.Float);
            var secondVal = runtimeStack.Pop();
            Assert.AreEqual(secondVal.Type, MuftecType.Float);

            Assert.AreNotEqual(firstVal.AsDouble(), secondVal.AsDouble());
        }

        /// <summary>
        ///A test for Infinite
        ///</summary>
        [TestMethod]
        public void InfiniteTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Float.Infinite(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(Double.PositiveInfinity);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Log
        ///</summary>
        [TestMethod]
        public void LogTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            Float.Log(data);
            runtimeStack.Push(3f);
            Float.Log(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Log(3.8));
            runtimeStackExpected.Push(System.Math.Log(3f));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Log10
        ///</summary>
        [TestMethod]
        public void Log10Test()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            Float.Log10(data);
            runtimeStack.Push(3f);
            Float.Log10(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Log10(3.8));
            runtimeStackExpected.Push(System.Math.Log10(3f));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for ModF
        ///</summary>
        [TestMethod]
        public void ModFTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.81516581);
            Float.ModF(data);
            runtimeStack.Push(3f);
            Float.ModF(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3f);
            runtimeStackExpected.Push(0.81516581);
            runtimeStackExpected.Push(3f);
            runtimeStackExpected.Push(0f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Pi
        ///</summary>
        [TestMethod]
        public void PiTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            Float.Pi(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.PI);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for PolarToXyz
        ///</summary>
        [TestMethod]
        public void PolarToXyzTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            runtimeStack.Push(1.1);
            runtimeStack.Push(0.2);
            Float.PolarToXyz(data);

            // Fuzzball output: 0.3424394240004481, 0.6728111653275464, 3.724252995796718
            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(0.3424394240004481);
            runtimeStackExpected.Push(0.6728111653275464);
            runtimeStackExpected.Push(3.724252995796718);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Round
        ///</summary>
        [TestMethod]
        public void RoundTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.239);
            runtimeStack.Push(2);
            Float.Round(data);
            runtimeStack.Push(3.9);
            runtimeStack.Push(0);
            Float.Round(data);
            runtimeStack.Push(3f);
            runtimeStack.Push(0);
            Float.Round(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3.24);
            runtimeStackExpected.Push(4f);
            runtimeStackExpected.Push(3f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Sine
        ///</summary>
        [TestMethod]
        public void SineTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Sine(data);
            runtimeStack.Push(0d);
            Float.Sine(data);
            runtimeStack.Push(0.5d);
            Float.Sine(data);
            runtimeStack.Push(5d);
            Float.Sine(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Sin(-5d));
            runtimeStackExpected.Push(System.Math.Sin(0d));
            runtimeStackExpected.Push(System.Math.Sin(0.5d));
            runtimeStackExpected.Push(System.Math.Sin(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for SquareRoot
        ///</summary>
        [TestMethod]
        public void SquareRootTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(9);
            Float.SquareRoot(data);
            runtimeStack.Push(9f);
            Float.SquareRoot(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3f);
            runtimeStackExpected.Push(3f);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for Tangent
        ///</summary>
        [TestMethod]
        public void TangentTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(-5d);
            Float.Tangent(data);
            runtimeStack.Push(0d);
            Float.Tangent(data);
            runtimeStack.Push(0.5d);
            Float.Tangent(data);
            runtimeStack.Push(5d);
            Float.Tangent(data);

            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(System.Math.Tan(-5d));
            runtimeStackExpected.Push(System.Math.Tan(0d));
            runtimeStackExpected.Push(System.Math.Tan(0.5d));
            runtimeStackExpected.Push(System.Math.Tan(5d));

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }

        /// <summary>
        ///A test for XyzToPolar
        ///</summary>
        [TestMethod]
        public void XyzToPolarTest()
        {
            var runtimeStack = new Stack<MuftecStackItem>();
            var data = new OpCodeData(runtimeStack);
            runtimeStack.Push(3.8);
            runtimeStack.Push(1.1);
            runtimeStack.Push(0.2);
            Float.XyzToPolar(data);

            // Fuzzball output: 3.961060464067672, 0.2817718672733522, 1.520283319161782
            var runtimeStackExpected = new Stack<MuftecStackItem>();
            runtimeStackExpected.Push(3.961060464067672);
            runtimeStackExpected.Push(0.2817718672733522);
            runtimeStackExpected.Push(1.520283319161782);

            TestShared.CompareStacks(runtimeStack, runtimeStackExpected);
        }
    }
}
