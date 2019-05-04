using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scara_web_backend.Services;


namespace scara_web_backend.Controllers
{
    [Route("api/[controller]")]
    public class RobotJointController : Controller
    {

        private IRosInteractionService _rosService {get;}

        public RobotJointController(IRosInteractionService _rosService) {
            this._rosService = _rosService;
        }

        [HttpPost("relMove")]
        public void relMove(RobotJoints robotJoints){
            Console.WriteLine("Relative Move/DriveDist");
            this._rosService.RelativeMove(robotJoints);
        }

        [HttpPost("absMove")]
        public void absMove(RobotJoints robotJoints){
            Console.WriteLine("Absolute Move/DriveTo");
            this._rosService.AbsoluteMove(robotJoints);
        }

        [HttpGet("status")]
        public void status(){
        }

    }
}
