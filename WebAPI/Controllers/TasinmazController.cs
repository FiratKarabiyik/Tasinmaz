using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasinmazController : ControllerBase
    {
        ITasinmazService _tasinmazService;
        IUserService _userService;
        private readonly ITasinmazDal _tasinmazDalReposity;

        public TasinmazController(ITasinmazService productService,IUserService userService, ITasinmazDal tasinmazDalReposity)
        {
            _tasinmazService = productService;
            _userService = userService;
            _tasinmazDalReposity = tasinmazDalReposity;
        }


        [HttpGet("getlistbysehir")]
        public IActionResult GetListBySehir(int Sid)
        {

            var result = _tasinmazService.GetListBySehir(Sid);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _tasinmazService.GetAll();
            //if (result.Success)
            //{
                return Ok(result);
                
            //}
            //return BadRequest(result);
        }

        [HttpGet("getall2")]
        public IActionResult AllTasinmaz()
        {

            var result = _tasinmazDalReposity.AllTasinmaz().OrderByDescending(t => t.TasinmazId); 
            //if (result.Success)
            //{
            //    return Ok(result);

            //}
            //return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getalllog")]
        public IActionResult GetAllLog()
        {

            var result = _tasinmazService.GetAllLog().Data.OrderByDescending(u => u.logid);  
           // if (result.Success)
           // {
                return Ok(result);

           // }
          //  return BadRequest(result);
        }



        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _tasinmazService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _tasinmazService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        


        [HttpPost("add")]
        public IActionResult Post(Tasinmaz product)
        {

            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var result = _tasinmazService.Add(product);


            if (result.Success)
            {
                _tasinmazService.AddLog(new Log 
                {acıklama ="Kayıt Eklendi",
                durum = true,
                islemtipi= "Tasınmaz Ekleme",
                tarih= DateTime.Now,                               
                userid = id,
                logip = HttpContext.Connection.RemoteIpAddress?.ToString()                          
                });






                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Tasinmaz tasinmaz)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var result = _tasinmazService.Delete(tasinmaz);
            if (result.Success)
            {
                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Kayıt Silindi ",
                    durum = true,
                    islemtipi = "Tasınmaz Silme",
                    tarih = DateTime.Now,
                    userid = id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()



                });
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



        [HttpPost("update")]
        public IActionResult Update(Tasinmaz tasinmaz)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userService.GetUserById(id);
            var result = _tasinmazService.Update(tasinmaz);
            if (result.Success)
            {

                _tasinmazService.AddLog(new Log
                {
                    acıklama = "Kayıt Güncellendi",
                    durum = true,
                    islemtipi = "Tasınmaz Güncelleme",
                    tarih = DateTime.Now,
                    userid = id,
                    logip = HttpContext.Connection.RemoteIpAddress?.ToString()



                });
                return Ok(result);
            }

            return BadRequest(result);
        }



      





    }
}
