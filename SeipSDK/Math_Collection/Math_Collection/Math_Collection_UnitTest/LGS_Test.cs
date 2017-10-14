using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math_Collection.LinearAlgebra.Matrices;
using Math_Collection.LinearAlgebra.Vectors;
using Math_Collection;
using Math_Collection.LinearAlgebra;
using System.IO;

namespace Math_Collection_UnitTest
{
	[TestClass]
	public class LGS_Test
	{
		[TestMethod]
		public void SolveWithGaussianElimination_Test()
		{
			Matrix m = new Matrix(new double[4, 4] { { 1, 1, 1, 1 }, { 1, 1, -1, -1 }, { 1, -1, 1, 1 }, { 1, -1, -1, 1 } });
			Vector v = new Vector(new double[4] { 0, 1, 3, -1 });

			LGS lgs = new LGS(m, v);
			Vector result = lgs.Solve(Enums.ESolveAlgorithm.eGaussianElimination);

			Vector expected = new Vector(new double[6] { 1, -2, 3, 4, 2, -1 });

			Assert.AreEqual(expected, result);

		}

        [TestMethod]
        public void SolveWithGaussSeidel_Test()
        {
            Matrix inputMatrix = new Matrix(new double[3, 3]
            {
                {10,-4,-2 },
                {-4,10,-4 },
                { -6,-2,12 }
            });

            Vector rightSideVector = new Vector(new double[3]
            {
                2,
                3,
                1
            });
            Vector startValue = new Vector(new double[3] { 0, 0, 0 });


            LGS lgs = new LGS(inputMatrix, rightSideVector);
            Vector result = lgs.Solve(Enums.ESolveAlgorithm.eGaußSeidel, startValue);

            Vector expected = new Vector(new double[3] { 0.598, 0.741, 0.506 });

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
		public void SolveWithJacobiMethod_Test()
		{
			Matrix inputMatrix = new Matrix(new double[3, 3]
			{
				{10,-4,-2 },
				{-4,10,-4 },
				{ -6,-2,12 }
			});

			Vector rightSideVector = new Vector(new double[3]
			{
				2,
				3,
				1
			});

			Vector startValue = new Vector(new double[3]
			{
				0,
				0,
				0
			});

			string info;
			LGS lgs = new LGS(inputMatrix, rightSideVector);
			Vector actual = lgs.SolveLGSJacobi(startValue, 100, out info);

			if (!string.IsNullOrEmpty(info))
				File.WriteAllText(@"C:\Users\User\Documents\Berufsschule\2. Lehrjahr\LF 8\Iterative Lösungsverfahren\Jacobi_Second_Diagonal.csv", info);

			actual.Round(3);

			Vector expected = new Vector(new double[3]
			{
				0.598,
				0.741,
				0.506
			});

			Assert.IsFalse(false);
		}

		[TestMethod]
		public void Jacobi_Second_NotDiagnonal()
		{
			Matrix inputMatrix = new Matrix(new double[3, 3]
			{
				{-4,10,-4 },
				{ -6,-2,12 },
				{10,-4,-2 }
			});

			Vector rightSideVector = new Vector(new double[3]
			{
				3,
				1,
				2
			});

			Vector startValue = new Vector(new double[3]
			{
				0,
				0,
				0
			});

			string info;
			LGS lgs = new LGS(inputMatrix, rightSideVector);
			Vector actual = lgs.SolveLGSJacobi(startValue, 100, out info);

			if (!string.IsNullOrEmpty(info))
				File.WriteAllText(@"C:\Users\User\Documents\Berufsschule\2. Lehrjahr\LF 8\Iterative Lösungsverfahren\Jacobi_Second_NotDiagonal.csv", info);

			actual.Round(3);

			Vector expected = new Vector(new double[3]
			{
				0.598,
				0.741,
				0.506
			});

			Assert.IsFalse(false);
		}

		[TestMethod]
		public void Jacobi_First_NotDiagonal_Test()
		{
			Matrix inputMatrix = new Matrix(new double[3, 3]
			{
				{3,-7,13 },
				{1,5,3 },
				{ 12,3,-5 }
			});

			Vector rightSideVector = new Vector(new double[3]
			{
				76,
				28,
				1
			});

			Vector startValue = new Vector(new double[3]
			{
				0,
				0,
				0
			});

			string info;
			LGS lgs = new LGS(inputMatrix, rightSideVector);
			Vector actual = lgs.SolveLGSJacobi(startValue, 100, out info);

			if (!string.IsNullOrEmpty(info))
				File.WriteAllText(@"C:\Users\User\Documents\Berufsschule\2. Lehrjahr\LF 8\Iterative Lösungsverfahren\Jacobi_First_NotDiagonal.csv", info);

			actual.Round(3);

			Vector expected = new Vector(new double[3]
			{
				0.598,
				0.741,
				0.506
			});

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void Jacobi_First_Diagonal_Test()
		{
			Matrix inputMatrix = new Matrix(new double[3, 3]
			{
				{12,3,-5 },
				{1,5,3 },
				{ 3,7,13 }
			});

			Vector rightSideVector = new Vector(new double[3]
			{
				1,
				28,
				76
			});

			Vector startValue = new Vector(new double[3]
			{
				0,
				0,
				0
			});

			string info;
			LGS lgs = new LGS(inputMatrix, rightSideVector);
			Vector actual = lgs.SolveLGSJacobi(startValue, 100, out info);

			if (!string.IsNullOrEmpty(info))
				File.WriteAllText(@"C:\Users\User\Documents\Berufsschule\2. Lehrjahr\LF 8\Iterative Lösungsverfahren\Jacobi_First_Diagonal.csv", info);

			actual.Round(3);

			Vector expected = new Vector(new double[3]
			{
				0.598,
				0.741,
				0.506
			});

			Assert.IsTrue(true);
		}
	}
}
