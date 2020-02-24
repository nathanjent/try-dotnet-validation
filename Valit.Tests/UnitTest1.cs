using NUnit.Framework;
using Valit;

namespace Valit.Tests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
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
            var person = new Person
            {
                Name = "A",
                Age = 12,
            };

            var result = ValitRules<Person>
                .Create()
                .Ensure(
                        m => m.Name,
                        _=>_.Required()
                        .MinLength(2))
                .Ensure(m => m.Age,
                        _=>_
                        .IsGreaterThan(16))
                .For(person)
                .Validate();
            Assert.False(result.Succeeded);
        }
    }
}
