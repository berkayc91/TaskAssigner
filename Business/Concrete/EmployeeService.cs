using Business.Abstract;
using Business.Model.Request;
using Business.Model.Response;
using Core.Utils;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeService(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IDataResult<List<EmployeeResponse>> GetAll()
        {
            var employeeList =  _employeeDal.GetAll().Select(e=> new EmployeeResponse
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Surname = e.Surname,
                TotalScore = e.TotalScore,
                ActiveTaskId = e.ActiveTaskId,
            }).ToList();

            return new SuccessDataResult<List<EmployeeResponse>>(employeeList, "Employees have been listed successfully.");
        }
        public IDataResult<EmployeeResponse> Get(int employeeId)
        { 
            var employee = _employeeDal.Get(x=> x.EmployeeId == employeeId);

            var employeeResponse = new EmployeeResponse()
            {
                EmployeeId = employee.EmployeeId,
                ActiveTaskId = employee.ActiveTaskId,
                Name = employee.Name,
                Surname = employee.Surname,
                TotalScore = employee.TotalScore

            };
            return new SuccessDataResult<EmployeeResponse>(employeeResponse);
        }

        public IResult Update(List<EmployeeRequest> employees)
        {
            var updateEntities = employees.Select(r => new Employee
            {
                EmployeeId = r.EmployeeId,
                Name = r.Name,
                Surname = r.Surname,
                TotalScore = r.TotalScore,
                ActiveTaskId = r.ActiveTaskId

            }).ToList();

            _employeeDal.Update(updateEntities);
            return new SuccessResult();
        }

    }
}
