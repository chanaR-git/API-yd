using hwWebAPI.Models;
using hwWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hwWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public List<User> usersList = new()
        {
            new (){Name="Aba"},
            new (){Name="Ima"},
        };

        public IuserRepository _userRepository;
        public UsersController(IuserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            return Ok(usersList);
        }
        
        [HttpPost]
        public IActionResult createUser([FromBody] User user)
        {
            try
            {
                User? found = usersList.Find(u => u.Name.Equals(user.Name));
                
                if (found==null)
                {
                    usersList.Add(user);
                    return Ok(usersList);
                }
                return BadRequest("exists");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
