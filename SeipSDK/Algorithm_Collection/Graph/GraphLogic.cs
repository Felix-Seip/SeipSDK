using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Graph
{
	public static class GraphLogic
	{
		/// <summary>
		/// Saves the Graph object as a .graph file
		/// </summary>
		/// <param name="_graph">Graph object that should be saved</param>
		/// <param name="path">Path with filename where the file should be saved</param>
		/// <returns>The written file content as string or empty string if something went wrong</returns>
		public static string ExportGraphToFile(Graph g, string path)
		{
			if (g == null)
				return string.Empty;

			if (string.IsNullOrEmpty(path))
				path = Path.GetRandomFileName() + ".graph";

			if (!Path.HasExtension(path))
				path = path + ".graph";


			string[] fileContent = new string[g.Nodes.Count + g.Edges.Count + 2];
			int index = 0;
			fileContent[index] = "<Nodes>";
			for (int i = 0; i < g.Nodes.Count; i++)
			{
				index++;
				fileContent[index] = g.Nodes[i].ToString();
			}
			index++;
			fileContent[index] = "<Edges>";
			for (int k = 0; k < g.Edges.Count; k++)
			{
				index++;
				fileContent[index] = g.Edges[k].ToString();
			}

			File.WriteAllLines(path, fileContent, Encoding.UTF8);
			return File.ReadAllText(path);
		}

		/// <summary>
		/// Generate a graph from a .graph file
		/// </summary>
		/// <param name="pathToGraphFile">Path to .graph file</param>
		public static Graph ImportGraphFromFile(string pathToGraphFile)
		{
			if (String.IsNullOrEmpty(pathToGraphFile))
				return null;

			if (!File.Exists(pathToGraphFile))
				return null;

			List<Node> Nodes = new List<Node>();
			List<Edge> Edges = new List<Edge>();

			bool nodeInLine = false;
			bool edgeInLine = false;
			string[] allLines = File.ReadAllLines(pathToGraphFile);
			foreach (string line in allLines)
			{
				line.Trim();

				if (line.Equals("<Nodes>"))
				{
					nodeInLine = true;
					edgeInLine = false;
					continue;
				}
				if (line.Equals("<Edges>"))
				{
					nodeInLine = false;
					edgeInLine = true;
					continue;
				}

				if (nodeInLine)
				{
					try
					{
						string name = line.Substring(0, line.IndexOf('[') - 1);
						string x = line.Substring(line.IndexOf('[') + 1, line.IndexOf(',') - 1 - line.IndexOf('['));
						string y = line.Substring(line.IndexOf(',') + 1, line.IndexOf(']') - 1 - line.IndexOf(','));

						//Node erzeugen
						Node n = new Node(name, new Point(Int32.Parse(x), Int32.Parse(y)));
						if (n != null)
							Nodes.Add(n);
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}
				}
				else if (edgeInLine)
				{
					try
					{
						string startNodeName = line.Substring(0, line.IndexOf('-'));
						string endNodeName = line.Substring(line.IndexOf('-') + 1, line.IndexOf('(') - 2 - line.IndexOf('-'));
						string weigth = line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - 1 - line.IndexOf('('));

						//find Node Objekts
						Node startNode = Nodes.Find(n => n.Name.Equals(startNodeName));
						Node endNode = Nodes.Find(n => n.Name.Equals(endNodeName));
						//Edge Objekt
						if (startNode != null && endNode != null)
						{
							Edge e = new Edge(startNode, endNode, double.Parse(weigth));
							if (e != null)
								Edges.Add(e);
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}
				}
			}

			return new Graph(Nodes, Edges);
		}
	}
}
