using Microsoft.AspNetCore.Mvc;

namespace dotnet_app.Controllers.Global
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