using System;
using QuikGraph;
using QuikGraph.Algorithms;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new directed graph
        var graph = new AdjacencyGraph<string, Edge<string>>();

        // Add teams
        graph.AddVertex("BAY");
        graph.AddVertex("CHI");
        graph.AddVertex("HOU");
        graph.AddVertex("KC");
        graph.AddVertex("LA");
        graph.AddVertex("LOU");
        graph.AddVertex("NC");
        graph.AddVertex("NJY");
        graph.AddVertex("ORL");
        graph.AddVertex("POR");
        graph.AddVertex("SD");
        graph.AddVertex("SEA");
        graph.AddVertex("UTA");
        graph.AddVertex("WAS");

        // Add some wins, mostly away from:
        // https://en.wikipedia.org/wiki/2024_National_Women%27s_Soccer_League_season
        graph.AddEdge(new Edge<string>("BAY", "CHI"));
        graph.AddEdge(new Edge<string>("BAY", "LA"));
        graph.AddEdge(new Edge<string>("BAY", "LOU"));
        graph.AddEdge(new Edge<string>("BAY", "POR"));
        graph.AddEdge(new Edge<string>("BAY", "SEA"));
        graph.AddEdge(new Edge<string>("CHI", "BAY"));
        graph.AddEdge(new Edge<string>("CHI", "HOU"));
        graph.AddEdge(new Edge<string>("CHI", "POR"));
        graph.AddEdge(new Edge<string>("CHI", "SD"));
        graph.AddEdge(new Edge<string>("CHI", "SEA"));
        graph.AddEdge(new Edge<string>("CHI", "UTA"));
        graph.AddEdge(new Edge<string>("HOU", "BAY"));
        graph.AddEdge(new Edge<string>("HOU", "LA"));
        graph.AddEdge(new Edge<string>("HOU", "SD"));
        graph.AddEdge(new Edge<string>("KC", "BAY"));
        graph.AddEdge(new Edge<string>("KC", "LA"));
        graph.AddEdge(new Edge<string>("KC", "LOU"));
        graph.AddEdge(new Edge<string>("KC", "POR"));
        graph.AddEdge(new Edge<string>("KC", "SD"));
        graph.AddEdge(new Edge<string>("KC", "UTA"));
        graph.AddEdge(new Edge<string>("LA", "CHI"));
        graph.AddEdge(new Edge<string>("LA", "SD"));
        graph.AddEdge(new Edge<string>("LA", "SEA"));
        graph.AddEdge(new Edge<string>("LA", "UTA"));
        graph.AddEdge(new Edge<string>("LOU", "CHI"));
        graph.AddEdge(new Edge<string>("LOU", "NC"));
        graph.AddEdge(new Edge<string>("LOU", "LA"));
        graph.AddEdge(new Edge<string>("LOU", "HOU"));
        graph.AddEdge(new Edge<string>("LOU", "UTA"));
        graph.AddEdge(new Edge<string>("NC", "CHI"));
        graph.AddEdge(new Edge<string>("NC", "SD"));
        graph.AddEdge(new Edge<string>("NC", "WAS"));
        graph.AddEdge(new Edge<string>("NJY", "BAY"));
        graph.AddEdge(new Edge<string>("NJY", "CHI"));
        graph.AddEdge(new Edge<string>("NJY", "HOU"));
        graph.AddEdge(new Edge<string>("NJY", "LA"));
        graph.AddEdge(new Edge<string>("NJY", "LOU"));
        graph.AddEdge(new Edge<string>("NJY", "POR"));
        graph.AddEdge(new Edge<string>("NJY", "SEA"));
        graph.AddEdge(new Edge<string>("ORL", "BAY"));
        graph.AddEdge(new Edge<string>("ORL", "CHI"));
        graph.AddEdge(new Edge<string>("ORL", "HOU"));
        graph.AddEdge(new Edge<string>("ORL", "KC"));
        graph.AddEdge(new Edge<string>("ORL", "LA"));
        graph.AddEdge(new Edge<string>("ORL", "SEA"));
        graph.AddEdge(new Edge<string>("ORL", "UTA"));
        graph.AddEdge(new Edge<string>("ORL", "WAS"));
        graph.AddEdge(new Edge<string>("POR", "BAY"));
        graph.AddEdge(new Edge<string>("POR", "CHI"));
        graph.AddEdge(new Edge<string>("POR", "HOU"));
        graph.AddEdge(new Edge<string>("POR", "ORL"));
        graph.AddEdge(new Edge<string>("SD", "UTA"));
        graph.AddEdge(new Edge<string>("SEA", "LA"));
        graph.AddEdge(new Edge<string>("SEA", "LOU"));
        graph.AddEdge(new Edge<string>("UTA", "BAY"));
        graph.AddEdge(new Edge<string>("UTA", "HOU"));
        graph.AddEdge(new Edge<string>("UTA", "POR"));
        graph.AddEdge(new Edge<string>("WAS", "BAY"));
        graph.AddEdge(new Edge<string>("WAS", "CHI"));
        graph.AddEdge(new Edge<string>("WAS", "HOU"));
        graph.AddEdge(new Edge<string>("WAS", "LA"));
        graph.AddEdge(new Edge<string>("WAS", "LOU"));
        graph.AddEdge(new Edge<string>("WAS", "NJY"));
        graph.AddEdge(new Edge<string>("WAS", "UTA"));
        graph.AddEdge(new Edge<string>("NC", "KC"));
        graph.AddEdge(new Edge<string>("WAS", "KC"));
        graph.AddEdge(new Edge<string>("ORL", "KC"));


        // Find the longest simple cycle using backtracking
        var longestCycle = new List<Edge<string>>();
        var currentCycle = new List<Edge<string>>();
        var visited = new HashSet<string>();

        foreach (var vertex in graph.Vertices)
        {
            FindLongestCycle(vertex, vertex, visited, currentCycle, longestCycle, graph);
        }

        // Display the longest cycle found in order
        if (longestCycle.Count == 0)
        {
            Console.WriteLine("No cycles found in the graph.");
        }
        else
        {
            Console.WriteLine("Longest cycle found:");
            var vertexOrder = new List<string>();
            foreach (var edge in longestCycle)
            {
                if (!vertexOrder.Contains(edge.Source))
                {
                    vertexOrder.Add(edge.Source);
                }
                vertexOrder.Add(edge.Target);
            }

            for (int i = 0; i < vertexOrder.Count; i++)
            {
                if (i < vertexOrder.Count - 1)
                {
                    Console.Write($"{vertexOrder[i]} -> ");
                }
                else
                {
                    Console.Write($"{vertexOrder[i]}");
                }
            }
            Console.WriteLine();
        }
    }

    static void FindLongestCycle(
        string startVertex,
        string currentVertex,
        HashSet<string> visited,
        List<Edge<string>> currentCycle,
        List<Edge<string>> longestCycle,
        AdjacencyGraph<string, Edge<string>> graph)
    {
        if (visited.Contains(currentVertex))
        {
            return;
        }

        visited.Add(currentVertex);

        foreach (var edge in graph.OutEdges(currentVertex))
        {
            currentCycle.Add(edge);

            if (edge.Target == startVertex && currentCycle.Count > longestCycle.Count)
            {
                longestCycle.Clear();
                longestCycle.AddRange(currentCycle);
            }
            else
            {
                FindLongestCycle(startVertex, edge.Target, visited, currentCycle, longestCycle, graph);
            }

            currentCycle.Remove(edge);
        }

        visited.Remove(currentVertex);
    }
}
