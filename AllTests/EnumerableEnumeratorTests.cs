using System;
using MainLibrary.Car;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class EnumerableEnumeratorTests
    {
        private readonly Car[] _carArray = {
            new("BMW"),
            new("Lexus"),
            new("Toyota"),
        };
        
        [Test]
        public void PrintByForeach()
        {          
            // prepare
            var carList = new CarIEnumerable(_carArray);
            
            // act
            Console.WriteLine("foreach:");
            foreach (Car p in carList)
                Console.WriteLine($"Car: {p.CarName}");
            
            // test
            Assert.IsNotNull(carList);    
        }

        [Test]
        public void PrintByWhile()
        {
            // prepare
            var cars = _carArray.GetEnumerator();
            
            // act
            Console.WriteLine("\nwhile:");
            while (cars.MoveNext())
            {
                var p = (Car)cars.Current;
                Console.WriteLine(p!.ToString());
            }

            // test
            Assert.IsNotNull(cars);
        }
    }
}