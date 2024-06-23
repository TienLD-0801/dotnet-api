using Microsoft.AspNetCore.Mvc;

namespace Global.Controllers
{
    [ApiController]
    [Route("/")]
    public class GlobalController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Api is running ...";
        }
    }
}