using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace scara_web_backend.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

private const IRosInteractionService _rosService;
        public SampleDataController(IRosInteractionService _rosService) {
            this._rosService = _rosService;
        }

        [HttpPost("move")]
        public void move(RobotJoints robotJoints){
            if(!this.Request.ViewModel.IsValid) return;
            this._rosService.SendMove(robotJoints);
        }

        [HttpGet("status")]
        public void status(){
        }

        [HttpGet("test")]
        public string test() {

            var msg = new std_msgs.String("some random data");
            socket.Publish(pubId, msg);

            socket.Close();


            return "";
        }

    }
}
