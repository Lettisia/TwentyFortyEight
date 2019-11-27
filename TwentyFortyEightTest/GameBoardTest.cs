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
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 2, 2, 0, 0 });
            var target = new int[] { 4, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2240 to become 4400");
            Assert.AreEqual(gb.Score, initialScore + 4, "Expect score to increase by 4");
        }

        [TestMethod]
        public void MergeTest2()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 2, 2, 2, 2 });
            var target = new int[] { 4, 4, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2222 to become 4400");
            Assert.AreEqual(gb.Score, initialScore + 8, "Expect score to increase by 8");
        }

        [TestMethod]
        public void MergeTest3()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 8, 2, 4, 2 });
            var target = new int[] { 8, 2, 4, 2 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8242 to become 8242");
            Assert.AreEqual(gb.Score, initialScore, "Expect score to be unchanged");
        }

        [TestMethod]
        public void MergeTest4()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 8, 2, 2, 4 });
            var target = new int[] { 8, 4, 4, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8224 to become 8440");
            Assert.AreEqual(gb.Score, initialScore + 4, "Expect score to increase by 4");
        }

        [TestMethod]
        public void MergeTest5()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 8, 2, 4, 4 });
            var target = new int[] { 8, 2, 8, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 8244 to become 8280");
            Assert.AreEqual(gb.Score, initialScore + 8, "Expect score to increase by 8");
        }

        [TestMethod]
        public void MergeTest6()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 2, 2, 4, 4 });
            var target = new int[] { 4, 8, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2284 to become 4840");
            Assert.AreEqual(gb.Score, initialScore + 12, "Expect score to increase by 12");
        }

        [TestMethod]
        public void MergeTest7()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 0, 0, 0, 0 });
            var target = new int[] { 0, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 0000 to become 0000");
            Assert.AreEqual(gb.Score, initialScore, "Expect score to be unchanged");
        }

        [TestMethod]
        public void MergeTest8()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 0, 2, 0, 2 });
            var target = new int[] { 4, 0, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 0202 to become 4000");
            Assert.AreEqual(gb.Score, initialScore + 4, "Expect score to increase by 4");

        }

        [TestMethod]
        public void MergeTest9()
        {
            var gb = new GameBoard();
            var initialScore = gb.Score;
            var result = gb.Merge(new int[] { 2, 2, 0, 2 });
            var target = new int[] { 4, 2, 0, 0 };
            var query = result.Where((b, i) => b == target[i]);
            Assert.AreEqual(result.Length, target.Length, "I expect equal length");
            Assert.AreEqual(result.Length, query.Count(), "I expect 2202 to become 4200");
            Assert.AreEqual(gb.Score, initialScore + 4, "Expect score to increase by 4");
        }

        [TestMethod]
        public void InitialiseTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var count = 0;
            //There should be 2 non-zero tiles with values 2 or 4
            foreach (var tile in gb.TilesXY)
            {
                if (tile != 0)
                {
                    count++;
                    Assert.IsTrue(tile == 2 || tile == 4, "Expected 2 or 4");
                }
            }
            Assert.AreEqual(count, 2, "Expect 2 non-zero squares");
        }

        [TestMethod]
        public void AddTileTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var count = 0;
            gb.AddRandomTileToEmptySpace();
            //There should be 3 non-zero tiles
            foreach (var tile in gb.TilesXY)
            {
                if (tile != 0)
                {
                    count++;
                }
            }
            Assert.AreEqual(count, 3, "Expect 3 non-zero squares");
        }

        [TestMethod]
        public void MoveRightTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var before = new int[,]
            { { 0, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 2, 0,  4,  512 },
              { 0, 0,  0, 1024 } };
            gb.TilesXY = before;
            gb.Move(GameBoard.Direction.Right);
            var after = gb.TilesXY;
            var expected = new int[,]
            { { 0, 0, 16,  128 },
              { 0, 4, 32,  256 },
              { 0, 2,  4,  512 },
              { 0, 0,  0, 1024 } };

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Assert.AreEqual(after[i, j], expected[i, j]);
                }
            }
        }

        [TestMethod]
        public void MoveLeftTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var before = new int[,]
            { { 0, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 2, 0,  4,  512 },
              { 0, 0,  0, 1024 } };
            gb.TilesXY = before;
            gb.Move(GameBoard.Direction.Left);
            var after = gb.TilesXY;
            var expected = new int[,]
            { {   16, 128,   0, 0 },
              {    4,  32, 256, 0 },
              {    2,   4, 512, 0 },
              { 1024,   0,   0, 0 } };

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Assert.AreEqual(after[i, j], expected[i, j]);
                }
            }
        }

        [TestMethod]
        public void MoveUpTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var before = new int[,]
            { { 0, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 2, 0,  4,  512 },
              { 0, 0,  0, 1024 } };
            gb.TilesXY = before;
            gb.Move(GameBoard.Direction.Up);
            var after = gb.TilesXY;
            var expected = new int[,]
            { { 2, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 0, 0,  4,  512 },
              { 0, 0,  0, 1024 } };

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Assert.AreEqual(after[i, j], after[i, j]);
                }
            }
        }

        [TestMethod]
        public void MoveDownTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var before = new int[,]
            { { 0, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 2, 0,  4,  512 },
              { 0, 0,  0, 1024 } };
            gb.TilesXY = before;
            gb.Move(GameBoard.Direction.Down);
            var after = gb.TilesXY;
            var expected = new int[,]
            { { 0, 0,  0,  128 },
              { 0, 0,  8,  256 },
              { 0, 8, 32,  512 },
              { 2, 4,  4, 1024 } };

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Assert.AreEqual(after[i, j], expected[i, j]);
                }
            }
        }

    }
}
