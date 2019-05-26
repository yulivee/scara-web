using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scara_web_backend.Services;


namespace scara_web_backend.Controllers
{
    [Route("api/[controller]")]
    public class RobotJointController : Controller
    {

        ILogger<RobotJointController> _logger;

        private IRobotInteractionService _rosService {get;}

        public RobotJointController(ILogger<RobotJointController> logger, IRobotInteractionService _robotService) {
            this._rosService = _robotService;
            _logger = logger;
        }

        [HttpPost("relMove")]
        public void relMove([FromBody] RobotJoints robotJoints){
            _logger.LogError("Relative Move");
            Console.WriteLine("Relative Move/DriveDist");

            TryValidateModel(robotJoints);
            if( ModelState.IsValid ) {
                this._rosService.RelativeMove(robotJoints);
            }else{
                Console.WriteLine("Invalid Model");
            }

        }

        [HttpPost("absMove")]
        public void absMove([FromBody] RobotJoints robotJoints){
            Console.WriteLine("Absolute Move/DriveTo");
            this._rosService.AbsoluteMove(robotJoints);
        }

        [HttpGet("status")]
        public void status(){
        }

        [HttpPost("params")]
        public void setParams([FromBody] RobotParameters robotParameters){
            Console.WriteLine("Set Robot Parameters");
            this._rosService.SetParameters(robotParameters);
        }

        [HttpPost("motorState")]
        public void motorState([FromBody] RobotParameters parameters){
           if (parameters.MotorState.HasValue){
                Console.WriteLine("Set Motors to " + ( parameters.MotorState.Equals(true) ? "on" : "off") );
                this._rosService.SetMotorState(parameters.MotorState.Value);
           }
        }

        [HttpGet("zeroAxis")]
        public void zeroAxis(){
            Console.WriteLine("Set Home");
            this._rosService.ZeroAxis();
        }

        [HttpGet("currentPos")]
        public RobotJoints currentPos(){
            Console.WriteLine("Get Current Position");
            return this._rosService.GetCurrentPosition();
        }

        [HttpPost("runProg")]
        public void runProg([FromBody] string rawProgram){
            Console.WriteLine("Execute Program");
            var robotProgram = new RobotProgram();
            foreach ( var rawCommand in rawProgram.Split('\n') ) {
                var robotCommand = RobotCommand.FromString(rawCommand);
                robotProgram.Commands.Add(robotCommand);
            }
            this._rosService.RunProgram(robotProgram);
        }

        [HttpPost("customCmd")]
        public void customCmd([FromBody] string rawCommand){
            Console.WriteLine("Execute Command :",rawCommand);
            this._rosService.RunCommand(RobotCommand.FromString(rawCommand));
        }
    }
}
