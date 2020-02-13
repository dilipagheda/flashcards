using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Infrastructure;
using api_flashcards_dotnet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_flashcards_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJWTGenerator _jWTGenerator;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJWTGenerator jWTGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTGenerator = jWTGenerator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest _loginRequest)
        {

            var user = await _userManager.FindByEmailAsync(_loginRequest.Email);

            if(user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, _loginRequest.Password, false);

            if(result.Succeeded)
            {
                var loginResponse = new LoginResponse()
                {
                    DisplayName = user.DisplayName,
                    Token = _jWTGenerator.CreateToken(user)
                };

                return Ok(loginResponse);
            }

            return Unauthorized();
            
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest _registerRequest)
        {
            var user = await _userManager.FindByEmailAsync(_registerRequest.Email);

            if(user != null)
            {
                var error = new ErrorResponse()
                {
                    Error = "Email is already in use"
                };
                return BadRequest(error);
            }

            var userToCreate = new ApplicationUser()
            {
                DisplayName = _registerRequest.DisplayName,
                Email = _registerRequest.Email,
                UserName = _registerRequest.Email
            };

            var result = await _userManager.CreateAsync(userToCreate, _registerRequest.Password);
            if(!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
