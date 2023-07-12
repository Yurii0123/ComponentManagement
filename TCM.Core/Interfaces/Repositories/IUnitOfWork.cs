using TCM.Core.Entities;

namespace TCM.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        ITrainComponentRepository TrainComponents { get; }

        Task<int> SaveAsync();

        Task Rollback();
    }
}
