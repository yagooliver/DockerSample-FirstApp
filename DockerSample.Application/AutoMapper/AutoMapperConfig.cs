using AutoMapper;
using DockerSample.Application.AutoMapper.Mappers;

namespace DockerSample.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new PersonMapper());
            });
        }
    }
}
