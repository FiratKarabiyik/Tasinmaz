using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        ITasinmazService _tasinmazService;
        IUserService _userService;

        public AuthController(IAuthService authService, ITasinmazService productService, IUserService userService)
        {
            _authService = authService;
            _tasinmazService = productService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {

            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Sisteme Giriş Yapıldı",
                    durum = true,
                    islemtipi = "Login",
                    tarih = DateTime.Now,
                    userid = userToLogin.Data.Id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()
                });

                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {

            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Kullanıcı Eklendi",
                    durum = true,
                    islemtipi = "Kullanıcı Eklendi",
                    tarih = DateTime.Now,
                    userid = id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()
                });

                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        


    }
}
