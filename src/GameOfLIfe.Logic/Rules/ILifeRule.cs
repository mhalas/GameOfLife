namespace GameOfLIfe.Logic.Rules
{
    public interface ILifeRule
    {
        bool IsCellCanBePopulated(bool[,] matrix, int rowPosition, int columnPosition);
    }
}
