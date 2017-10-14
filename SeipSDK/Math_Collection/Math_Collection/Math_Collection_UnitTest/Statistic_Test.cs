using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuntimeFunctionParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Math_Collection_UnitTest
{
	[TestClass]
	public class Statistic_Test
	{
		private static List<Point> _points;

		[ClassInitialize]
		public static void ClassInit(TestContext tc)
		{
			_points = new List<Point>();
		}

		[TestInitialize]
		public void TestInit()
		{
			_points.Clear();
		}

		[TestMethod]
		public void PolynominalRegression_Test()
		{

			// Linear
			_points.Add(new Point(1, 3));
			_points.Add(new Point(2, 1));
			_points.Add(new Point(3, 4));
			_points.Add(new Point(4, 6));
			_points.Add(new Point(5, 5));
			Function actual = Math_Collection.Statistic.PolynominalRegression.CreateRegression(_points, 1);
			Assert.AreEqual("0.9*Math.Pow(x,1)+1.1", actual.OriginalFunction);
			_points.Clear();

			// Polynominal 3.Degree
			_points.Add(new Point(-1, -1));
			_points.Add(new Point(0, 3));
			_points.Add(new Point(1, 2));
			_points.Add(new Point(2, 5));
			_points.Add(new Point(3, 4));
			_points.Add(new Point(5, 2));
			_points.Add(new Point(7, 5));
			_points.Add(new Point(9, 4));

			actual = Math_Collection.Statistic.PolynominalRegression.CreateRegression(_points, 3);
			Assert.IsTrue(AreFunctionsRoundedEqual("0.027837885209210222*Math.Pow(x,3)+-0.41139336181583719*Math.Pow(x,2)" +
				"+1.7469815859079403*Math.Pow(x,1)+1.7773844621673596", actual.OriginalFunction));

			_points.Clear();

			// Polynominal -1 Degree
			// that test must throw an argument exception
			_points.Add(new Point(1, 3));
			_points.Add(new Point(2, 1));
			_points.Add(new Point(3, 3));
			_points.Add(new Point(4, 8));
			try
			{
				actual = Math_Collection.Statistic.PolynominalRegression.CreateRegression(_points, -1);
				Assert.Fail();
			}
			catch (ArgumentException ex)
			{
				Assert.IsTrue(true);
			}

			_points.Clear();
		}

		#region Helper functions

		private bool AreFunctionsRoundedEqual(string fx, string gx)
		{
			try
			{
				string roundedFX = RoundFunction(fx);
				string roundedGX = RoundFunction(gx);
				return roundedFX.Equals(roundedGX);
			}
			catch
			{
				return false;
			}
		}

		private string RoundFunction(string f)
		{
			RegexOptions options = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;
			Regex findNumbersEx = new Regex(@"\d+[.]\d+", options);
			MatchCollection matchesF = findNumbersEx.Matches(f);

			for (int i = 0; i < matchesF.Count; i++)
			{
				double number;
				string numberString = matchesF[i].Value;
				double.TryParse(numberString, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out number);
				number = Math.Round(number, 3);
				f = f.Replace(numberString, "" + number);
			}
			return f;
		}

		#endregion
	}
}
