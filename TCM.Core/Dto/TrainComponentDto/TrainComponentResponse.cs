namespace TCM.Core.Dto.TrainComponentDto
{
    public class TrainComponentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public bool CanAssignQuantity { get; set; }
    }
}
