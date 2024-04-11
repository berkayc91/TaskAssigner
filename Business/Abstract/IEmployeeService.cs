using Business.Model.Request;
using Business.Model.Response;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<EmployeeResponse>> GetAll();
        IDataResult<EmployeeResponse> Get(int employeeId);
        IResult Update(List<EmployeeRequest> employees);
    }
}
