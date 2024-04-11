using Business.Abstract;
using Business.Model.Response;
using Core.Utils;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly ITaskDal _taskDal;

        public TaskService(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public IDataResult<List<TaskResponse>> GetAll()
        {
            var taskList = _taskDal.GetAll().Select(t=> new TaskResponse
            {
                TaskId = t.TaskId,
                Name = t.Name,
                Difficulty = t.Difficulty,
                DifficultyColorCode = t.DifficultyColorCode
            }).ToList();

            return new SuccessDataResult<List<TaskResponse>>(taskList, "Tasks have been listed successfully.");
        }

        public IDataResult<TaskResponse> Get(int taskId)
        {
            var task = _taskDal.Get(x=> x.TaskId == taskId);

            var taskResponse = new TaskResponse()
            {

                TaskId = task.TaskId,
                Name = task.Name,
                Difficulty = task.Difficulty,
                DifficultyColorCode = task.DifficultyColorCode

            };
            return new SuccessDataResult<TaskResponse>(taskResponse);
        }
    }
}
