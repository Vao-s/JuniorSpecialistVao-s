using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class ListTest
    {
        private const int N = 1000000;
        private readonly Random _random = new();
        
        [Test]
        public void SpeedListTest()
        {
            // prepare
            var sw = new Stopwatch();
            var persons = new List<int>();
            long n = 0;
            
            //act
            CreateRandomValueList(persons);
            Console.WriteLine(persons.Count);
            sw.Start();
            for (var i = 0; i < 10; i++)
            {
                foreach (var person in persons)
                {
                    if (person == _random.Next(0, persons.Count))
                    {
                        var k = person;
                        break;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Среднее время поиска среди {N} элементов: {(double)sw.ElapsedMilliseconds/10}");
            sw.Reset();
            
            // test
            Assert.IsNotNull(persons);
        }
        private static void CreateRandomValueList(List<int> person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));
            for (var i = 0; i < N; i++)
            {
                person.Add(i);
            }
        }
    }
}