using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/assigner")]
    [ApiController]
    public class AssignerController : ControllerBase
    {
        private readonly IAssignerService _assignerService;

        public AssignerController(IAssignerService assignerService)
        {
            _assignerService = assignerService; 
        }
        [HttpGet]
        [Route("Assign")]
        public IActionResult Assign()
        {
            _assignerService.Assigner();
            return Ok();
        }
    }
}
