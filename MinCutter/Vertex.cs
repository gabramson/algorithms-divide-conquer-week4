using System;
using System.Collections.Generic;
using System.Text;

namespace MinCutterLib
{
    public struct Vertex
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