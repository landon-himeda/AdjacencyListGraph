using System.Collections.Generic;

namespace AdjacentGraph
{
    class Graph<T>
    {
        public int numVertices {get;set;}
        public LinkedList<T>[] AdjacencyArray {get;set;}
        public Dictionary<T,int?> ValueIndexDict {get;set;}

        public Graph(int num)
        {
            numVertices = num;
            AdjacencyArray = new LinkedList<T>[num];
            for (int i = 0; i < AdjacencyArray.Length; i++)
            {
                AdjacencyArray[i] = new LinkedList<T>();
            }
            ValueIndexDict = new Dictionary<T,int?>();
        }

        public Graph<T> AddHead(int index, T value)
        {
            AdjacencyArray[index].AddFirst(value);
            ValueIndexDict[value] = index;
            return this;
        }

        public Graph<T> AddDirectedEdge(T fromValue, T toValue)
        {
            int fromIndex = (int) ValueIndexDict[fromValue];
            int toIndex = (int) ValueIndexDict[toValue];
            AdjacencyArray[fromIndex].AddLast(AdjacencyArray[toIndex].First.Value);
            return this;
        }

        public Graph<T> AddUndirectedEdge(T firstValue, T secondValue)
        {
            int firstIndex = (int) ValueIndexDict[firstValue];
            int secondIndex = (int) ValueIndexDict[secondValue];
            AdjacencyArray[firstIndex].AddLast(AdjacencyArray[secondIndex].First.Value);
            AdjacencyArray[secondIndex].AddLast(AdjacencyArray[firstIndex].First.Value);
            return this;
        }

        public bool BreadthFirstConnectionSearch(T startValue, T endValue)
        {
            if ((ValueIndexDict[startValue] is null) || (ValueIndexDict[endValue] is null))
                return false;
            Queue<T> verticesToCheck = new Queue<T>();
            Dictionary<T,bool> checkedVertices = new Dictionary<T, bool>();
            verticesToCheck.Enqueue(startValue);
            checkedVertices[startValue] = true;
            System.Console.WriteLine($"First enqueue: {startValue}");

            while (verticesToCheck.Count > 0)
            {
                T singleVertexToCheck = verticesToCheck.Dequeue();
                System.Console.WriteLine($"Dequeuing: {singleVertexToCheck}");
                int indexToCheck = (int) ValueIndexDict[singleVertexToCheck];
                LinkedListNode<T> runner = AdjacencyArray[indexToCheck].First.Next;
                while (runner != null)
                {
                    if (runner.Value.Equals(endValue))
                    {
                        System.Console.WriteLine($"Found connection to {endValue} from vertex {singleVertexToCheck}");
                        return true;
                    }
                    if (!checkedVertices.ContainsKey(runner.Value))
                    {
                        verticesToCheck.Enqueue(runner.Value);
                        System.Console.WriteLine($"Enqueuing {runner.Value}");
                        checkedVertices[runner.Value] = true;
                    }
                    runner = runner.Next;
                }
            }
            System.Console.WriteLine($"No connection found, returning false.");
            return false;
        }
    }
}
