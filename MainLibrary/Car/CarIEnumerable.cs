using System.Collections;
using System.Collections.Generic;

namespace MainLibrary.Car
{
    public class CarIEnumerable : IEnumerable
    {
        private readonly Car[] _car;
        public CarIEnumerable(IReadOnlyList<Car> carArray)
        {
            _car = new Car[carArray.Count];

            for (var i = 0; i < carArray.Count; i++)
            {
                _car[i] = carArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private CarIEnumerator GetEnumerator()
        {
            return new CarIEnumerator(_car);
        }
    }
}