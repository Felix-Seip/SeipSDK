using Math_Collection.LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;

namespace Algorithm_Collection.Graph
{
	public class Edge : IEqualityComparer<Edge>
	{
		private double _weight;
		/// <summary>
		/// Gets or Sets the weight of the edge
		/// (Representing the distance)
		/// </summary>
		public double Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		private Node _start;
		/// <summary>
		/// Gets or Sets the start node for the edge
		/// </summary>
		public Node Start
		{
			get { return _start; }
			set { _start = value; }
		}

		private Node _end;
		/// <summary>
		/// Gets or Sets the end node for the edge
		/// </summary>
		public Node End
		{
			get { return _end; }
			set { _end = value; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="start">Start node of the edge</param>
		/// <param name="end">End node of the edge</param>
		public Edge(Node start, Node end)
		{
			Start = start;
			End = end;
			Weight = CalcDistanceForEdge();
			start.AddEdge(this);
			end.AddEdge(this);
		}

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="start">Start node of the edge</param>
		/// <param name="end">End node of the edge</param>
		/// <param name="weigth">Weight of the edge</param>
		public Edge(Node start, Node end, double weigth) : this(start, end)
		{
			Weight = weigth;
		}

		/// <summary>
		/// Calculates the weight for the edge
		/// </summary>
		/// <returns></returns>
		private double CalcDistanceForEdge()
		{
			Vector vectorBeetweenNodes = new Vector(new double[] { End.Location.X - Start.Location.X, End.Location.Y - Start.Location.Y });
			return Math.Round(vectorBeetweenNodes.Magnitude, 3);
		}

		/// <summary>
		/// Gets the string representation for the edge
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Start.Name + "-" + End.Name + " (" + (int)Weight + ")";
		}

		public override bool Equals(object obj)
		{
			Edge compareTo = obj as Edge;
			if (compareTo == null)
				return false;

			return Start.Equals(compareTo.Start) && End.Equals(compareTo.End) && Weight.Equals(compareTo.Weight);
		}

		public bool Equals(Edge x, Edge y)
		{
			//Check whether the objects are the same object. 
			if (Object.ReferenceEquals(x, y)) return true;

			//Check whether the products' properties are equal. 
			return x != null && y != null && x.Start.Equals(y.Start) && x.End.Equals(y.End) && x.Weight == y.Weight;
		}

		public int GetHashCode(Edge obj)
		{
			return obj.GetHashCode();
		}
	}
}
