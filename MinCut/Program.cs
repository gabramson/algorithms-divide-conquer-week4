using MinCutterLib;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MinCut
{
    class Program
    {
        static void Main(string[] args)
        {
            var minCutter = new MinCutter(40000);

            Regex regex = new Regex(@"^(\d+)(\t(\d+))+");
            string line;
            using (StreamReader srStreamRdr = new StreamReader(@"kargerMinCut.txt"))
            {
                while ((line = srStreamRdr.ReadLine()) != null)
                {
                    var x = regex.Matches(line);
                    int first = int.Parse(x[0].Groups[1].Captures[0].Value);
                    for (int i = 0; i < x[0].Groups[3].Captures.Count; i += 1)
                    {
                        int second = int.Parse(x[0].Groups[3].Captures[i].Value);
                        minCutter.AddEdge(first, second);
                    }
                }
            }
            minCutter.Execute();
            Console.WriteLine(minCutter.Crossings);
            Console.ReadKey();
        }
    }
}
