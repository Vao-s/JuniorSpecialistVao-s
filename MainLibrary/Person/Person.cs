using System;
using System.Collections.Generic;

namespace MainLibrary.Person
{
    public struct Person : ICloneable
    {
        public string FirstName { get; set; }
        string SecondName  { get; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public Company Work { get; init; }
        DateTime DateBirth { get; }
        double PassportNum { get; }

        public object Clone()
        {
            var company = new Company { Name = Work.Name };
            return new Person
            {
                FirstName = FirstName,
                Age = Age,
                Work = company
            };
        }
        
        public static implicit operator Person(string str)
        {
            var words = str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return new Person{ FirstName = words[0] , LastName = words[1]};
        }

        public static explicit operator string(Person person)
        {
            var str = $"{person.FirstName} {person.LastName}";
            return str;
        }
        public Person(string firstName, string secondName, string lastName, DateTime dateBirth, double passportNum)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            DateBirth = dateBirth;
            PassportNum = passportNum;
            Age = 0;
            Work = null;
        }
        
        public static bool operator ==(Person person1, Person person2)
        {
            return person1.FirstName != person2.FirstName;
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return person1.FirstName == person2.FirstName;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Person))
            {
                return false;
            }
            var person = (Person) obj;
            return person.PassportNum == PassportNum;
        }
        public override int GetHashCode()
        {
            return (int) PassportNum;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}