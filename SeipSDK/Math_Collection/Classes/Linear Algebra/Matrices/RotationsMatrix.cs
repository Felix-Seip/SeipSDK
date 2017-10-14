using System;

namespace Math_Collection.LinearAlgebra.Matrices
{
    public class RotationsMatrix : Matrix
    {
        public enum MatrixType
        {
            OriginAxis = 0,
            XAxis = 1,
            YAxis = 2,
            ZAxis = 3
        }

        /// <summary>
        /// Creates a new rotations matrix. 
        /// </summary>
        public RotationsMatrix(MatrixType type, double angle)
        {
            angle = Basics.Basics.DegreesToRadians(angle);

            //Set the matrix to the corresponding special matrices.
            if (type == (int)MatrixType.OriginAxis)
            {
                Values = new double[,] { { Math.Cos(angle), -Math.Sin(angle), 0 }, { Math.Sin(angle), Math.Cos(angle), 0 }, { 0, 0, 1 } };
            }
            else if (type == MatrixType.XAxis)
            {
                Values = new double[,] { { 1, 0, 0 }, { 0, Math.Cos(angle), -Math.Sin(angle) }, { 0, Math.Sin(angle), Math.Cos(angle) } };
            }
            else if (type == MatrixType.YAxis)
            {
                Values = new double[,] { { Math.Cos(angle), 0, Math.Sin(angle) }, { 0, 1, 0 }, { -Math.Sin(angle), 0, Math.Cos(angle) } };
            }
            else if (type == MatrixType.ZAxis)
            {
                Values = new double[,] { { Math.Cos(angle), -Math.Sin(angle), 0 }, { Math.Sin(angle), Math.Cos(angle), 0 }, { 0, 0, 1 } };
            }
        }

    }
}
