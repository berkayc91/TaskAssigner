using Core.Entity.Abstract;

namespace Entity.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int TotalScore { get; set; } = 0;
        public byte ActiveTaskId { get; set; }
    }
}
