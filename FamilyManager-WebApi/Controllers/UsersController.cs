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
        
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await _userService.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}