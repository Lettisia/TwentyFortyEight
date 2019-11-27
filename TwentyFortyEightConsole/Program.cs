using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFortyEight;

namespace TwentyFortyEightConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gb = new GameBoard();
            gb.Initialise();


            gb.TilesXY[0, 0] = 67;
            Console.WriteLine("tiles 0,0 = " + gb.TilesXY[0, 0]);

            MoveLeftTest();

            Console.ReadLine();
        }

        public static void MoveLeftTest()
        {
            var gb = new GameBoard();
            gb.Initialise();
            var before = new int[,]
            { { 0, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 2, 0,  4,  512 },
              { 0, 0,  0, 1024 } };

            Console.WriteLine(before.PrintAsString());

            Console.WriteLine("Before: ");
            foreach (var tile in before)
            {
                Console.Write(tile);
            }
            Console.WriteLine();

            gb.TilesXY = before;
            gb.Move(GameBoard.Direction.Up);
            var after = gb.TilesXY;
            var expected = new int[,]
            { { 2, 8,  8,  128 },
              { 0, 4, 32,  256 },
              { 0, 0,  4,  512 },
              { 0, 0,  0, 1024 } };

            Console.WriteLine("After: ");
            foreach (var tile in after)
            {
                Console.Write(tile);
            }
            Console.WriteLine();

            Console.WriteLine("Expected: ");
            foreach (var tile in after)
            {
                Console.Write(tile);
            }
            Console.WriteLine();
        }

    }
}
