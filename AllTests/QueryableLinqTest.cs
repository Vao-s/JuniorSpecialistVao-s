using System;
using System.Linq;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class QueryableLinqTest
    {
        private readonly Random _random = new Random();
        private const int N = 100;
        private readonly int[] _array = new int[N];
        
        private readonly string[] _towns = {"Тирасполь", "Бендеры", "Григориополь", "Дубоссары", "Рыбница", "Каменка"};
        
        [Test]
        public void IsOneOfTownsStartWith()
        {
            // prepare
            var towns = _towns;
            
            // act
            var isTownExist = towns.Any(t => t.StartsWith("Т"));
            
            // test
            Console.WriteLine($"Есть ли города на букву Т? {isTownExist}");
            Assert.IsTrue(isTownExist);
        }
        
        [Test]
        public void IsAllTownsStartWith()
        {
            // prepare
            var towns = _towns;
            
            // act
            var isAllTownsStartWith = towns.All(t => t.StartsWith("T"));
            
            // test
            Console.WriteLine($"Все ли города на букву Т? {isAllTownsStartWith}");
            Assert.IsFalse(isAllTownsStartWith);
        }
        
        [Test]
        public void TeamsStartWithAndOrderBy()
        {
            // prepare
            var towns = _towns;
            
            // act
            var teamsStartWithAndOrderBy = towns.Where(t => t.ToUpper().StartsWith("Т")).OrderBy(t => t);
            
            Console.WriteLine("Выведем города на букву Т");
            foreach (var i in teamsStartWithAndOrderBy)
            {
                Console.WriteLine(i);
            }
            
            // test
            Assert.IsNotNull(teamsStartWithAndOrderBy);
        }

        [Test]
        public void TeamsEndWithAndGroupBy()
        {
            // prepare
            var towns = _towns;
            
            // act
            var teamsEndWithAndGroupBy = towns.Select(x => x.ToUpper()[x.Length-1]).GroupBy(x => x);
            foreach (var i in teamsEndWithAndGroupBy)
            {
                Console.WriteLine($"На букву {i.Key}, заканчиваются {i.Count()} города(ов)");
            }
            
            // test
            Assert.IsNotNull(teamsEndWithAndGroupBy);
        }

        [Test]
        public void MinValueArray()
        {
            // prepare
            var array = _array;
            CreateArray(array);

            // act
            var minValueArray = array.Where(t => t > 0).Min();
            Console.WriteLine($"Min > 0: {minValueArray}");
            
            // test
            Assert.IsNotNull(minValueArray);
        }

        [Test]
        public void MaxValueArray()
        {
            // prepare
            var array = _array;
            CreateArray(array);
            
            // act
            var maxValueArray = array.Where(t => t > 0).Max();
            Console.WriteLine($"Max > 0: {maxValueArray}");
            
            // test
            Assert.IsNotNull(maxValueArray);
        }

        [Test]
        public void SumArray()
        {
            // prepare
            var array = _array;
            
            // act
            var sumConcreteValue = array.Where(t => t > 0 && t < 10).Sum();
            Console.WriteLine($"Sum == 2: {sumConcreteValue}");
            
            // test
            Assert.IsNotNull(sumConcreteValue);
        }

        private void CreateArray(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = _random.Next(0, 100);
            }
        }
    }
}