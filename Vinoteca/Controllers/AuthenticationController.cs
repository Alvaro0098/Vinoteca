using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly UserRepository _userRepository;
        public AuthenticationController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsForAuthenticateDto credentials)
        {
            User? userAuthenticated = _userRepository.Authenticate(credentials.UserName, credentials.Passwords);
            if (userAuthenticated is not null)
            {
                return Ok("lleva token");
            }
            return Unauthorized();
            

        }
        
    }
}
