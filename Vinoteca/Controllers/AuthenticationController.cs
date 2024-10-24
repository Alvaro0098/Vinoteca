﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _config;
        public AuthenticationController(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _config = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsForAuthenticateDto credentials)
        {
            User? userAuthenticated = _userRepository.Authenticate(credentials.UserName, credentials.Passwords);
            if (userAuthenticated is not null)
            {

                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                SigningCredentials signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", userAuthenticated.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("given_name", userAuthenticated.UserName)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                  _config["Authentication:Issuer"],
                  _config["Authentication:Audience"],
                  claimsForToken,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddHours(1),
                  signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);




                return Ok(tokenToReturn);
            }
            return Unauthorized();
            

        }
        
    }
}
