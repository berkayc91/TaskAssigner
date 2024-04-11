using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/task-history")]
    [ApiController]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryService _taskHistoryService;

        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        [HttpGet]
        [Route("List_TaskHistory")]
        public IActionResult GetAll() 
        {
            var result = _taskHistoryService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("List_TodayTask")]
        public IActionResult GetToday()
        {
            var result = _taskHistoryService.GetTodayTask();
            return Ok(result);
        }
    }
}
