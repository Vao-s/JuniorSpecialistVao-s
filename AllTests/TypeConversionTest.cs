using System;
using MainLibrary.Person;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class TypeConversionTest
    {
        [Test]
        public void TypeConversion()
        {
            // prepare
            var person1 = new Person
            {
                FirstName = "Vadim",
                LastName = "Osipov"
            };

            // act
            var str = (string) person1;
            Console.WriteLine(str);

            str = "Vadim Osipov";

            var person2 = (Person) str;
            Console.WriteLine(person2.ToString());

            Console.WriteLine(str == (string) person2);
            
            Console.WriteLine(person2.Equals((Person)str));

            // test
            Assert.IsTrue(person2.Equals((Person)str));
        }
    }
}