using System;
using System.Collections.Generic;
using System.Text;

namespace MinCutterLib
{
    public class EdgeList
    {
        private SortedList<(int, int), Edge> edgeList = new SortedList<(int, int), Edge>();

        public EdgeList(EdgeList toCopy)
        {
            foreach (var edge in toCopy.edgeList.Values)
            {
                this.Add(edge.start, edge.end, edge.frequency);
            }
        }

        public EdgeList()
        {

        }

        public int Total { private set; get; } = 0;

        public void Add(int start, int end, int frequency)
        {
            if (start < end)
            {
                edgeList.Add((start, end), new Edge(start, end, frequency));
            }
            else
            {
                edgeList.Add((end, start), new Edge(end, start, frequency));
            }
            Total += frequency;
        }

        public void Remove(int start, int end)
        {
            int frequency;
            if (start < end)
            {
                frequency = edgeList[(start, end)].frequency;
                edgeList.Remove((start, end));
            }
            else
            {
                frequency = edgeList[(end, start)].frequency;
                edgeList.Remove((end, start));
            }
            Total -= frequency;
        }

        public void Update(int start, int end, int frequency)
        {
            int frequencyDiff;
            if (start < end)
            {
                frequencyDiff = edgeList[(start, end)].frequency - frequency;
                edgeList[(start, end)] = new Edge(start, end, frequency);
            }
            else
            {
                frequencyDiff = edgeList[(end, start)].frequency - frequency;
                edgeList[(end, start)] = new Edge(start, end, frequency);
            }
            Total -= frequencyDiff;
        }

        public bool Contains(int start, int end)
        {
            if (start < end)
            {
                return edgeList.ContainsKey((start, end));
            }
            else
            {
                return edgeList.ContainsKey((end, start));
            }
        }

        public int GetFrequency(int start, int end)
        {
            if (start < end)
            {
                return edgeList[(start, end)].frequency;
            }
            else
            {
                return edgeList[(end, start)].frequency;
            }
        }

        public Edge SelectByIndex(int index)
        {
            int cumFrequency = 0;
            foreach(var edge in edgeList.Values)
            {
                cumFrequency += edge.frequency;
                if (cumFrequency > index)
                {
                    return edge;
                }
            }
            throw(new Exception("Not found"));
        }
    }
}
