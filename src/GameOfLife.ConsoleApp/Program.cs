using GameOfLIfe.Logic;
using System;

namespace GameOfLife.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] startingMatrix = new bool[,]
            {
                { false, true, false },
                { false, false, true },
                { true, true, true}
            };

            Console.WriteLine("Game of life, invented by John Conway.");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            Game game = new Game(20, 20, 1000);
            game.OnChangedAfterTick += Game_OnChangedAfterTick;
            game.OnEnd += Game_OnEnd;
            game.Start(startingMatrix);
        }

        private static void Game_OnEnd(bool[,] matrix, int totalMoves)
        {
            Console.WriteLine("No more changes. Total moves: {0}", totalMoves);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void Game_OnChangedAfterTick(bool[,] matrix)
        {
            Console.Clear();

            for (int row = 0; row < matrix.GetUpperBound(0); row++)
            {
                for (int column = 0; column < matrix.GetUpperBound(1); column++)
                {
                    var value = matrix[row, column];

                    if (value)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
