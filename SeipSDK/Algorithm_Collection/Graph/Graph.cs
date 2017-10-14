using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm_Collection.Graph
{
	public class Graph
	{
		private List<Node> _nodes;
		/// <summary>
		/// Gets or Sets the nodes for the graph
		/// </summary>
		public List<Node> Nodes
		{
			get { return _nodes; }
			set { _nodes = value; }
		}

		private List<Edge> _edges;
		/// <summary>
		/// Gets or Sets the edges for the graph
		/// </summary>
		public List<Edge> Edges
		{
			get { return _edges; }
			set { _edges = value; }
		}

		/// <summary>
		/// Standardkonstruktor
		/// </summary>
		public Graph()
		{
			Nodes = new List<Node>();
			Edges = new List<Edge>();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="nodes">Nodeliste</param>
		/// <param name="edges">Edgeliste</param>
		public Graph(List<Node> nodes, List<Edge> edges)
		{
			Nodes = nodes;
			Edges = edges;
		}
	
		/// <summary>
		/// Gets a node by the name
		/// </summary>
		/// <param name="name">Name of the node</param>
		/// <returns>Node if the name is contained in the graph. 
		/// Null if no node was found</returns>
		public Node FindNodeByName(string name)
		{
			foreach (Node n in Nodes)
			{
				if (n.Name.ToLower().Equals(name.ToLower()))
					return n;
			}
			return null;
		}

		/// <summary>
		/// Gets all unvisited nodes
		/// </summary>
		/// <returns></returns>
		public List<Node> GetUnvisitedNodes()
		{
			if (Nodes == null)
				return null;

			return Nodes.FindAll(node => node.Visited == false);
		}
		
		/// <summary>
		/// Gets the start or end node
		/// </summary>
		/// <param name="start">Bei true wird der Startknoten zurückgegeben.
		/// Bei false der Endknoten</param>
		/// <returns></returns>
		public Node GetMarkedNode(bool start = true)
		{
			List<Node> markedNodes = new List<Node>();
			foreach (Node n in Nodes)
			{
				if (n.Marked)
					markedNodes.Add(n);
			}

			if (markedNodes.Count == 0)
				return null;

			if (start)
				return markedNodes[0];

			return markedNodes[1];
		}

		/// <summary>
		/// Gets the string representation of the graph
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (Node n in Nodes)
			{
				sb.Append(n.ToString());
			}
			return sb.ToString();
		}

		public override bool Equals(object obj)
		{
			Graph compareTo = obj as Graph;
			if (compareTo == null)
				return false;

			return Nodes.SequenceEqual(compareTo.Nodes) && Edges.SequenceEqual(compareTo.Edges);
		}
	}
}
