using System;
using System.Threading.Tasks;

namespace DockerSample.Domain.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        Task<bool> CommitAsync();
    }
}
