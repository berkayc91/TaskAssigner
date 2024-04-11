using Core.DataAccess.Concrete.EF;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EF
{
    public class EFEmployeeDal : EFEntityRepositoryBase<Employee>, IEmployeeDal
    {
        public EFEmployeeDal(DbContext db) : base(db)
        {
        }
    }
}
