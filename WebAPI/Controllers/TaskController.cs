using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("List_Task")]
        public IActionResult GetAll()
        {
            var result = _taskService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("Find_Task/{id}")]
        public IActionResult Get(int id)
        {
            var result = _taskService.Get(id);
            return Ok(result);
        }
    }
}
