using System;

namespace DockerSample.Domain.Models
{
    public class Person
    {
        public Person() {}

        public Person(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
