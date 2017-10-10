using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCutterLib;

namespace VertexListTest
{
    [TestClass]
    public class VertexListTest
    {
        [TestMethod]
        public void TestVertexList()
        {
            var vertexList = new VertexList();
            vertexList.Add(1);
            vertexList.Add(2);
            vertexList.Add(3);
            vertexList.AddNeighbor(1, 2);
            Assert.IsTrue(vertexList.ContainsVertex(1));
            var secondList = new VertexList(vertexList);
        }
    }
}
