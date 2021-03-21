using System;
using MainLibrary.Person;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class GetHashCodeEqualsTests
    {
        [Test]
        public void GetHashCodeTest()
        {
            // prepare
            var dateBirth = new DateTime(2001, 2, 17);
            var person1 = new Person("Вадим", "Осипов", "Вячеславович", dateBirth, 0339445);
            var person2 = new Person("Вадим", "Осипов", "Вячеславович", dateBirth, 0339446);

            // act
            Console.WriteLine($"person1 метод GetHascode = {person1.GetHashCode()}");
            Console.WriteLine($"person2 метод GetHascode = {person2.GetHashCode()}");
            
            // test
            Assert.False(person1.GetHashCode()==person2.GetHashCode());
        }

        [Test]
        public void EqualsTest()
        {
            // prepare
            var dateBirth = new DateTime(2001, 2, 17);
            var person1 = new Person("Вадим", "Осипов", "Вячеславович", dateBirth, 0339445);
            var person2 = new Person("Вадим", "Осипов", "Вячеславович", dateBirth, 0339445);

            // act
            Console.WriteLine(person1.Equals(person2));
            
            // test
            Assert.IsTrue(person1.Equals(person2));
        }
        
        [Test]
        public void ReverseOperatorsEqualsAndNotEquals()
        {
            // prepare
            var person1 = new Person("Вадим", "Осипов", "Вячеславович", DateTime.Now, 0);
            var person2 = new Person("Вадим", "Осипов2", "Вячеславович2", DateTime.Now, 1);
            
            // act
            Console.WriteLine("Реверс операторов \"==\" и \"!=\"");
            Console.WriteLine($"person 1 = {person1.FirstName}\nperson 2 = {person2.FirstName}");
            var areSameFirstNames = person1 == person2;
            Console.WriteLine($"person1 == person2 ? {areSameFirstNames}");
            
            // test
            Assert.IsFalse(areSameFirstNames);
        }
    }
}