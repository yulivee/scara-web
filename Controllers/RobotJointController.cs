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

        private IRobotInteractionService _rosService {get;}

        public RobotJointController(IRobotInteractionService _rosService) {
            this._rosService = _rosService;
        }

        [HttpPost("relMove")]
        public void relMove(RobotJoints robotJoints){
            Console.WriteLine("Relative Move/DriveDist");

            TryValidateModel(robotJoints);
            if( ModelState.IsValid ) {
                this._rosService.RelativeMove(robotJoints);
            }else{
                Console.WriteLine("Invalid Model");
            }

        }

        [HttpPost("absMove")]
        public void absMove(RobotJoints robotJoints){
            Console.WriteLine("Absolute Move/DriveTo");
            this._rosService.AbsoluteMove(robotJoints);
        }

        [HttpGet("status")]
        public void status(){
        }

        [HttpPost("params")]
        public void setParams(RobotParameters robotParameters){
            Console.WriteLine("Set Robot Parameters");
            this._rosService.SetParameters(robotParameters);
        }

        [HttpPost("motorState")]
        public void motorState(RobotParameters parameters){
            Console.WriteLine("Set Motors to " + ( parameters.MotorState.Equals(true) ? "on" : "off") );
            this._rosService.SetMotorState(parameters.MotorState);
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
        public void runProg(string rawProgram){
            Console.WriteLine("Execute Program");
            var robotProgram = new RobotProgram();
            foreach ( var rawCommand in rawProgram.Split('\n') ) {
                var robotCommand = RobotCommand.FromString(rawCommand);
                robotProgram.Commands.Add(robotCommand);
            }
            this._rosService.RunProgram(robotProgram);
        }

        [HttpPost("customCmd")]
        public void customCmd(string rawCommand){
            Console.WriteLine("Execute Command :",rawCommand);
            this._rosService.RunCommand(RobotCommand.FromString(rawCommand));
        }
    }
}
