using NUnit.Framework;
using Serialization;
using System;

namespace SerializerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalculateAgeForPerson()
        {
            //arrange
            Person p = new Person("Tim", Gender.Male, DateTime.Parse("08-02-1997"));
            int expectedAge = 23;
            //act
            int personAge = p.Age;

            //assert
            Assert.AreEqual(expectedAge, personAge);
        }


        [Test]
        public void TestToStringMethodForPerson()
        {
            //arrange
            Person p = new Person("Tim", Gender.Male, DateTime.Parse("08-02-1997"));
            string expectedString = $"Tim is a Male born on 08.02.1997 00:00:00 (23 years old).";
            //act

            string currentString = p.ToString();

            //assert
            Assert.AreEqual(expectedString, currentString);
            
        }
    }
}