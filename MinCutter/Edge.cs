using System;
using System.Collections.Generic;
using System.Text;

namespace MinCutterLib
{
    public struct Edge
    {
        public int start;
        public int end;
        public int frequency;

        public Edge(int start, int end, int frequency)
        {
            this.start = start;
            this.end = end;
            this.frequency = frequency;
        }
    }
}
