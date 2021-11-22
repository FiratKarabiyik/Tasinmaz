using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
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
    public class UserController : ControllerBase
    {
        ITasinmazService _tasinmazService;
        IUserService _userService;
        public UserController(IUserService userService, ITasinmazService productService)
        {
            _userService = userService;
            _tasinmazService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _userService.GetAll().Data.OrderByDescending(u=>u.Id);
            //if (result.Success)
            // {
            return Ok(result);
            //}
           // return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User tasinmaz)
        {

            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);

            var result = _userService.Delete(tasinmaz);
            if (result.Success)
            {
                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Kayıt Silindi",
                    durum = true,
                    islemtipi = "Kullanıcı Silme",
                    tarih = DateTime.Now,
                    userid = id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()
                });
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var result = _userService.UpdateUser(userUpdateDto);

         
            if (result.Success)
            {
                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Kayıt Güncellendi",
                    durum = true,
                    islemtipi = "Kullanıcı Güncellendi",
                    tarih = DateTime.Now,
                    userid = id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()
                });
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyidlogin")]
        public IActionResult GetByIdLogin()
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            return Ok(user);
        }



      





    }
}
