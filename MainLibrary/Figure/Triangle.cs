using System;

namespace MainLibrary.Figure
{
    public class Triangle : Figure
    {
        private readonly double _height;
        private readonly double _length;
        public double Length
        {
            get => _length;
            private init
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных");
                }
            }
        }
        public double Height
        {
            get => _height;
            private init
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных Т");
                }
            }
        }
        public Triangle(double length, double height)
        {
            Name = "Треугольник";
            Length = length;
            Height = height;
        }

        public override double GetArea()
        {
            return 0.5 * Height * Length;
        }
    }
}