using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoachUp.BLL;

namespace CoachUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        [HttpGet]
        public string Get()
        {
            Class1 c = new Class1();
            return c.Hi();
        }
    }
}
