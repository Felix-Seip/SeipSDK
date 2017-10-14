using System;

namespace Math_Collection.LinearAlgebra.Matrices
{
	public class Matrix
	{
		/// <summary>
		/// Values in the matrix.
		/// </summary>
		public double[,] Values { get; protected set; }
		/// <summary>
		/// Row count of the matrix.
		/// </summary>
		public int RowCount
		{
			get
			{
				return Values.GetLength(0);
			}
			private set
			{ }
		}
		/// <summary>
		/// Column count of the matrix.
		/// </summary>
		public int ColumnCount
		{
			get
			{
				return Values.GetLength(1);
			}
			private set
			{ }
		}

		public double Determinant
		{
			get
			{
				return LinearAlgebra.LinearAlgebraOperations.CalculateDeterminant(this);
			}
			private set { }
		}

		public bool IsDiagonallyDominant
		{
			get
			{
				//TODO: Implement Getter
				throw new NotImplementedException();
			}
		}

		public bool IsSqaureMatrix
		{
			get
			{
				return RowCount == ColumnCount;
			}
		}

		public double this[int row,int column]
		{
			get
			{
				return Values[row,column];
			}
			set
			{
				Values[row,column] = value;
			}
		}

		public Matrix() { }
		public Matrix(double[,] matrix)
		{
			Values = (double[,])matrix.Clone();
		}

		public Matrix(Matrix matrix)
		{
			Values = matrix.Values;
		}

		public int NextPivotRow(int startRow,int startColumn)
		{
			if (startRow < 0 || startRow > RowCount || startColumn < 0 || startColumn > ColumnCount)
				return -1;

			for (int i = startRow; i < RowCount; i++)
			{
				if (Values[i,startColumn] != 0)
					return i;
			}

			return -1;
		}

		public override string ToString()
		{
			string matrixAsString = "";
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					matrixAsString += Values[i,j] + "\t";
				}
				matrixAsString += "\n";
			}
			return matrixAsString;
		}

		public override bool Equals(object obj)
		{
			Matrix tmp = obj as Matrix;
			if (tmp == null)
				return false;

			bool equal = true;

			for (int i = 0; i < RowCount; i++)
			{
				for (int k = 0; k < ColumnCount; k++)
				{
					if (Values[i,k] != tmp[i,k])
						equal = false;
				}
			}
			return equal;
		}
		
	}
}
