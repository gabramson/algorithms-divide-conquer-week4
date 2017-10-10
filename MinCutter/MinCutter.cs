using System;
using System.Collections.Generic;

namespace MinCutterLib
{
    public class MinCutter
    {
        private Dictionary<int, Vertex> Vertices = new Dictionary<int, Vertex>();
        private int bestCrossings = int.MaxValue;
        public int Crossings { private set; get; }

        public void AddEdge(int first, int second)
        {
            if (!Vertices.ContainsKey(first))
            {
                Vertices.Add(first, new Vertex(first));
            }
            if (!Vertices.ContainsKey(second))
            {
                Vertices.Add(second, new Vertex(second));
            }
            if (!Vertices[first].OutNeighbors.ContainsKey(second)){
                Vertices[first].OutNeighbors.Add(second, 1);
                Vertices[second].OutNeighbors.Add(first, 1);
            }
        }

        public void Execute()
        {
            Crossings = 0;

            MergeVertices(1, 2);
        }

        private void MergeVertices(int first, int second)
        {
            foreach(var index in Vertices[second].OutNeighbors.Keys){
                if (index != first)
                {
                    if (Vertices[first].OutNeighbors.ContainsKey(index))
                    {
                        Vertices[first].OutNeighbors[index] += Vertices[first].OutNeighbors[index];
                    }
                }
            }
            Vertices[first].OutNeighbors.Remove(second);
            Vertices.Remove(second);
        }

        private struct Vertex
        {
            public Vertex(int index)
            {
                Index = index;
                OutNeighbors = new Dictionary<int , int>();
            }

            public int Index { private set; get; }
            public Dictionary<int , int > OutNeighbors { set; get; }
        }
    }
}
