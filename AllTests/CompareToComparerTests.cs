using System;
using System.Collections.Generic;
using MainLibrary.Figure;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class CompareToComparerTests
    {
        private readonly Random _random= new();

        [Test]
        public void CompareFigures()
        {
            // prepare
            var compareSquare = new CompareSquare<Square>();
            var square = new List<Square>();

            // act
            for (var i = 0; i < 10; i++)
            {
                square.Add(new Square(_random.Next(1, 10)));
            }

            square.Sort(compareSquare);
            square.ForEach(figures => Console.WriteLine(figures.GetArea()));

            // test
            Assert.IsNotNull(square);
        }
    }
}