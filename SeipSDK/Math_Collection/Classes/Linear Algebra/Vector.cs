using System;

namespace Math_Collection.LinearAlgebra.Vectors
{
	public class Vector
	{
		/// <summary>
		/// Values in the vector.
		/// </summary>
		public double[] Values;

		/// <summary>
		/// The number of elements in the vector.
		/// </summary>
		public int Size
		{
			get
			{
				return Values.Length;
			}

			private set { }
		}

		public double Magnitude
		{
			get
			{
				return CalculateMagnitude();
			}

			private set { }
		}

		public double this[int i]
		{
			get
			{
				return Values[i];
			}
			set
			{
				Values[i] = value;
			}
		}

		public Vector()
		{
			Values = new double[0];
		}

		public Vector(double[] values)
		{
			Values = (double[])values.Clone();
		}

		public Vector(Vector v)
		{
			Values = v.Values;
		}

		/// <summary>
		/// Returns the length of a vector.
		/// </summary>
		private double CalculateMagnitude()
		{
			double squaredValues = 0;

			for (int i = 0; i < Size; i++)
				squaredValues += Math.Pow(this[i],2);

			return Math.Sqrt(squaredValues);
		}

		public override string ToString()
		{
			return ""+Magnitude;
		}

        public void FlushVectorValues()
        {
            for(int i = 0; i < Size; i++)
            {
                Values[i] = 0;
            }
        }

		public override bool Equals(object obj)
		{
			Vector tmp = obj as Vector;
			if (tmp == null)
				return false;

			bool equal = true;

			for (int k = 0; k < Size; k++)
			{
				double currentValue = Math.Round(Values[k], 4);
				double compareValue = Math.Round(tmp[k], 4);
				if (currentValue.CompareTo(compareValue) != 0)
					equal = false;
			}

			return equal;
		}

		/// <summary>
		/// Clones a Vector object
		/// </summary>
		/// <returns></returns>
		public Vector Clone()
		{
			double[] newValues = Values.Clone() as double[];
			if (newValues == null)
				return null;

			return new Vector(newValues);
		}

		/// <summary>
		/// Rounds every value of the vector
		/// </summary>
		/// <param name="decimals">decimal places</param>
		public void Round(int decimals)
		{
			for(int i = 0; i< Size; i++)
			{
				Values[i] = Math.Round(Values[i], decimals);
			}
		}
	}
}