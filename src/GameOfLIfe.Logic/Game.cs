using GameOfLIfe.Logic.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLIfe.Logic
{
    public class Game
    {
        private readonly int _delayInMiliseconds;

        private IEnumerable<ILifeRule> _rules;

        private bool[,] _matrix;

        public Game(int maxRows, int maxColumns, int delayInMiliseconds)
        {
            _delayInMiliseconds = delayInMiliseconds;

            _rules = new List<ILifeRule>()
            {
                new NewPopulatedRule(),
                new OverpopulationRule(),
                new SolitudeRule(),
                new SurviveRule()
            };

            _matrix = new bool[maxRows, maxColumns];
        }

        public event Action<bool[,]> OnChangedAfterTick;
        public event Action<bool[,], int> OnEnd;

        public void Start(bool[,] startingMatrix)
        {
            var isPlaying = true;
            var totalMoves = 0;

            InitializeMatrix(startingMatrix);
            OnChangedAfterTick(_matrix);

            do
            {
                var tempMatrix = _matrix.Clone() as bool[,];

                AnalyzeEveryCellByRules(tempMatrix);

                var areEqual = CheckMatrixEquality(tempMatrix);
                if (areEqual)
                {
                    isPlaying = false;
                }

                OnChangedAfterTick(_matrix);

                totalMoves++;
                Thread.Sleep(_delayInMiliseconds);
            }
            while (isPlaying);

            OnEnd(_matrix, totalMoves);
        }

        private bool CheckMatrixEquality(bool[,] tempMatrix)
        {
            for (int row = 0; row <= tempMatrix.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= tempMatrix.GetUpperBound(1); column++)
                {
                    if(_matrix[row, column] != tempMatrix[row, column])
                    {
                        return false;
                    }
                    
                }
            }

            return true;
        }

        private void AnalyzeEveryCellByRules(bool[,] tempMatrix)
        {
            for (int row = 0; row <= tempMatrix.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= tempMatrix.GetUpperBound(1); column++)
                {
                    var result = _rules.All(x => x.IsCellCanBePopulated(tempMatrix, row, column) == true);
                    _matrix[row, column] = result;
                }
            }
        }

        private void InitializeMatrix(bool[,] startingMatrix)
        {
            for (int row = 0; row <= startingMatrix.GetUpperBound(0); row++)
            {
                if (_matrix.GetUpperBound(0) < row)
                    break;

                for (int column = 0; column <= startingMatrix.GetUpperBound(1); column++)
                {
                    if (_matrix.GetUpperBound(1) < column)
                        break;

                    _matrix[row, column] = startingMatrix[row, column];
                }
            }
        }
    }
}
