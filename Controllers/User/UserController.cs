using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new string[] { "user1", "user2", "user3" };
        }


        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {

            return "user" + id;
        }

        // POST: api/user
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            // TODO: Implement logic to create a new user
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            return Ok();
        }
    }
}