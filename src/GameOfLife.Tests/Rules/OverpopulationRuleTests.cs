﻿using GameOfLIfe.Logic.Rules;
using NUnit.Framework;

namespace GameOfLife.Tests.Rules
{
    [TestFixture]
    public class OverpopulationRuleTests
    {
        [TestCase(0, 0, true)]
        [TestCase(0, 1, true)]
        [TestCase(0, 2, true)]

        [TestCase(1, 0, true)]
        [TestCase(1, 1, false)]
        [TestCase(1, 2, false)]

        [TestCase(2, 0, true)]
        [TestCase(2, 1, true)]
        [TestCase(2, 2, true)]
        public void CheckCellsPopulation(int row, int column, bool expectedResult)
        {
            bool[,] matrix = new bool[,]
            {
                {true, false, true },
                {false, true, true },
                {false, true, true },
            };

            var rule = new OverpopulationRule();
            var result = rule.IsCellCanBePopulated(matrix, row, column);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
