using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyFortyEight
{
    public class GameBoard
    {
        private const int BoardSize = 4;
        public int[,] TilesXY { get; set; }
        public int Score { get; set; }
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down,
        }

        public GameBoard()
        {
            TilesXY = new int[BoardSize, BoardSize];
        }

        public int[,] Initialise()
        {
            // Start with 2 random tiles. Values can be 2 or 4.
            var random = new Random();
            var firstx = random.Next(TilesXY.GetLength(0));
            var firsty = random.Next(TilesXY.GetLength(1));
            var secondx = random.Next(TilesXY.GetLength(0));
            var secondy = random.Next(TilesXY.GetLength(1));
            while (secondx == firstx && secondy == firsty)
            {
                secondx = random.Next(TilesXY.GetLength(0));
                secondy = random.Next(TilesXY.GetLength(1));
            }
            Console.WriteLine("firstx = {0}, firsty = {1}, secondx = {2}, secondy = {3}", 
                firstx, firsty, secondx, secondy);

            TilesXY[firstx, firsty] = (random.Next(2) + 1) * 2;
            TilesXY[secondx, secondy] = (random.Next(2) + 1) * 2;
            foreach (var tile in TilesXY)
            {
                Console.Write(tile);
            }
            Console.WriteLine();

            return TilesXY;
        }

        public bool IsTwentyFortyEight()
        {
            foreach (var tile in TilesXY)
            {
                if (tile == 2048)
                    return true;
            }
            return false;
        }

        public bool IsGameOver()
        {
            foreach (var tile in TilesXY)
            {
                if (tile == 0)
                    return false;
            }
            return true;
        }

        // Adds a 2 or a 4 to an empty space 
        public int[,] AddRandomTileToEmptySpace()
        {
            var random = new Random();
            var x = random.Next(TilesXY.GetLength(0));
            var y = random.Next(TilesXY.GetLength(1));
            while (TilesXY[x,y] != 0)
            {
                x = random.Next(TilesXY.GetLength(0));
                y = random.Next(TilesXY.GetLength(1));
            }
            TilesXY[x,y] = (random.Next(2) + 1) * 2;
            return TilesXY;
        }

        public int[,] Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    for (var i = 0; i < TilesXY.GetLength(0); i++)
                    {
                        var row = new int[4];
                        for (var j = 0; j < TilesXY.GetLength(1); j++)
                        {
                            row[j] = TilesXY[i, j];
                        }
                        row = Merge(row);
                        for (var j = 0; j < TilesXY.GetLength(1); j++)
                        {
                            TilesXY[i, j] = row[j];
                        }
                    }
                    break;
                case Direction.Right:
                    for (var i = 0; i < TilesXY.GetLength(0); i++)
                    {
                        var row = new int[4];
                        for (var j = TilesXY.GetLength(1) - 1; j >= 0; j--)
                        {
                            row[TilesXY.GetLength(1) - j - 1] = TilesXY[i, j];
                        }
                        row = Merge(row);
                        for (var j = TilesXY.GetLength(1) - 1; j >= 0 ; j--)
                        {
                            TilesXY[i, j] = row[TilesXY.GetLength(1) - 1 - j];
                        }
                    }
                    break;
                case Direction.Up:
                    for (var i = 0; i < TilesXY.GetLength(1); i++)
                    {
                        var row = new int[4];
                        for (var j = 0; j < TilesXY.GetLength(0); j++)
                        {
                            row[j] = TilesXY[j, i];
                        }
                        row = Merge(row);
                        for (var j = 0; j < TilesXY.GetLength(0); j++)
                        {
                            TilesXY[j, i] = row[j];
                        }
                    }
                    break;
                case Direction.Down:
                    for (var i = 0; i < TilesXY.GetLength(1); i++)
                    {
                        var row = new int[4];
                        for (var j = TilesXY.GetLength(0) - 1; j >= 0; j--)
                        {
                            row[TilesXY.GetLength(0) - j - 1] = TilesXY[j, i];
                        }
                        row = Merge(row);
                        for (var j = TilesXY.GetLength(0) - 1; j >= 0; j--)
                        {
                            TilesXY[j, i] = row[TilesXY.GetLength(0) - 1 - j];
                        }
                    }
                    break;
                default:
                    break;
            }
            return TilesXY;
        }

        // Slide a row/column of tiles and add tiles
        // Input: four values which will be "slid" towards the 0 index
        public int[] Slide(int[] tiles)
        {
            var result = new int[BoardSize];
            var position = 0;
            // Slide
            foreach (var tile in tiles)
            {
                if (tile != 0)
                {
                    result[position] = tile;
                    position++;
                }
            }
            return result;
        }

        public int[] Merge(int[] start)
        {
            var tiles = Slide(start);
            var result = new int[BoardSize];
            var position = 0;
            for (var i = 0; (i < BoardSize) && (tiles[i] != 0); i++)
            {
                if (i == BoardSize - 1 || tiles[i] != tiles[i + 1])
                {
                    result[position] = tiles[i];
                    position++;
                }
                else
                {
                    result[position] = tiles[i] * 2;
                    Score += tiles[i] * 2;
                    i++;
                    position++;
                }
            }
            return result;
        }

        public static Tile[,] IntArrayToTileArray(int[,] values)
        {
            var tiles = new Tile[values.GetLength(0), values.GetLength(1)];
            for (var i = 0; i < values.GetLength(0); i++)
            {
                for (var j = 0; j < values.GetLength(1); j++)
                {
                    tiles[i, j] = new Tile(values[i, j]);
                }
            }
            return tiles;
        }

        public static int[,] TileArrayToIntArray(Tile[,] tiles)
        {
            var values = new int[tiles.GetLength(0), tiles.GetLength(1)];
            for (var i = 0; i < tiles.GetLength(0); i++)
            {
                for (var j = 0; j < tiles.GetLength(1); j++)
                {
                    values[i, j] = tiles[i, j].Value;
                }
            }
            return values;
        }
    }
}
