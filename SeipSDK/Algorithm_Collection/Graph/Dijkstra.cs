using Algorithm_Collection.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.GraphAlgorithm
{
    /// <summary>
    /// Statische Klasse für den Dijkstra Algorithmus 
    /// </summary>
    public static class Dijkstra
    {
        /// <summary>
        /// Findet den Schnellste/Kürzesten Weg zwischen zwei Knoten
        /// </summary>
        /// <param name="graph">Graph auf den der Algo angewendet werden soll</param>
        /// <param name="start">Startknoten von dem der Algorithmus startet</param>
        /// <param name="end">Zielknoten für den Algorithmus</param>
        /// <returns></returns>
        public static Route FindShortestPath(Graph.Graph graph, Node start, Node end)
        {
            //Zu wenig Daten für den Algorithmus -> raus hier!
            if (graph == null || start == null || end == null)
                return null;

            //Initialisierung des aktuellen Knotens mit dem Startknoten
            Node currentNode = start;
            //Vorbereitung: Setze alle Knoten auf maximale Distanz und nicht besucht
            foreach (Node n in graph.Nodes)
            {
                n.DistanceToStartNode = double.MaxValue;
                n.Visited = false;
            }
            //Für den Startknoten Distanz auf 0 setzten
            currentNode.DistanceToStartNode = 0.0;
            //Liste aller noch nicht besuchten Knoten
            List<Node> unvisitedNodes = graph.GetUnvisitedNodes();

            bool isRouteFound = false;
            bool isNoRouteAvailable = false;

            while (!isRouteFound)
            {
                foreach (Node neighbour in currentNode.GetUnvisitedNeighbours())
                {
                    //Distanz von aktuellem Knoten zum unbesuchten Nachbarn
                    double dist = currentNode.DistanceToStartNode + currentNode.GetWeightToNeighbour(neighbour);
                    //Wenn Distanz kleiner ist als gespeicherte Distanz des Nachbarns
                    if (dist < neighbour.DistanceToStartNode)
                    {
                        neighbour.DistanceToStartNode = dist;
                        neighbour.PreviousNode = currentNode;
                    }
                }

                currentNode.Visited = true; //CurrentNode wurde nun besucht
                unvisitedNodes = graph.GetUnvisitedNodes(); //liste neu laden

                //Es gibt keine unbesuchten Knoten mehr
                if (unvisitedNodes.Count == 0)
                {
                    isRouteFound = true;
                }
                else
                {
                    //Weitere Abbruchbedingung, wenn Endknoten bereits besucht wurde
                    isRouteFound = !unvisitedNodes.Any(node => node == end);
                    //Kleinste Distanz von allen unbesuchten Knoten
                    double minUnvisitedDistance = unvisitedNodes.Min(node => node.DistanceToStartNode);
                    //Keine Route vorhanden, wenn kleinste Distanz immer noch Maximal ist
                    isNoRouteAvailable = minUnvisitedDistance == Double.MaxValue;

                    if (isNoRouteAvailable)
                    {
                        return null;
                    }
                    else if (!isRouteFound)
                    {
                        //Route noch nicht gefunden -> Wähle den nähsten Knoten als nächsten Knoten
                        currentNode = unvisitedNodes.First(node => node.DistanceToStartNode == minUnvisitedDistance);
                    }
                }
            }

            //Weg wurde gefunden -> Route zusammenbauen
            return new Route(start, end);
        }

      
    }
}
