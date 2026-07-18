using AuthProjectAPI.Models;

namespace TestPersonRoutes
{
    public class TestPersonModel
    {
        [Fact]
        public void ShouldCreateNewPerson()
        {
            var person = new PersonModel("John", "Doe");

            Assert.Equal("John", person.Name);
            Assert.Equal("Doe", person.LastName);
        }

        [Fact]
        public void ShouldChangePersonName()
        {
            var person = new PersonModel("John", "Doe");
            person.ChangeName("Jane", "Smith");
            Assert.Equal("Jane", person.Name);
            Assert.Equal("Smith", person.LastName);
        }

        [Fact]
        public void ShouldHaveUniqueId()
        {
            var person1 = new PersonModel("John", "Doe");
            var person2 = new PersonModel("Jane", "Smith");
            Assert.NotEqual(person1.Id, person2.Id);
        }
    }
}
