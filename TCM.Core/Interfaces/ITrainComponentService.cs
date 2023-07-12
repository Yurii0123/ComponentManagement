using Microsoft.AspNetCore.JsonPatch;
using TCM.Core.Dto.TrainComponentDto;

namespace TCM.Core.Interfaces
{
    public interface ITrainComponentService
    {
        Task<int> CreateComponentAsync(TrainComponentCreateRequest request);
        Task<bool> UpdateComponentAsync(TrainComponentUpdateRequest request);
        Task<bool> UpdateQantityAsync(int id, int quantity);
        Task<bool> DeleteComponentAsync(int id);
        Task<TrainComponentResponse> GetById(int id);
        Task<List<TrainComponentHierarchyResponse>> GetAllAsync(int? parentId = null, int pageIndex = 0, int pageSize = 10);
        Task<bool> CreateRelationAsync(int parentId, int childId);
        Task<bool> DeleteRelationAsync(int parentId, int childId);
    }
}
