namespace TCM.Core.Dto.TrainComponentDto
{
    public class TrainComponentCreateRequest
    {
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
    }
}
