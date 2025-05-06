using System;
using QuikGraph;
using QuikGraph.Algorithms;
using System.IO;
using System.Runtime.CompilerServices;

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

        //Add2024SessonData(graph);
        Add2025SeasonData(graph);

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

            Console.WriteLine($"Cycle found with length {vertexOrder.Count - 1}");

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

    private static void GetMatchResults()
    {
        // https://american-soccer-analysis.github.io/itscalledsoccer/reference/
        // https://app.americansocceranalysis.com/api/v1/__docs__/#/National%20Women's%20Soccer%20League%20(NWSL)/get_nwsl_games
        // https://fbref.com/en/comps/182/schedule/NWSL-Scores-and-Fixtures
        // https://fbref.com/en/comps/182/2015/schedule/2015-NWSL-Scores-and-Fixtures
    }

    private static void Add2025SeasonData(AdjacencyGraph<string, Edge<string>> graph)
    {
        // first team is the winner, second team is the loser. Draws are not included.
        // week 1
        graph.AddEdge(new Edge<string>("ORL", "CHI"));
        graph.AddEdge(new Edge<string>("WAS", "HOU"));
        graph.AddEdge(new Edge<string>("KC", "POR"));

        // Week 2
        graph.AddEdge(new Edge<string>("SEA", "NC"));
        graph.AddEdge(new Edge<string>("KC", "WAS"));
        graph.AddEdge(new Edge<string>("BAY", "LOU"));
        graph.AddEdge(new Edge<string>("SD", "UTA"));
        graph.AddEdge(new Edge<string>("HOU", "CHI"));
        graph.AddEdge(new Edge<string>("ORL", "NJY"));

        // Week 3
        graph.AddEdge(new Edge<string>("WAS", "BAY"));
        graph.AddEdge(new Edge<string>("ORL", "SD"));
        graph.AddEdge(new Edge<string>("KC", "UTA"));
        graph.AddEdge(new Edge<string>("LOU", "CHI"));
        graph.AddEdge(new Edge<string>("LA", "SEA"));

        // Week 4
        graph.AddEdge(new Edge<string>("POR", "UTA"));
        graph.AddEdge(new Edge<string>("LA", "HOU"));
        graph.AddEdge(new Edge<string>("KC", "SD"));
        graph.AddEdge(new Edge<string>("CHI", "BAY"));
        graph.AddEdge(new Edge<string>("WAS", "LOU"));
        graph.AddEdge(new Edge<string>("ORL", "SEA"));
        graph.AddEdge(new Edge<string>("NJY", "NC"));

        // Week 5
        graph.AddEdge(new Edge<string>("UTA", "CHI"));
        graph.AddEdge(new Edge<string>("SEA", "POR"));
        graph.AddEdge(new Edge<string>("NJY", "LA"));
        graph.AddEdge(new Edge<string>("SD", "LOU"));
        graph.AddEdge(new Edge<string>("WAS", "ORL"));
        graph.AddEdge(new Edge<string>("BAY", "NC"));
        graph.AddEdge(new Edge<string>("KC", "HOU"));

        // Week 6
        graph.AddEdge(new Edge<string>("POR", "NJY"));
        graph.AddEdge(new Edge<string>("ORL", "LA"));
        graph.AddEdge(new Edge<string>("HOU", "UTA"));
        graph.AddEdge(new Edge<string>("NJY", "WAS"));
        graph.AddEdge(new Edge<string>("NC", "KC"));
        graph.AddEdge(new Edge<string>("SD", "CHI"));

        // Week 7
        graph.AddEdge(new Edge<string>("LA", "WAS"));
        graph.AddEdge(new Edge<string>("LOU", "HOU"));
        graph.AddEdge(new Edge<string>("SEA", "KC"));
        graph.AddEdge(new Edge<string>("NC", "UTA"));
        graph.AddEdge(new Edge<string>("POR", "ORL"));
        graph.AddEdge(new Edge<string>("SD", "BAY"));
        
    }
    private static void Add2024SeasonData(AdjacencyGraph<string, Edge<string>> graph)
    {
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
