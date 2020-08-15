using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Serialization
{
    [Serializable]
    public class Person : IEquatable<Person>
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

        public Person()
        {

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

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Stefan Gherman\source\repos\Serialization\Serialization\bin\Debug\netcoreapp3.1\MyFile.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public Person Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Stefan Gherman\source\repos\Serialization\Serialization\bin\Debug\netcoreapp3.1\MyFile.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            Person p = (Person)formatter.Deserialize(stream);
            stream.Close();
            return p;
        }

      

        public int GetHashCode(object obj)
        {
            return this.GetHashCode();
        }

        public bool Equals([AllowNull] Person other)
        {
            return other.Name == Name && other.PersonGender == PersonGender && other.BirthDate == BirthDate;
    
            
        }
    }
}
