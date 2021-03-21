using System;
using MainLibrary.Person;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class CloneableTest
    {
        [Test]
        public void CloneClass()
        {
            // prepare
            var p1 = new Person
            {
                FirstName = "Ben", Age = 23, Work = new Company {Name = "Microsoft"}
            };

            // act
            var p2 = (Person) p1.Clone();

            Console.WriteLine($"{p1.FirstName}, {p1.Age}, {p1.Work.Name}");
            p2.Work.Name = "Google";
            p2.FirstName = "Beef";
            
            Console.WriteLine($"\n{p1.FirstName}, {p1.Age}, {p1.Work.Name}");
            Console.WriteLine($"{p2.FirstName}, {p2.Age}, {p2.Work.Name}");

            // test
            Assert.AreEqual(p1,p2);
        }
    }


}


