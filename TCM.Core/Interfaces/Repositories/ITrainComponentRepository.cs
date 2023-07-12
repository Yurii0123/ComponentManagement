using TCM.Core.Entities;

namespace TCM.Core.Interfaces.Repositories
{

    public interface ITrainComponentRepository : IGenericRepository<TrainComponent>
    {
        IEnumerable<TrainComponent> GetComponentsWithHierarchy(int? rootComponentId);
        Task<bool> CheckDependencyExists(int parentId, int childId);
        Task<bool> CheckCircularDependency(int parentId, int childId);
    }
}
