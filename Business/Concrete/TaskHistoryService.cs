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
    public class TaskHistoryService : ITaskHistoryService
    {
        private readonly ITaskHistoryDal _taskHistoryDal;
        private readonly ITaskService _taskService;
        private readonly IEmployeeService _employeeService;

        public TaskHistoryService(ITaskHistoryDal taskHistoryDal, ITaskService taskService, IEmployeeService employeeService)
        {
            _taskHistoryDal = taskHistoryDal;
            _taskService = taskService;
            _employeeService = employeeService;
        }

        public IDataResult<List<TaskHistoryResponse>> GetAll()
        {
            var taskHistoryList = _taskHistoryDal.GetAll().OrderByDescending(x=>x.TaskDate).Select(h => new TaskHistoryResponse()
            {
                TaskHistoryId = h.TaskHistoryId,
                TaskDate = h.TaskDate,
                Employee = _employeeService.Get(h.EmployeeId).Data,
                Task = _taskService.Get(h.TaskId).Data
            }).ToList();

            return new SuccessDataResult<List<TaskHistoryResponse>>(taskHistoryList,"Task Histories have been listed successfully.");
        }

        public IResult Add(List<TaskHistoryRequest> taskHistories)
        {
            var insertEntities = taskHistories.Select(th => new TaskHistory
            {
                EmployeeId = th.EmployeeId,
                TaskDate   = th.TaskDate,
                TaskId = th.TaskId, 
            }).ToList();
            _taskHistoryDal.Add(insertEntities);
            return new SuccessResult();
        }
        public IDataResult<List<TaskHistoryResponse>> GetTodayTask()
        {
            var today = DateTime.Today;
            var taskHistoryList = _taskHistoryDal.GetAll(x=>x.TaskDate.Date == today).Select(h => new TaskHistoryResponse()
            {
                TaskHistoryId = h.TaskHistoryId,
                TaskDate = h.TaskDate,
                Employee = _employeeService.Get(h.EmployeeId).Data,
                Task = _taskService.Get(h.TaskId).Data
            }).ToList();

            return new SuccessDataResult<List<TaskHistoryResponse>>(taskHistoryList, "Todays tasks have been listed successfully.");
        }
    }
}
