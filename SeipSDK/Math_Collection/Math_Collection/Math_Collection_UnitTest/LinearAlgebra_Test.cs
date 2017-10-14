using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math_Collection;
using Math_Collection.LinearAlgebra.Matrices;
using Math_Collection.LinearAlgebra;
using Math_Collection.LinearAlgebra.Vectors;

namespace Math_Collection_UnitTest
{
    [TestClass]
    public class LinearAlgebra_Test
    {
        [TestMethod]
        public void SwitchRows_Test()
        {
            //double[,] elements = new double[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
            //Matrix m = new Matrix(elements);

            //Matrix actual = LinearAlgebraOperations.SwitchRows(m, 2, 1);
            //Assert.Inconclusive();
        }

        [TestMethod]
        public void LR_Partition_Test()
        {
            //Matrix input = new Matrix(new double[3, 3] { { 1, 2, 3 }, { 1, 1, 1 }, { 3, 3, 1 } });
            //Matrix l = new Matrix();
            //Matrix r = new Matrix();

            //LinearAlgebraOperations.LR_Partition(input, out l, out r);

            //int i = 0;

        }
        
        [TestMethod]
        public void CrossProductTest()
        {
            double[] v1Values = new double[] { 1, 2, 3 };
            double[] v2Values = new double[] { 4, 5, 6 };

            Vector normal = LinearAlgebraOperations.CalculateCrossProduct(new Vector(v1Values), new Vector(v2Values));

            Assert.AreEqual(new Vector(new double[] { -3, 6, -3 }), normal);
        }
    }
}
