using Microsoft.AspNetCore.Mvc;
using Vinoteca.Models.Dtos;
using Vinoteca.Services.interfaces;

namespace Vinoteca.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {

        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userService.AddOneUser(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);

        }

        [HttpGet("{id}")] //por url
        public IActionResult GetOneUserById(int id)
        {
            var user = _userService.GetOneUserId(id);  // Llama al servicio para obtener el usuario

            if (user == null)
            {
                return NotFound("Usuario no encontrado");  // Retorna 404 si no se encuentra el usuario
            }

            return Ok(user);  // Retorna 200 OK con el usuario encontrado
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool isRemoved = _userService.RemoveOneUser(id);

            if (isRemoved)
            {
                return Ok(); // El usuario fue eliminado correctamente
            }

            return NotFound(); // El usuario no fue encontrado
        }



    }
}
