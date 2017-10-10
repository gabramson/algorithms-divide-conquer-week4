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
            Assert.AreEqual(3, vertexList.Count);
            Assert.IsTrue(vertexList.ContainsVertex(1));
            var secondList = new VertexList(vertexList);
            Assert.IsTrue(vertexList.ContainsNeighbor(1, 2));
            secondList.RemoveNeighbor(1, 2);
            Assert.IsFalse(secondList.ContainsNeighbor(1, 2));
            secondList.Remove(3);
            Assert.IsFalse(secondList.ContainsVertex(3));
        }
    }
}
