using Algorithm_Collection.Graph;
using System;
using System.Collections.Generic;

namespace Algorithm_Collection.GraphAlgorithm
{
	public static class AStern
	{
		/// <summary>
		/// Finds the shortest path with the A* Algorithm
		/// </summary>
		/// <param name="g">the graph</param>
		/// <param name="start">the start node</param>
		/// <param name="end">the end node</param>
		/// <returns>A route with the shortest path</returns>
		public static Route FindShortestPath(Graph.Graph g, Node start, Node end)
		{
			List<Node> closedList = new List<Node>();
			List<Node> openList = new List<Node>();
			openList.Add(start);

			foreach (Node n in g.Nodes)
			{
				n.DistanceToStartNode = double.MaxValue;
				n.DistanceToEnd = double.MaxValue;
			}

			start.DistanceToStartNode = 0;
			start.DistanceToEnd = CalcHeuristicCost(start, end);

			while (openList.Count > 0)
			{
				Node current = GetNodeWithLowestDistanceToEnd(openList);
				if (current != null && current == end)
				{
					return new Route(start, end);
				}

				openList.Remove(current);
				closedList.Add(current);
				foreach (Node neighbor in current.GetNeighbours())
				{
					if (closedList.Contains(neighbor))
						continue;

					double suggestedDistanceFromStartToCurrent = current.DistanceToStartNode +
						current.GetWeightToNeighbour(neighbor);

					if (!openList.Contains(neighbor))
						openList.Add(neighbor);
					else if (suggestedDistanceFromStartToCurrent >= neighbor.DistanceToStartNode)
						continue;

					neighbor.PreviousNode = current;
					neighbor.DistanceToStartNode = suggestedDistanceFromStartToCurrent;
					neighbor.DistanceToEnd = neighbor.DistanceToStartNode + CalcHeuristicCost(neighbor, end);
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the distance for the direct way from one node to another
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		private static double CalcHeuristicCost(Node from, Node to)
		{
			double resultVectorX = to.Location.X - from.Location.X;
			double resultVectorY = to.Location.Y - from.Location.Y;
			double toThePower = resultVectorX * resultVectorX + resultVectorY * resultVectorY;
			return Math.Sqrt(toThePower);
		}

		/// <summary>
		/// Gets the node with lowest distance to the end
		/// </summary>
		/// <param name="openSet"></param>
		/// <returns></returns>
		private static Node GetNodeWithLowestDistanceToEnd(List<Node> openSet)
		{
			if (openSet.Count == 0)
				return null;

			Node searchedNode = openSet[0];
			foreach (Node n in openSet)
			{
				if (n.DistanceToEnd < searchedNode.DistanceToEnd)
					searchedNode = n;
			}
			return searchedNode;
		}

	}
}
