namespace GameOfLIfe.Logic.Rules
{
    public class SolitudeRule : BaseRule, ILifeRule
    {
        public bool IsCellCanBePopulated(bool[,] matrix, int rowPosition, int columnPosition)
        {
            var currentValue = matrix[rowPosition, columnPosition];
            if(currentValue == false)
            {
                return true;
            }

            var neighbors = GetNeighborsCount(matrix, rowPosition, columnPosition);

            return neighbors > 1;
        }
    }
}
