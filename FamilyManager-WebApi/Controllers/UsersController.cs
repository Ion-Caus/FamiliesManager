using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManager_WebApi.Data;
using FamilyManager_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManager_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> ValidateUser([FromBody] User user)
        {
            try
            {
                User responseUser = await _userService.ValidateUserAsync(user.Username, user.Password);
                return Ok(responseUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }
    }
}