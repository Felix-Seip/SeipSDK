using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Analysis = Math_Collection.Analysis.AnalysisBase;
using Math_Collection.LinearAlgebra.Vectors;
using Math_Collection;
using RuntimeFunctionParser;
using Math_Collection.Analysis;

namespace Math_Collection_UnitTest
{
	[TestClass]
	public class Analysis_Test
	{
		[TestMethod]
		public void DerivationApproximation_Test()
		{
			double actual = 0.0;
			double expected = 0.0;
			double h = 0.001;
			Parser p = new Parser();

			//Function f(x) = 3h
			string function = "3";
			Function f = p.ParseFunction(function);

			expected = 0.0;
			actual = Analysis.Derivation_Approximation(f, 2, h);
			Assert.IsTrue(IsNearlyEqual(expected, actual,0));

			// f(x) = x^2
			function = "x^2";
			f = p.ParseFunction(function);
			expected = 2.0;
			actual = Analysis.Derivation_Approximation(f, 1, h);
			Assert.IsTrue(IsNearlyEqual(expected, actual,h));
        }

        [TestMethod]
        public void GradientApproximation_Test()
        {
            double h = 0.00001;
            string function = "(x*y+x^2)+(y*x+y^2)";
            Function func = new Parser().ParseFunction(function);
            double[] expected = new double[] { 8, 8};
            double[] actual = Analysis.PartialDerivatives_Approximation(func, new double[] { 2, 2 }, h, true);

            for(int i = 0; i < actual.Length; i++)
            {
                Assert.IsTrue(IsNearlyEqual(expected[i], actual[i], h));    
            }
        }

        [TestMethod]
        public void Gradient_Test()
        {
            Function func = new Parser().ParseFunction("x^2+y^2");
            Gradient grad = new Gradient(func, true);

            double h = 0.00001;

            Vector expected = new Vector(new double[] { 10, 4});
            Vector actual = grad.Solve(5, 2);

            for (int i = 0; i < actual.Size; i++)
            {
                Assert.IsTrue(IsNearlyEqual(expected[i], actual[i], h));
            }
        }

		[TestMethod]
		public void ExtremaApproximationWithFibonacciMethod_Test()
		{
			string function = "x^2";
			Function f = new Parser().ParseFunction(function);
			int n = 30;
			Math_Collection.Basics.Interval intervall = new Math_Collection.Basics.Interval(-16, 16);
			// TODO: Epsilon umgebung mit (min-max) / Nn, damit Test nicht fehlschlägt
			Vector expected = new Vector(new double[] { 2, 1 });
			Vector actual = Analysis.ExtremaApproximatedWithFibonacciMethod(f, intervall, n, Enums.EExtrema.eMinimum);
            Assert.AreEqual(expected, actual);
		}

        [TestMethod]
        public void OptimizeUsingEdgeSearch_Test()
        {
            string function = "x^4+y^4";
            Function f = new Parser().ParseFunction(function);
            Math_Collection.Basics.Interval intervall = new Math_Collection.Basics.Interval(-4, 4);
            Vector pointOfMinimum = Analysis.OptimizeUsingEdgeSearch(f, new Vector(new double[] { 1, 1, 1}), intervall);
        }

        [TestMethod]
		public void ApproximatedRoot_Test()
		{
			string function = "x^2 - 2";
			Function f = new Parser().ParseFunction(function);

			double startValue = 2;
			double epsilon = 0.001;

			double expectedRoot = Math.Round(Math.Sqrt(2), 4);
			double actualRoot = Math.Round(Analysis.CalulateApproximatedRoot(f, startValue,epsilon), 4);

			Assert.IsTrue(IsNearlyEqual(expectedRoot, actualRoot,epsilon));
		}

        [TestMethod]
        public void ApproximatedRootWithGradientMethodWithMinimum_Test()
        {
            //Example of a function with a minimum
            Function func = new Parser().ParseFunction("x^2 + y^2");
            Gradient grad = new Gradient(func, true);
            Vector rootPoint = new Vector(new double[] { 5, 5 });

            Vector actual = Analysis.CalculateRootWithConjugateGradientMethod(grad, rootPoint);
            Vector expected = new Vector(new double[] { 0, 0 });

            Assert.IsTrue(actual.Equals(expected));
        }

        #region Helper methods

        private bool IsNearlyEqual(double a, double b, double deviation)
		{
			return Math.Abs(a - b) <= deviation;
		}

		#endregion
	}
}
