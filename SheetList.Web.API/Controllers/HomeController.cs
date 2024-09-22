using Microsoft.AspNetCore.Mvc;

namespace SheetList.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
      [HttpGet]
      public ActionResult<string> Get() => 
            Ok("Welcome to this project");
    }
}
