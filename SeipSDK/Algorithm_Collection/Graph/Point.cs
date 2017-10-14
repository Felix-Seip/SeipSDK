namespace Algorithm_Collection.Graph
{
	/// <summary>
	/// Simple class to hold a x and y coordinate
	/// </summary>
	public class Point
	{
		/// <summary>
		/// Gets or Sets the x coordinate
		/// </summary>
		public double X { get; set; }
		/// <summary>
		/// Gets or Sets the y coordinate
		/// </summary>
		public double Y { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			Point compareTo = obj as Point;
			if (compareTo == null)
				return false;

			return X.Equals(compareTo.X) && Y.Equals(compareTo.Y);
		}
	}
}