using NUnit.Framework;
using System;
using MainLibrary.Figure;

namespace TestProject1
{
    [TestFixture]
    public class OopTest
    {        
        [Test]
        public void PrintFigures()
        {           
            // prepare
            var square = new Square(10);
            var cube = new Cube(3);
            var triangle = new Triangle(3, 4);
            
            // act
            Console.WriteLine($"Квадрат со стороной {square.Length} имеет площадь {square.GetArea()}");
            Console.WriteLine($"Куб со стороной {cube.Length} имеет площадь {cube.GetArea()}");
            Console.WriteLine($"Треугольник со стороной {triangle.Length} и высотой {triangle.Height} имеет площадь {triangle.GetArea()}");
            
            // test
            Assert.NotNull(square);
        }
    }
}