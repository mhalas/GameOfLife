using System;

namespace GameOfLIfe.Logic.Rules
{
    public abstract class BaseRule
    {
        protected int GetNeighborsCount(bool[,] matrix, int centerX, int centerY)
        {
            int neighbors = 0;

            var minRow = Math.Max(centerX - 1, matrix.GetLowerBound(0));
            var maxRow = Math.Min(centerX + 1, matrix.GetUpperBound(0));
            var minColumn = Math.Max(centerY - 1, matrix.GetLowerBound(1));
            var maxCOlumn = Math.Min(centerY + 1, matrix.GetUpperBound(1));

            for (int row = minRow; row <= maxRow; row++)
            {
                for (int column = minColumn; column <= maxCOlumn; column++)
                {
                    if (centerX == row && centerY == column)
                    {
                        continue;
                    }

                    if (matrix[row, column] == true)
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }
    }
}
