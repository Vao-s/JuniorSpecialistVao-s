using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MainLibrary.Person;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class DictionaryTest
    {
        private const int N = 100000;
        private static Random _random = new();
        
        [Test]
        public void SimpleDirectory()
        {
            // prepare
            Dictionary<Person, string> personDirectory = new Dictionary<Person, string>
            {
                {new Person("Вадим", "Осипов", "Вячеславович", DateTime.Now, 0), "Завод"},
                {new Person("Вадим1", "Осипов1", "Вячеславович1", DateTime.Now, 1), "Салон красоты"},
                {new Person("Вадим2", "Осипов2", "Вячеславович2", DateTime.Now, 2), "Продуктовый магазин"},
                {new Person("Вадим3", "Осипов3", "Вячеславович3", DateTime.Now, 3), "Завод"},
            };
            var firstName = "Вадим";
            var secondName = "Осипов";
            var lastName = "Вячеславович";
            var dateBirth = new DateTime(2001,2,17);
            var passportNum = 0;
            
            // act
            if (personDirectory.ContainsKey(new Person(firstName, secondName, lastName, dateBirth, passportNum)))
            {
                var workPlace = personDirectory[new Person(firstName, secondName, lastName, dateBirth, passportNum)];
                Console.WriteLine($"{firstName}, место работы: {workPlace}");
            }
            else
            {
                Console.WriteLine("Нет такого человека в базе.");
            }
            
            // test
            Assert.IsTrue(personDirectory.ContainsKey(new Person("Вадим", "Осипов", "Вячеславович", DateTime.Now, 0)));
        }

        [Test]
        public void SpeedDictionaryTest()
        {
            // prepare
            var sw = new Stopwatch();
            var persons = new Dictionary<int, string>();
            var key = "";

            // act
            CreateSortKeyRandomValueDictionary(persons);
            Console.WriteLine(persons.Count);
            sw.Start();
            for (var i = 0; i < 10; i++)
            {
                key = persons.FirstOrDefault(x => x.Key == _random.Next(0, persons.Count)).Value;
   //??         var myValue = persons[_random.Next(0, persons.Count)];
            }
            sw.Stop();
            Console.WriteLine($"Среднее время поиска среди {N} элементов: {(double)sw.ElapsedMilliseconds/10}");
            sw.Reset();
            
            // test
            Assert.IsNotNull(persons);
        }

        private static void CreateSortKeyRandomValueDictionary(Dictionary<int, string> persons)
        {
            if (persons == null) throw new ArgumentNullException(nameof(persons));
            for (var i = 0; i < N; i++)
            {
                persons.Add(i+1, GetRandomName());
            }
        }

        private static string GetRandomName()
        {
            string[] name = {
                "Азиз","Аид","Айдар","Айрат","Акакий","Аким","Алан","Александр","Алексей","Али","Алик","Алим","Алихан",
                "Алишер","Алмаз","Альберт","Амир","Амирам","Амиран","Анар","Анастасий","Анатолий","Анвар","Ангел","Андрей",
                "Анзор","Антон","Анфим","Арам"
            };
            return name[_random.Next(0,name.Length)];
        }
    }
}