using Math_Collection.Basics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math_Collection_UnitTest
{
    [TestClass]
    public class Basics_Test
    {
        [TestMethod]
        public void FibonacciTest()
        {
            Assert.AreEqual(8, Basics.FibonacciSequence(6));
        }

		[TestMethod]
		public void IntervalTest()
		{
			// Closed Interval
			Interval a = new Interval(1.0, 4.0, 0.5, Math_Collection.Enums.EIntervalFeature.eClosed);
			Assert.AreEqual(1.0, a.MinValue, "In a closed interval the min value should be included");
			Assert.AreEqual(4.0, a.MaxValue, "In a closed interval the max value should be included");
			Assert.AreEqual(3.0, a.Range, "Range is wrong calculated in a closed interval");

			// Open Interval
			Interval b = new Interval(1.0, 4.0, 0.5, Math_Collection.Enums.EIntervalFeature.eOpen);
			Assert.AreEqual(1.5, b.MinValue, "In a open interval the min value should not be included");
			Assert.AreEqual(3.5, b.MaxValue, "In a open interval the max value should not be included");
			Assert.AreEqual(2.0, b.Range, "Range is wrong calculated in a open interval");

			// Lef Open Interval
			Interval c = new Interval(1.0, 4.0, 0.5, Math_Collection.Enums.EIntervalFeature.eLeftOpenRightClosed);
			Assert.AreEqual(1.5, c.MinValue, "In a left open interval the min value should not be included");
			Assert.AreEqual(4.0, c.MaxValue, "In a right closed interval the max value should be included");
			Assert.AreEqual(2.5, c.Range, "Range is wrong calculated in a left open interval");

			// Right Open Interval
			Interval d = new Interval(1.0, 4.0, 0.5, Math_Collection.Enums.EIntervalFeature.eLeftClosedRightOpen);
			Assert.AreEqual(1.0, d.MinValue, "In a left closed interval the min value should be included");
			Assert.AreEqual(3.5, d.MaxValue, "In a right open interval the max value should not be included");
			Assert.AreEqual(2.5, d.Range, "Range is wrong calculated in a left closed interval");
		}
    }
}
