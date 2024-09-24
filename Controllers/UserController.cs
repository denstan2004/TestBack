using Microsoft.AspNetCore.Mvc;
using TEST_APP.Models;

namespace TEST_APP.Controllers
{
    [Route ("/api/test")]  
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("Get/All/Users")]
        public IEnumerable<User> GetUser()
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetUserNames();
        }
        [HttpPost]
        [Route("Update/User")]
        public void UpdateUser([FromBody] User user)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.UpdateUser(user);
        }
    }
}
