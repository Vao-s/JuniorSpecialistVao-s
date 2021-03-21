using System;

namespace MainLibrary.Figure
{
    public class Square : Figure, IComparable
    {
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
                    Console.WriteLine("Ошибка ввода данных КВ");
                }
            }
        }

        public Square(double length)
        {
            Name = "Квадрат";
            Length = length;
        }

        public override double GetArea()
        {
            return Length * Length;
        }

        public int CompareTo(object other)
        {
            return other switch
            {
                null => 1,
                Square square => square.GetArea().CompareTo(GetArea()),
                _ => throw new ArgumentException("Object is not a square")
            };
        }
    }
}