using System.Collections.Generic;
using System.Text;

namespace Algorithm_Collection.Graph
{
	/// <summary>
	/// Represents a route
	/// </summary>
	public class Route
	{
		private List<Node> _nodeList;
		/// <summary>
		/// Gets or Sets the nodes for the route
		/// </summary>
		public List<Node> NodeList
		{
			get { return _nodeList; }
			set { _nodeList = value; }
		}

		private double _distance;
		/// <summary>
		/// Gets or Sets the route lenght
		/// </summary>
		public double Distance
		{
			get { return _distance; }
			set { _distance = value; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Route()
		{
			NodeList = new List<Node>();
			Distance = 0.0;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		public Route(Node start, Node end)
		{
			NodeList = new List<Node>();
			InitRoute(start, end);
		}

		/// <summary>
		/// Reconstructs a route based on the start and end node
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		private void InitRoute(Node start, Node end)
		{
			Node currentNode = end;
			Distance = currentNode.DistanceToStartNode;

			while (currentNode.PreviousNode != null || currentNode != start)
			{
				AddNode(currentNode);
				currentNode = currentNode.PreviousNode;
			}
			AddNode(start);
		}

		/// <summary>
		/// Adds a node to the route
		/// </summary>
		/// <param name="node"></param>
		public void AddNode(Node node)
		{
			if (node == null || NodeList.Contains(node))
			{
				return;
			}

			NodeList.Add(node);
		}

		/// <summary>
		/// Gets the string representation of the route
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = NodeList.Count - 1; i >= 0; i--)
			{
				sb.Append(NodeList[i].Name + "-> \r\n");
			}
			sb.Append("Mit der Länge: " + Distance);
			return sb.ToString();
		}
	}
}
