using System;
using System.Collections.Generic;
using System.Text;

namespace MinCutterLib
{
    public class VertexList
    {
        private Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();

        public VertexList(VertexList toCopy)
        {
            foreach (var vertex in toCopy.vertices.Values)
            {
                this.Add(vertex.Index);
                foreach (var neighbor in vertex.OutNeighbors)
                {
                    this.AddNeighbor(vertex.Index, neighbor);
                }
            }
        }

        public VertexList()
        {

        }

        public void Add(int index)
        {
            vertices.Add(index, new Vertex(index));
        }

        public void AddNeighbor(int start, int end)
        {
            vertices[start].OutNeighbors.Add(end);
        }

        public bool ContainsVertex(int index)
        {
            return vertices.ContainsKey(index);
        }

        public Vertex this[int i]
        {
            get { return vertices[i]; }
        }
    }
}
