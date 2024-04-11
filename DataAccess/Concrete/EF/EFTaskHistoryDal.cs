using Core.DataAccess.Concrete.EF;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EFTaskHistoryDal : EFEntityRepositoryBase<TaskHistory>, ITaskHistoryDal
    {
        public EFTaskHistoryDal(DbContext db) : base(db)
        {
        }
    }
}
