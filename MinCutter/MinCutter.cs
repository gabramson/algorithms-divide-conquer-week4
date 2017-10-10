using System;
using System.Collections.Generic;

namespace MinCutterLib
{
    public class MinCutter
    {
        private Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();
        private EdgeList edgeList = new EdgeList();
        public int Crossings { private set; get; }

        public void AddEdge(int first, int second)
        {
            if (!vertices.ContainsKey(first))
            {
                vertices.Add(first, new Vertex(first));
            }
            if (!vertices.ContainsKey(second))
            {
                vertices.Add(second, new Vertex(second));
            }
            if (!vertices[first].OutNeighbors.Contains(second)){
                vertices[first].OutNeighbors.Add(second);
                vertices[second].OutNeighbors.Add(first);
                edgeList.Add(first, second, 1);
            }
        }

        public void Execute()
        {
            var bestCrossings = int.MaxValue;
            var nextCrossings = int.MaxValue;

            for (int i = 1; i <=10; i+=1) {
                nextCrossings = SingleIteration(vertices, edgeList, i);
                if (nextCrossings < bestCrossings) {
                    bestCrossings = nextCrossings;
                }
            }
            Crossings = bestCrossings;
        }

        private int  SingleIteration(Dictionary<int, Vertex> inputVertices, EdgeList inputEdgeList, int seed)
        {
            var myVertices = new Dictionary<int, Vertex>(inputVertices);
            var myEdgeList = new EdgeList(inputEdgeList);
            Random r = new Random(seed);

            while (myVertices.Count > 2)
            {
                var edge = myEdgeList.SelectByIndex(r.Next(0, myEdgeList.Total - 1));
                int first = edge.start;
                int second = edge.end;
                MergeVertices(first, second, myVertices, myEdgeList);
            }
            return edgeList.Total;
        }

        private void MergeVertices(int first, int second, Dictionary<int, Vertex> vertices, EdgeList edgeList)
        {
            foreach(var index in vertices[second].OutNeighbors){
                if (index != first)
                {
                    if (vertices[first].OutNeighbors.Contains(index))
                    {
                        edgeList.Update(first, index, edgeList.GetFrequency(first, index) + edgeList.GetFrequency(second, index));
                        edgeList.Remove(second, index);
                        vertices[index].OutNeighbors.Remove(second);
                    }
                    else
                    {
                        vertices[first].OutNeighbors.Add(index);
                        vertices[index].OutNeighbors.Add(first);
                        edgeList.Add(first, index, edgeList.GetFrequency(second, index));
                        edgeList.Remove(second, index);
                        vertices[index].OutNeighbors.Remove(second);
                    }
                }
            }
            vertices[first].OutNeighbors.Remove(second);
            edgeList.Remove(first, second);
            vertices.Remove(second);
        }

        private struct Vertex
        {
            public Vertex(int index)
            {
                Index = index;
                OutNeighbors = new HashSet<int>();
            }

            public int Index { private set; get; }
            public HashSet<int> OutNeighbors { set; get; }
        }


    }
}
