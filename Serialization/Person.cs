using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    public class Person
    {
       
       

        public string Name { get; set; }
        public int Age { get; private set; }
        public Gender PersonGender { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string name, Gender gender, DateTime birthDate)
        {
            Name = name;
            PersonGender = gender;
            BirthDate = birthDate;
            CalculateAge();
        }
        private void CalculateAge()
        {
            Age = DateTime.Now.Year - BirthDate.Year;
            if (Age < 0 )
            {
                Age = 0;
            }
           
        }

        public override string ToString()
        {
            return $"{Name} is a {PersonGender} born on {BirthDate} ({Age} years old).";
        }
    }
}
