using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {

        private ISehirService _sehirService;
        public SehirController(ISehirService sehirService)
        {
            _sehirService = sehirService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {

            var result = _sehirService.GetAll();
            if (result.Success)
            {
              return Ok(result);
            }

            return BadRequest(result.Message);
        }


    }
}
