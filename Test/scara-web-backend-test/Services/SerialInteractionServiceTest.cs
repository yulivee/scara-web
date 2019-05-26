using System;
using Xunit;

using scara_web_backend.Services;
using scara_web_backend.Services.Robot;

namespace scara_web_backend.Services
{

    public class SerialInteractionServiceTest
    {
             SerialInteractionService robotService = new SerialInteractionService();
             

             [Fact]
             public void TestRelativeMove() {


                 var robotJoints = new scara_web_backend.Services.Robot.RobotJoints { 
                                                     joint1 = 0,
                                                     joint2 = 100,
                                                     joint3 = 0,
                                                     joint4 = 0,
                                                     joint5 = 0,
                                                     joint6 = 0,
                                                     gripper = 0
                                                     };
                 Assert.True(this.robotService.RelativeMove(robotJoints), "Relative Move operation is successful");
             }
    }

}