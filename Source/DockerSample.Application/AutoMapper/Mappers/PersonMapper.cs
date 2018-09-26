using AutoMapper;
using DockerSample.Application.ViewModels;
using DockerSample.Domain.Models;

namespace DockerSample.Application.AutoMapper.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonVm>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PersonVm, Person>();
        }
    }
}
