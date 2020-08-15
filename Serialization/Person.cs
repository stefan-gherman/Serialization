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
    public class Person : IEquatable<Person>, IDeserializationCallback, ISerializable
    {
        private string _name;
        [NonSerialized]
        private int _age;
        private Gender _personGender;
        private DateTime _birthDate;
       

        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get {return _age; } private set {_age = value; } }
        public Gender PersonGender { get {return _personGender; } set {_personGender = value; } }
        public DateTime BirthDate { get {return _birthDate; } set {_birthDate = value; } }

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
            Stream stream = new FileStream(@"C:\Users\Stefan Gherman\source\repos\Serialization\Serialization\bin\Debug\netcoreapp3.1\MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public Person Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Stefan Gherman\source\repos\Serialization\Serialization\bin\Debug\netcoreapp3.1\MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.None);
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

        public Person(SerializationInfo info, StreamingContext context)
        {
            _name = (string)info.GetValue("name", typeof(string));
            _birthDate = (DateTime)info.GetValue("birthdate", typeof(DateTime));
            _personGender = (Gender)info.GetValue("gender", typeof(Gender));
        }   

        public void OnDeserialization(object sender)
        {
            CalculateAge();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", _name, typeof(string));
            info.AddValue("birthdate", _birthDate, typeof(DateTime));
            info.AddValue("gender", _personGender, typeof(Gender));
        }
    }
}
