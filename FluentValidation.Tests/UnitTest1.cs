using FluentValidation;
using NUnit.Framework;

namespace FluentValidation.Tests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonValidator
        : AbstractValidator<Person>
    {
        public PersonValidator()
        {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .Length(2);
                RuleFor(x => x.Age)
                    .GreaterThan(16);
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
            var validator = new PersonValidator();
            var person = new Person
            {
                Name = "A",
                Age = 12,
            };

            var result = validator.Validate(person);

            Assert.False(result.IsValid);

            Assert.False(result.Errors.Count == 0);
        }
    }
}
