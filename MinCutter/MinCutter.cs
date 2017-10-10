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
            bestCrossings = 0;
            Random r = new Random(1);

            //int size = Vertices.Count;
            //List<int> orderedKeys = (List<int>)Vertices.Keys;
            //orderedKeys.Sort();
            //while (size > 2){
            //    int first = orderedKeys[r.Next(0, size - 1)];
            //    int neighbors = Vertices[first].OutNeighbors.Count;
            //    int second = Vertices[first].OutNeighbors.Keys[r.Next(0, neighbors - 1)];
            //    MergeVertices(first, second);
            //    size -= 1;
            //}
            //bestCrossings = Vertices.Keys[0].OutNeighbors.Keys[0];
            //Crossings = bestCrossings;
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
