using Core.DataAccess.Abstract;
using Task = Entity.Entities.Task;

namespace DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task>
    {
    }
}
