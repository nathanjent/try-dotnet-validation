using System;
using NUnit.Framework;
using Dawn;

namespace Guard.Tests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name)
        {
            Dawn.Guard
            .Argument(() => name)
            .NotNull()
            .NotEmpty();
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var person = new Person(null);
            });
        }
    }
}
