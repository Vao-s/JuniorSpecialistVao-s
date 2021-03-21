using System.Collections.Generic;

namespace MainLibrary.Figure
{
    public class CompareSquare<T> : IComparer<T>
        where T:Figure
    {
        public int Compare(T x, T y)
        {
            if (x!.GetArea() < y!.GetArea())
                return 1;
            if (x!.GetArea() > y!.GetArea())
                return -1;
            else return 0;
        }
    }
}