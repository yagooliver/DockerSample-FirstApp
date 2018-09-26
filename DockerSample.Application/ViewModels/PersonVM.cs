using System;

namespace DockerSample.Application.ViewModels
{
    public class PersonVm
    {
        public PersonVm() { }

        public PersonVm(Guid id, string name, string email)
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
