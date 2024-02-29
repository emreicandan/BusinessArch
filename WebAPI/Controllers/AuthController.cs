using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn([FromBody]UserForLoginDTO userForLoginDTO)
        {
            return Ok(_authService.SignIn(userForLoginDTO));
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody]UserForRegisterDTO userForRegisterDTO)
        {
            return Ok(_authService.Register(userForRegisterDTO));
        }
    }
}

