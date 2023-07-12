using System.ComponentModel.DataAnnotations;

namespace TCM.Core.Entities
{
    public class TrainComponent : BaseEntity
    {
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; set; }
        public List<TrainComponent> Parents { get; } = new();
        public List<TrainComponent> Children { get; } = new();
    }
}
