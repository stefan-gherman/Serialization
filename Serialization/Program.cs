using System;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Tim", Gender.Male, DateTime.Parse("08-02-1997"));
            p.Serialize();
        }
    }
}
