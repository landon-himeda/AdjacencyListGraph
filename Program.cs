using System;

namespace AdjacentGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<char> charGraph = new Graph<char>(5);
            charGraph.AddHead(0,'A')
                .AddHead(1,'B')
                .AddHead(2,'C')
                .AddHead(3,'D')
                .AddHead(4,'E');
            charGraph.AddUndirectedEdge('A','C')
                .AddUndirectedEdge('D','E');
            charGraph.AddDirectedEdge('A', 'B')
            .AddDirectedEdge('B', 'C')
            .AddDirectedEdge('A', 'B')
            .AddDirectedEdge('D', 'A')
            .AddDirectedEdge('E', 'B');

            charGraph.BreadthFirstConnectionSearch('A', 'B');
            charGraph.BreadthFirstConnectionSearch('A', 'D');
            charGraph.BreadthFirstConnectionSearch('E', 'A');
            charGraph.BreadthFirstConnectionSearch('D', 'D');
        }
    }
}
