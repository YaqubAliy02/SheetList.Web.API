using Microsoft.AspNetCore.Mvc;

namespace ODS.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Ok("Welcome to my project");
    }
}
