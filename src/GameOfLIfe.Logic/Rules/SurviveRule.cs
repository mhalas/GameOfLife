namespace GameOfLIfe.Logic.Rules
{
    public class SurviveRule : BaseRule, ILifeRule
    {
        public bool IsCellCanBePopulated(bool[,] matrix, int rowPosition, int columnPosition)
        {
            var neighbors = GetNeighborsCount(matrix, rowPosition, columnPosition);
            var currentValue = matrix[rowPosition, columnPosition];

            return (neighbors == 2 || neighbors == 3);
        }
    }
}
