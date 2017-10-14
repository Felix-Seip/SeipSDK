using Math_Collection.LinearAlgebra.Matrices;
using Math_Collection.LinearAlgebra.Vectors;
using System;

namespace Math_Collection.LinearAlgebra
{
    /// <summary>
    /// Static Class for all linear algebra operations
    /// </summary>
    public static class LinearAlgebraOperations
    {
		/// <summary>
		/// Adds two vectors together
		/// </summary>
		/// <param name="vector1">First summand</param>
		/// <param name="vector2">Second summand</param>
		/// <returns>The sum vector</returns>
        public static Vector AddVectorToVector(Vector vector1, Vector vector2)
        {
            double[] addedValues = new double[vector1.Size];
            if (vector1.Size == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    addedValues[i] = vector1[i] + vector2[i];
                }
            }
            return new Vector(addedValues);
        }

        /// <summary>
        /// Returns the directional vector between two vectors.
        /// </summary>
        public static Vector SubtractVectorFromVector(Vector vector1, Vector vector2)
        {
            double[] subtractedValues = new double[vector1.Size];
            if (vector1.Values.Length == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    subtractedValues[i] = vector1[i] - vector2[i];
                }
            }
            return new Vector(subtractedValues);
        }

        /// <summary>
        /// Returns the product two vectors.
        /// </summary>
        public static Vector MultiplyVectorWithVector(Vector vector1, Vector vector2)
        {
            double[] multipliedValues = new double[vector1.Size];
            if (vector1.Size == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    multipliedValues[i] = vector1[i] * vector2[i];
                }
            }
            return new Vector(multipliedValues);
        }

        /// <summary>
        /// Returns the dot product of two vectors.
        /// </summary>
        public static double CalculateDotProduct(Vector vector1, Vector vector2)
        {
            double dotProduct = 0;
            if (vector1.Size == vector2.Size)
            {
                for (int i = 0; i < vector1.Size; i++)
                {
                    dotProduct += vector1[i] * vector2[i];
                }
            }
            return dotProduct;
        }

		/// <summary>
		/// Returns the cross product of two vectors
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector CalculateCrossProduct(Vector v1, Vector v2)
		{
			if (v1.Size != v2.Size)
			{
				throw new Exception("The given vectors don't have the same length");
			}

			double[] normalVectorValues = new double[v1.Size];
			for (int i = 1; i < v1.Size + 1; i++)
			{
				if (i == v1.Size)
				{
					normalVectorValues[i - 1] = (v1[0] * v2[1]) - (v1[1] * v2[0]);
				}
				else if (i == v1.Size - 1)
				{
					normalVectorValues[i - 1] = (v1[i] * v2[0]) - (v1[0] * v2[i]);
				}
				else
				{
					normalVectorValues[i - 1] = (v1[i] * v2[i + 1]) - (v1[i + 1] * v2[i]);
				}
			}
			return new Vector(normalVectorValues);
		}

		/// <summary>
		/// Multiplies a Vector with a scalar
		/// </summary>
		public static Vector MultiplyVectorWithScalar(Vector vector, double scalar)
        {
            double[] multipliedValues = new double[vector.Size];

            for (int i = 0; i < vector.Size; i++)
            {
                multipliedValues[i] = vector[i] * scalar;
            }

            return new Vector(multipliedValues);
        }

        /// <summary>
        /// Returns the product of a matrix and a scalar.
        /// </summary>
        public static Matrix MultiplyMatrixWithScalar(Matrix matrix, double scalar)
        {
            double[,] resultingMatrixValues = new double[matrix.RowCount, matrix.ColumnCount];

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    resultingMatrixValues[i, j] = matrix[i, j] * scalar;
                }
            }
            return new Matrix(resultingMatrixValues);
        }

        /// <summary>
        /// Returns the product of a matrix and a vector.
        /// </summary>
        public static Vector MultiplyMatrixWithVector(Matrix matrix, Vector vector)
        {
            double[] resultingVectorValues = new double[vector.Values.Length];

            //Check the needed requirements for a multiplication.
            if (matrix.ColumnCount == vector.Values.Length)
            {
                for (int i = 0; i < matrix.RowCount; i++)
                {
                    for (int j = 0; j < matrix.ColumnCount; j++)
                    {
                        resultingVectorValues[i] += matrix[i, j] * vector[j];
                    }
                }
            }
            return new Vector(resultingVectorValues);
        }

        /// <summary>
        /// Returns the product of two matrices.
        /// </summary>
        public static Matrix MultiplyMatrixWithMatrix(Matrix matrix1, Matrix matrix2)
        {
            double[,] multipliedMatrix = new double[matrix1.RowCount, matrix1.ColumnCount];

            //Check the needed requirements for a matrix multiplication.
            if (matrix1.ColumnCount == matrix2.RowCount)
            {
                for (int i = 0; i < matrix1.RowCount; i++)
                {
                    for (int j = 0; j < matrix2.ColumnCount; j++)
                    {
                        for (int k = 0; k < matrix2.ColumnCount - 1; k++)
                        {
                            multipliedMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            return new Matrix(multipliedMatrix);
        }

        /// <summary>
        /// Raises a matrix to a power
        /// </summary>
        /// <param name="m">Matrix that should be raised</param>
        /// <param name="pow">int value to which power the matrix should be taken</param>
        /// <returns>the raised Matrix</returns>
        public static Matrix MultiplyMatrixWithItself(Matrix m, int pow)
        {
            for(int i = 0; i < pow; i++)
            {
                m = MultiplyMatrixWithMatrix(m, m);
            }
            return m;
        }

		/// <summary>
		/// Adds a value to every element in a row
		/// </summary>
		internal static Matrix AddValueToMatrixRowValues(Matrix matrix, double value, int rowIndex)
        {
            if (rowIndex > matrix.RowCount || rowIndex < 0)
                throw new IndexOutOfRangeException();

            for (int k = 0; k < matrix.ColumnCount; k++)
            {
                matrix[rowIndex, k] = matrix[rowIndex, k] + value;
            }
            return matrix;
        }

		/// <summary>
		/// Subtracts a value to every element in a row
		/// </summary>
		internal static Matrix SubtractValueFromMatrixRowValues(Matrix matrix, double value, int rowIndex)
        {
            if (rowIndex > matrix.RowCount || rowIndex < 0)
                throw new IndexOutOfRangeException();

            for (int k = 0; k < matrix.ColumnCount; k++)
            {
                matrix[rowIndex, k] = matrix[rowIndex, k] - value;
            }
            return matrix;
        }

		/// <summary>
		/// Multiplies a value to every element in a row
		/// </summary>
		internal static Matrix MultiplyValueToMatrixRowValues(Matrix matrix, double value, int rowIndex)
        {
            if (rowIndex > matrix.RowCount || rowIndex < 0)
                throw new IndexOutOfRangeException();

			Matrix result = new Matrix(matrix.Values);

            for (int k = 0; k < matrix.ColumnCount; k++)
            {
				result[rowIndex, k] = matrix[rowIndex, k] * value;
            }
            return result; 
        }

        /// <summary>
        /// Divides a value to every element in a row
        /// </summary>
        internal static Matrix DivideValueByMatrixRowValues(Matrix matrix, double value, int rowIndex)
        {
            if (rowIndex > matrix.RowCount || rowIndex < 0)
                throw new IndexOutOfRangeException();

            if (value == 0)
                throw new Exception("entered value can not be 0 by a division");

            for (int k = 0; k < matrix.ColumnCount; k++)
            {
                matrix[rowIndex, k] = matrix[rowIndex, k] / value;
            }
            return matrix;
        }
		
        /// <summary>
        /// Changes a whole Column of a Matrix with the Vector Values
        /// Uses for Cramersche Regel
        /// </summary>
        /// <param name="sourceMatrix">Matrix that should be changed</param>
        /// <param name="changeWith">Vector that is set into to the matrix</param>
        /// <param name="columnIndex">column that changes</param>
        /// <returns>the changed Matrix or null if something fails</returns>
        internal static Matrix ChangeColumnInMatrix(Matrix sourceMatrix, Vector changeWith, int columnIndex)
		{
			if (sourceMatrix.ColumnCount != changeWith.Size)
				return null;

			if (columnIndex < 0 || columnIndex > sourceMatrix.ColumnCount)
				return null;

			Matrix changedMatrix = new Matrix(sourceMatrix.Values);

			for (int i=0; i < sourceMatrix.RowCount; i++)
			{
				changedMatrix[i,columnIndex] = changeWith[i];
			}

			return changedMatrix;
		}

        /// <summary>
        /// Returns the transposed version of the matrix.
        /// </summary>
        public static Matrix TransposeMatrix(Matrix matrix)
        {
            double[,] transposedMatrixValues = new double[matrix.ColumnCount, matrix.RowCount];

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                for (int j = 0; j < matrix.RowCount; j++)
                {
                    transposedMatrixValues[i, j] = matrix[j, i];
                }
            }
            return new Matrix(transposedMatrixValues);
        }

        /// <summary>
        /// Removes the specified row and column from a matrix.
        /// </summary>
        private static Matrix RemoveRowsColumns(Matrix matrix, int row, int column)
        {
            double[,] newMatrix = new double[matrix.RowCount - 1, matrix.ColumnCount - 1];

            for (int i = 0, j = 0; i < matrix.RowCount; i++)
            {
                if (i == row)
                    continue;

                for (int k = 0, u = 0; k < matrix.ColumnCount; k++)
                {
                    if (k == column)
                        continue;

                    newMatrix[j, u] = matrix[i, k];
                    u++;
                }
                j++;
            }
            return new Matrix(newMatrix);
        }

		/// <summary>
		/// Copies a piece of a given matrix
		/// Usesd for the calculation of determinant
		/// </summary>
		/// <param name="row">Rowindex which should not be copied</param>
		/// <param name="column">Columnindex which should not be copied</param>
		/// <param name="matrix">Input matrix</param>
		/// <returns>The copied matrix</returns>
        private static Matrix CopyUnderlyingMatrix(int row, int column, Matrix matrix)
        {
            double[,] newMatrix = new double[matrix.RowCount - 1, matrix.ColumnCount - 1];
            for (int i = 0, j = 0; i < matrix.RowCount; i++)
            {
                if (i == row)
                    continue;

                for (int k = 0, u = 0; k < matrix.ColumnCount; k++)
                {
                    if (k == column)
                        continue;

                    newMatrix[j, u] = matrix[i, k];
                    u++;
                }
                j++;
            }

            return new Matrix(newMatrix);
        }

		/// <summary>
		/// Calculates the determinant of a matrix
		/// </summary>
		/// <param name="determinantMatrix"></param>
		/// <returns></returns>
        internal static double CalculateDeterminant(Matrix determinantMatrix)
        {
            double determinant = 0;

            if (determinantMatrix.ColumnCount > 2 && determinantMatrix.RowCount > 2)
            {
                for (int j = 0; j < determinantMatrix.ColumnCount; j++)
                {
                    determinant += Math.Pow(-1, 1 + j + 1) * determinantMatrix[j, 0] * CalculateDeterminant(CopyUnderlyingMatrix(j, 0, determinantMatrix));
                    double bla = determinant;
                }

            }
            else
            {
                Console.WriteLine("\n" + determinantMatrix.ToString());
                determinant += determinantMatrix[0, 0] * determinantMatrix[1, 1] - determinantMatrix[0, 1] * determinantMatrix[1, 0];
            }
            return determinant;
        }

        /// <summary>
        /// Calculates the upper right and lower left pyramid matrix.
        /// </summary>
        private static Matrix CalculateLowerLeftUpperRightPyramidMatrix(Matrix inputMatrix)
        {
            Matrix R = new Matrix(inputMatrix.Values);

            double[,] LMatrixVals = new double[R.RowCount, R.ColumnCount];

            Matrix L = new Matrix(LMatrixVals);

            for (int i = 0; i < L.ColumnCount - 1; i++)
            {
                for (int k = i + 1; k < L.RowCount; k++)
                {
                    L[k, i] = inputMatrix[k, i] / inputMatrix[i, i];
                    for (int j = i; j < L.RowCount; j++)
                        R[k, j] = R[k, j] - L[k, i] * R[i, j];
                }
            }
            return L;
        }

		/// <summary>
		/// Calculates the inverse matrix
		/// </summary>
		/// <param name="inputMatrix"></param>
		/// <returns>The inverse Matrix</returns>
        public static Matrix CalculateInverseMatrix(Matrix inputMatrix)
        {
            for (int i = 0; i < inputMatrix.RowCount; i++)
            {
                for (int j = 0; j < inputMatrix.RowCount; j++)
                {
                    if (i != j)
                    {
                        double ratio = inputMatrix[j, i] / inputMatrix[i, i];
                        for (int k = 0; k < inputMatrix.ColumnCount; k++)
                        {
                            inputMatrix[j, k] -= ratio * inputMatrix[i, k];
                        }
                    }
                }
            }
            for (int i = 0; i < inputMatrix.RowCount; i++)
            {
                double a = inputMatrix[i, i];
                for (int j = 0; j < inputMatrix.RowCount; j++)
                {
                    inputMatrix[i, j] /= a;
                }
            }
            return inputMatrix;
        }

        public static Matrix TransposeVector(Vector vector)
        {
            Matrix matrix = new Matrix(new double[1, vector.Size]);
            for(int i = 0; i < vector.Size; i++)
            {
                matrix[1, i] = vector[i];
            }
            return matrix;
        }
    }
}
