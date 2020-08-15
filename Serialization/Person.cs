using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    class Person
    {
        private string name;
        private int age;
        private Gender personGender;
        private DateTime birthDate;


        public string Name { get; set; }
        public int Age { get; private set; }
        public Gender PersonGender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
