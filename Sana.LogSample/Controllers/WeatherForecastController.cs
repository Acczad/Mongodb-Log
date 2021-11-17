using Microsoft.AspNetCore.Mvc;
using Sana.Log.Abstraction;
using Sana.Log.Abstraction.Model;
using System;
using System.Collections.Generic;

namespace Sana.LogSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISanaLogger _sanaLogger;

        public WeatherForecastController(ISanaLogger sanaLogger)
        {
            _sanaLogger = sanaLogger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var errModel = SanaErrorLogModel.GetInstance("test error message", "etc");

            errModel.AddIP("192.168.1.1");
            errModel.AddUser (50, "test@test.com");

            errModel.AddMultiCulturalMessages(new Dictionary<string, string>());
            errModel.AddException(5022, new Exception("test message"));

            _sanaLogger.Error(errModel);

            return Ok();
        }
    }
}
