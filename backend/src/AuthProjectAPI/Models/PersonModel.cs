using System.ComponentModel.DataAnnotations;

namespace AuthProjectAPI.Models
{
    public class PersonModel
    {
        public PersonModel(string name, string lastName)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        }
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string CreatedAt { get; init; }
        public void ChangeName(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
