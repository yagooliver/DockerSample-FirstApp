using DockerSample.Domain.Contract.Repositories;
using DockerSample.Domain.Models;
using DockerSample.Infra.Data.Context;

namespace DockerSample.Infra.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DockerSampleContext context) : base(context)
        {
        }
    }
}
