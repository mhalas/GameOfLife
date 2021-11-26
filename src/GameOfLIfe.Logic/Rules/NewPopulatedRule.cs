namespace GameOfLIfe.Logic.Rules
{
    public class NewPopulatedRule : BaseRule, ILifeRule
    {
        public bool IsCellCanBePopulated(bool[,] matrix, int rowPosition, int columnPosition)
        {
            var neighbors = GetNeighborsCount(matrix, rowPosition, columnPosition);
            var currentValue = matrix[rowPosition, columnPosition];


            return (neighbors == 3 && currentValue == false) || currentValue == true;
        }
    }
}
