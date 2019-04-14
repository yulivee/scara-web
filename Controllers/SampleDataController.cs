using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using std_msgs = RosSharp.RosBridgeClient.Messages.Standard;
using std_geo = RosSharp.RosBridgeClient.Messages.Geometry;

namespace scara_web_backend.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class RobotJoints {
            public int joint1 {get;set;}
            public int joint2 {get;set;}
            public int joint3 {get;set;}
            public int joint4 {get;set;}
            public int joint5 {get;set;}
            public int joint6 {get;set;}
            public int joint7 {get;set;}
        }

        [HttpPost("move")]
        public void move(){
        }
        [HttpGet("status")]
        public void status(){
        }

        [HttpGet("test")]
        public string test() {
            var socket = new RosSocket(new WebSocketNetProtocol("ws://127.0.0.1:9090"));

            var pubId = socket.Advertise<std_msgs.String>("test_topic");

            var msg = new std_msgs.String("some random data");
            socket.Publish(pubId, msg);

            socket.Close();


            return "";
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
