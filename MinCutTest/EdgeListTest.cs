using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCutterLib;

namespace EdgeListTest
{
    [TestClass]
    public class EdgeListTest
    {
        [TestMethod]
        public void TestEdgeList()
        {
            var edgeList = new EdgeList();
            edgeList.Add(1, 2, 5);
            edgeList.Add(1, 4, 3);
            edgeList.Add(2, 3, 3);
            Assert.AreEqual(11, edgeList.Total);
            Assert.IsTrue(edgeList.Contains(1, 2));
            Assert.IsTrue(edgeList.Contains(4, 1));
            Assert.IsFalse(edgeList.Contains(3, 4));
            Assert.AreEqual(5, edgeList.GetFrequency(1, 2));
            Assert.AreEqual(3, edgeList.GetFrequency(4, 1));
            Assert.AreEqual(2, edgeList.SelectByIndex(4).end);
            Assert.AreEqual(4, edgeList.SelectByIndex(5).end);
            Assert.AreEqual(3, edgeList.SelectByIndex(8).end);
            edgeList.Remove(4, 1);
            Assert.AreEqual(8, edgeList.Total);
            Assert.AreEqual(3, edgeList.SelectByIndex(5).end);
            edgeList.Update(1, 2, 4);
            Assert.AreEqual(7, edgeList.Total);
            Assert.AreEqual(3, edgeList.SelectByIndex(4).end);
            var secondList = new EdgeList(edgeList);
            Assert.AreEqual(7, secondList.Total);
            Assert.AreEqual(3, secondList.SelectByIndex(4).end);
        }
    }
}
