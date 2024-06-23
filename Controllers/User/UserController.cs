using dotnet_app.Services.User;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace dotnet_app.Controllers.User
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IUserService userService) : ControllerBase


    {
        private readonly IUserService _userService = userService;

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
        public ActionResult<UserEntity> Post([FromBody] UserEntity value)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            var user = _userService.CreateUser(value);
            return Ok(user);
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