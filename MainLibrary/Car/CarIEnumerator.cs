using System.Collections;

namespace MainLibrary.Car
{
    public class CarIEnumerator : IEnumerator
    {
        private readonly Car[] _car;
        private int _position = -1;

        public CarIEnumerator(Car[] list)
        {
            _car = list;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _car.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;
        private Car Current => _car[_position];
    }
}