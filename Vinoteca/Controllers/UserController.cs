﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public IActionResult AddUser([FromBody] CreateAndUpdateUserDto dto)
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

        [Authorize]
        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            try
            {
                _userService.RemoveOneUser(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return NoContent();

        }
    }
}
