using Core.Entity.Abstract;

namespace Entity.Entities
{
    public class Task : IEntity
    {
        public int TaskId { get; set; }
        public string? Name { get; set; }
        public byte Difficulty { get; set; }
        public string? DifficultyColorCode { get; set; }
    }
}
