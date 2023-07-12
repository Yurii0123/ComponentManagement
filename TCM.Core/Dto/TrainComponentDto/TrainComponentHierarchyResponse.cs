using TCM.Core.Entities;

namespace TCM.Core.Dto.TrainComponentDto
{
    public class TrainComponentHierarchyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        public List<TrainComponentHierarchyResponse> Children { get; } = new();
    }
}
