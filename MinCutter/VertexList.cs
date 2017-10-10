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

        public int Count { get { return vertices.Count; } }

        public void Add(int index)
        {
            vertices.Add(index, new Vertex(index));
        }

        public void Remove(int index)
        {
            vertices.Remove(index);
        }

        public void AddNeighbor(int index, int neighbor)
        {
            vertices[index].OutNeighbors.Add(neighbor);
        }

        public void RemoveNeighbor(int index, int neighbor)
        {
            vertices[index].OutNeighbors.Remove(neighbor);
        }

        public HashSet<int> GetNeighbors(int index)
        {
            return vertices[index].OutNeighbors;
        }

        public bool ContainsVertex(int index)
        {
            return vertices.ContainsKey(index);
        }

        public bool ContainsNeighbor(int index, int neighbor)
        {
            return vertices[index].OutNeighbors.Contains(neighbor);
        }

        public Vertex this[int i]
        {
            get { return vertices[i]; }
        }
    }
}
