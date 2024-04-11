using Core.Business.Abstract;

namespace Business.Model.Response
{
    public class TaskResponse : IModel
    {
        public int TaskId { get; set; }
        public string? Name { get; set; }
        public byte Difficulty { get; set; }
        public string? DifficultyColorCode { get; set; }
    }
}
