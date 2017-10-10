using System;
using System.Collections.Generic;

namespace MinCutterLib
{
    public class MinCutter
    {
        private VertexList vertexList = new VertexList();
        private EdgeList edgeList = new EdgeList();
        private int iterations;

        public MinCutter(int iterations)
        {
            this.iterations = iterations;
        }

        public int Crossings { private set; get; }

        public void AddEdge(int first, int second)
        {
            if (!vertexList.ContainsVertex(first))
            {
                vertexList.Add(first);
            }
            if (!vertexList.ContainsVertex(second))
            {
                vertexList.Add(second);
            }
            if (!vertexList.ContainsNeighbor(first, second)){
                vertexList.AddNeighbor(first, second);
                vertexList.AddNeighbor(second, first);
                edgeList.Add(first, second, 1);
            }
        }

        public void Execute()
        {
            var bestCrossings = int.MaxValue;
            var nextCrossings = int.MaxValue;

            for (int i = 1; i <=iterations; i+=1) {
                nextCrossings = SingleIteration(vertexList, edgeList, i);
                if (nextCrossings < bestCrossings) {
                    bestCrossings = nextCrossings;
                }
            }
            Crossings = bestCrossings;
        }

        private int  SingleIteration(VertexList inputVertexList, EdgeList inputEdgeList, int seed)
        {
            var myVertexList = new VertexList(vertexList);
            var myEdgeList = new EdgeList(inputEdgeList);
            Random r = new Random(seed);

            while (myVertexList.Count > 2)
            {
                var edge = myEdgeList.SelectByIndex(r.Next(0, myEdgeList.Total - 1));
                int first = edge.start;
                int second = edge.end;
                MergeVertices(first, second, myVertexList, myEdgeList);
            }
            return myEdgeList.Total;
        }

        private void MergeVertices(int first, int second, VertexList vertexList, EdgeList edgeList)
        {
            var secondNeighbors = new HashSet<int>(vertexList.GetNeighbors(second));
            foreach (var index in secondNeighbors){
                if (index != first)
                {
                    if (vertexList.ContainsNeighbor(first, index))
                    {
                        edgeList.Update(first, index, edgeList.GetFrequency(first, index) + edgeList.GetFrequency(second, index));
                        edgeList.Remove(second, index);
                        vertexList.RemoveNeighbor(second, index);
                        vertexList.RemoveNeighbor(index, second);
                    }
                    else
                    {
                        vertexList.AddNeighbor(first, index);
                        vertexList.AddNeighbor(index, first);
                        edgeList.Add(first, index, edgeList.GetFrequency(second, index));
                        edgeList.Remove(second, index);
                        vertexList.RemoveNeighbor(second, index);
                        vertexList.RemoveNeighbor(index, second);
                    }
                }
            }
            edgeList.Remove(first, second);
            vertexList.RemoveNeighbor(first, second);
            vertexList.RemoveNeighbor(second, first);
            vertexList.Remove(second);
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
