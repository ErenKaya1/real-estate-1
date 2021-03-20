using Microsoft.AspNetCore.Mvc;
using System;

namespace RealEstate.Images.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("get method");
            return Ok("get method");
        }

        [HttpPost]
        public IActionResult Post()
        {
            Console.WriteLine("post method");
            return Ok();
        }
    }
}