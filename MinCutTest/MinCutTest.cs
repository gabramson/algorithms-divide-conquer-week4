using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCutterLib;

namespace MinCutTest
{
    [TestClass]
    public class MinCutTest
    {
        [TestMethod]
        public void TestMinCutter()
        {
            var minCutter = new MinCutter();
            minCutter.AddEdge(1, 2);
            minCutter.AddEdge(1, 3);
            minCutter.AddEdge(1, 4);
            minCutter.AddEdge(1, 7);
            minCutter.AddEdge(2, 1);
            minCutter.AddEdge(2, 3);
            minCutter.AddEdge(2, 4);
            minCutter.AddEdge(3, 1);
            minCutter.AddEdge(3, 2);
            minCutter.AddEdge(3, 4);
            minCutter.AddEdge(4, 1);
            minCutter.AddEdge(4, 2);
            minCutter.AddEdge(4, 3);
            minCutter.AddEdge(4, 5);
            minCutter.AddEdge(5, 4);
            minCutter.AddEdge(5, 6);
            minCutter.AddEdge(5, 7);
            minCutter.AddEdge(5, 8);
            minCutter.AddEdge(6, 5);
            minCutter.AddEdge(6, 7);
            minCutter.AddEdge(6, 8);
            minCutter.AddEdge(7, 1);
            minCutter.AddEdge(7, 5);
            minCutter.AddEdge(7, 6);
            minCutter.AddEdge(7, 8);
            minCutter.AddEdge(8, 5);
            minCutter.AddEdge(8, 6);
            minCutter.AddEdge(8, 7);
            minCutter.Execute();
            Assert.AreEqual(2, minCutter.Crossings);
        }
    }
}
