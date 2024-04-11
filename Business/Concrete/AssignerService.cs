using Business.Abstract;
using Business.Model.Request;
using Hangfire;

namespace Business.Concrete
{
    public class AssignerService : IAssignerService
    {
        private readonly ITaskHistoryService _taskHistoryService;
        private readonly ITaskService _taskService;
        private readonly IEmployeeService _employeeService;
        private readonly IBackgroundJobClient _job;
        public AssignerService(
            ITaskHistoryService taskHistoryService,
            ITaskService taskService,
            IEmployeeService employeeService,
            IBackgroundJobClient job)
        {
            _taskHistoryService = taskHistoryService;
            _taskService = taskService;
            _employeeService = employeeService;
            _job = job;
        }


        public void Assigner(Dictionary<int, List<int>> invalidDifficulties = null)
        {
            var list_Employee = _employeeService.GetAll().Data.OrderBy(x => x.TotalScore).ToList();
            var list_Task = _taskService.GetAll().Data;
            var updateEmployees = new List<EmployeeRequest>();
            var addTaskHistories = new List<TaskHistoryRequest>();
            invalidDifficulties ??= new Dictionary<int, List<int>>();

            foreach (var employee in list_Employee)
            {
                var invalidDifficultyList = invalidDifficulties.ContainsKey(employee.EmployeeId) ? invalidDifficulties[employee.EmployeeId] : new List<int>();


                var currentTaskDifficulty = list_Task.FirstOrDefault(t => t.TaskId == employee.ActiveTaskId)?.Difficulty;
                if (currentTaskDifficulty != null)
                {
                    invalidDifficultyList.Add(currentTaskDifficulty.Value + 1);
                }


                var availableTasks = list_Task.Where(t => !invalidDifficultyList.Contains(t.Difficulty) &&
                                                          !invalidDifficultyList.Contains(t.Difficulty + 1)).OrderByDescending(t => t.Difficulty).ToList();

                if (!availableTasks.Any())
                {
                    Assigner(invalidDifficulties);
                }

                var selectedTask = availableTasks.First();

                list_Task.Remove(selectedTask);

                if (!invalidDifficultyList.Contains(selectedTask.Difficulty))
                {
                    invalidDifficultyList.Add(selectedTask.Difficulty);
                }

                invalidDifficulties[employee.EmployeeId] = invalidDifficultyList;

                var employeeRequest = new EmployeeRequest
                {
                    EmployeeId = employee.EmployeeId,
                    ActiveTaskId = (byte)selectedTask.TaskId,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    TotalScore = employee.TotalScore + selectedTask.Difficulty,
                };

                updateEmployees.Add(employeeRequest);

                var taskHistoryRequest = new TaskHistoryRequest
                {
                    TaskId = selectedTask.TaskId,
                    EmployeeId = employee.EmployeeId,
                    TaskDate = DateTime.Now
                };

                addTaskHistories.Add(taskHistoryRequest);
                
            }

            _employeeService.Update(updateEmployees);
            _taskHistoryService.Add(addTaskHistories);

        
        }


        public void CreateAssignJob()
        {
            _job.Enqueue(() => Assigner(null));
        }

    }
}
