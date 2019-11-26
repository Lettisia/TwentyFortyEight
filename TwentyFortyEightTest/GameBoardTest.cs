using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TwentyFortyEight;

namespace TwentyFortyEightTest
{
    [TestClass]
    public class GameBoardTest
    {
        [TestMethod]
        public void SlideTest()
        {
            var gb = new GameBoard();
            var result = gb.Slide(new int[] { 0, 2, 0, 4 });
            var target = new int[] { 2, 4, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 0204 to become 2400");
        }

        [TestMethod]
        public void MergeTest1()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 2, 2, 0, 0 });
            var target = new int[] { 4, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2240 to become 4400");
        }

        [TestMethod]
        public void MergeTest2()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 2, 2, 2, 2 });
            var target = new int[] { 4, 4, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2222 to become 4400");
        }

        [TestMethod]
        public void MergeTest3()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 8, 2, 4, 2});
            var target = new int[] { 8, 2, 4, 2 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8242 to become 8242");
        }

        [TestMethod]
        public void MergeTest4()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 8, 2, 2, 4 });
            var target = new int[] { 8, 4, 4, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8224 to become 8440");
        }

        [TestMethod]
        public void MergeTest5()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 8, 2, 4, 4 });
            var target = new int[] { 8, 2, 8, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8244 to become 8280");
        }

        [TestMethod]
        public void MergeTest6()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 2, 2, 4, 4 });
            var target = new int[] { 4, 8, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2284 to become 4840");
        }

        [TestMethod]
        public void MergeTest7()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 0, 0, 0, 0 });
            var target = new int[] { 0, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 0000 to become 0000");
        }

        [TestMethod]
        public void MergeTest8()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 0, 2, 0, 2 });
            var target = new int[] { 4, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 0202 to become 4000");
        }

        [TestMethod]
        public void MergeTest9()
        {
            var gb = new GameBoard();
            var result = gb.Merge(new int[] { 2, 2, 0, 2 });
            var target = new int[] { 4, 2, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2202 to become 4200");
        }

    }
}
