using System;
using System.Collections.Generic;

namespace TwentyFortyEight
{
    public class GameBoard
    {
        private const int BoardSize = 4;
        private const int StartingSquares = 2;
        private Tile[] TilesList = new Tile[BoardSize*BoardSize];
        private Tile[,] TilesXY = new Tile[BoardSize, BoardSize];
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
            // Populate Game board
            var count = 0;
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    TilesList[count] = new Tile(0);
                    TilesXY[i, j] = TilesList[count];
                }
            }
        }

        public void Initialise()
        {
            // Start with 2 random tiles. Values can be 2 or 4.
            Random random = new Random();
            for (var i = 0; i < StartingSquares; i++)
            {
                var index = random.Next(TilesList.Length);
                TilesList[index].Value = random.Next(1, 2) * 2;
            }
        }

        public void Move(Direction direction)
        {

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

        public int[] Merge(int [] start)
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
                } else
                {
                    result[position] = tiles[i] * 2;
                    Score += tiles[i] * 2;
                    i++;
                    position++;
                } 
            }
            return result;
        }
    }
}
