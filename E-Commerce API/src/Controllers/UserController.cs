using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.src.Service;
using E_Commerce_API.src.Models;
using E_Commerce_API.src.DTO;

namespace E_Commerce_API.src.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserDTO> userDtoList = new();
            foreach (var user in await _userService.GetAllUsers())
            {
                UserDTO userDto = new UserDTO(user.Name);
                userDtoList.Add(userDto);
            }
            var result = userDtoList;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var createdUser = _userService.CreatedUser(user);
            return Created("", createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _userService.GetByEmail(dto.Email);

            if (user == null || user.Password != dto.Password)
                return Unauthorized();

            var token = _authService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
