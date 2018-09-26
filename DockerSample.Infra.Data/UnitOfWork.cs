using System.Threading.Tasks;
using DockerSample.Domain.Contract;
using DockerSample.Infra.Data.Context;

namespace DockerSample.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DockerSampleContext _context;

        private bool _disposed;

        public UnitOfWork(DockerSampleContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public bool Commit() => _context.SaveChanges() > 0;

        public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;

        protected virtual void Dispose(bool dispoing)
        {
            if (_disposed) return;

            if(dispoing)
                _context?.Dispose();

            _disposed = true;
        }

    }
}
