using Core.DataAccess.Concrete.EF;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Entity.Entities.Task;

namespace DataAccess.Concrete.EF
{
    public class EFTaskDal : EFEntityRepositoryBase<Task>, ITaskDal
    {
        public EFTaskDal(DbContext db) : base(db)
        {
        }
    }
}
