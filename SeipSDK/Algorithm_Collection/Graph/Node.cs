using System;
using System.Collections.Generic;

namespace Algorithm_Collection.Graph
{
	public class Node : IEqualityComparer<Node>
	{
		private string _name;
		/// <summary>
		/// Sets or Gets the Name of the node
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private List<Edge> _connectedEdges;
		/// <summary>
		/// Gets or Sets a List of all connected edges
		/// </summary>
		public List<Edge> ConnectedEdges
		{
			get { return _connectedEdges; }
			set { _connectedEdges = value; }
		}

		private Point _location;
		/// <summary>
		/// Represents the Postition of the node
		/// </summary>
		public Point Location
		{
			get { return _location; }
			set { _location = value; }
		}

		private bool _marked;
		/// <summary>
		/// Represents if the node is a special node (start or end)
		/// </summary>
		public bool Marked
		{
			get { return _marked; }
			set { _marked = value; }
		}

		private Node _prevNode;
		/// <summary>
		/// Gets or Sets the previous node 
		/// </summary>
		public Node PreviousNode
		{
			get { return _prevNode; }
			set { _prevNode = value; }
		}

		private double _distanceToStart;
		/// <summary>
		/// Gets or Sets the distance to the start node
		/// </summary>
		public double DistanceToStartNode
		{
			get
			{
				return _distanceToStart;
			}
			set { _distanceToStart = value; }
		}

		private double _distanceToEnd;
		/// <summary>
		/// Gets or Sets the distance to the end node
		/// </summary>
		public double DistanceToEnd
		{
			get { return _distanceToEnd; }
			set { _distanceToEnd = value; }
		}

		private bool _visited;
		/// <summary>
		/// Represents if the node was already visited
		/// (used for the algorithms)
		/// </summary>
		public bool Visited
		{
			get { return _visited; }
			set { _visited = value; }
		}

		/// <summary>
		/// Construktor for the node
		/// Location is set to 0;0
		/// </summary>
		/// <param name="name">Name of the node</param>
		public Node(string name)
		{
			Name = name;
			Location = new Point(0, 0);
			Marked = false;
			ConnectedEdges = new List<Edge>();
			PreviousNode = null;
			Visited = false;
		}

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="name">Name of the node</param>
		/// <param name="location">Position of the node</param>
		public Node(string name, Point location)
		{
			Name = name;
			Location = location;
			Marked = false;
			ConnectedEdges = new List<Edge>();
			PreviousNode = null;
			Visited = false;
		}

		/// <summary>
		/// Gets the string representation of the node
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Name + " [" + (int)Location.X + "," + (int)Location.Y + "]";
		}

		/// <summary>
		/// Adds a edge where the node is connected to
		/// </summary>
		/// <param name="e"></param>
		public void AddEdge(Edge e)
		{
			if (ConnectedEdges.Contains(e))
				return;
			ConnectedEdges.Add(e);
		}

		/// <summary>
		/// Gets all connected nodes
		/// </summary>
		/// <returns>List<Node> of all nodes that are connected through the edges</returns>
		public List<Node> GetNeighbours()
		{
			List<Node> neighbours = new List<Node>();
			foreach (Edge e in ConnectedEdges)
			{
				if (e.Start == this)
					neighbours.Add(e.End);
				else
					neighbours.Add(e.Start);
			}

			return neighbours;
		}

		/// <summary>
		/// Gets all unvisited neighbours
		/// </summary>
		/// <returns>List<Node> of all neighbours that are not visited yet</returns>
		public List<Node> GetUnvisitedNeighbours()
		{
			return GetNeighbours().FindAll(node => node.Visited == false);
		}

		/// <summary>
		/// Gets the Neighbour with the lowest weight
		/// </summary>
		/// <returns></returns>
		public Node FindBestNeighbour()
		{
			Edge bestEdge = ConnectedEdges[0];
			foreach (Edge e in ConnectedEdges)
			{
				if (e.Weight < bestEdge.Weight)
					bestEdge = e;
			}

			if (bestEdge.End == this)
				return bestEdge.Start;

			return bestEdge.End;
		}

		/// <summary>
		/// Gets the weight of the edge to the neighbour
		/// </summary>
		/// <param name="neighbour">Neighbour node</param>
		/// <returns>Gets the weight for the edge.
		/// Returns -1 if no edge between the nodes were found</returns>
		public double GetWeightToNeighbour(Node neighbour)
		{
			foreach (Edge e in ConnectedEdges)
			{
				if (e.End == neighbour || e.Start == neighbour)
					return e.Weight;
			}
			return -1.0;
		}

		public override bool Equals(object obj)
		{
			Node compareTo = obj as Node;
			if (compareTo == null)
				return false;

			return Location.Equals(compareTo.Location) && Name.Equals(compareTo.Name);
		}

		public bool Equals(Node x, Node y)
		{
			//Check whether the objects are the same object. 
			if (Object.ReferenceEquals(x, y)) return true;

			//Check whether the products' properties are equal. 
			return x != null && y != null && x.Name.Equals(y.Name) && x.Location.Equals(y.Location);
		}

		public int GetHashCode(Node obj)
		{
			return obj.GetHashCode();
		}
	}
}
