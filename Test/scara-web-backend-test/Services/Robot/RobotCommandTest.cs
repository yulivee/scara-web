using System;
using Xunit;

using scara_web_backend.Services;
using scara_web_backend.Services.Robot;

namespace scara_web_backend.Services
{

    public class RobotCommandTest
    {
             

             [Fact]
             public void TestToStringFromRawCommand() {

             var rawCommand = "12, 0, 100 ,0 ,0 ,0 ,0 ,0\n\n";
                var expectedParameters = "0,100,0,0,0,0,0";
                var expectedCommand = "12,0,100,0,0,0,0,0";
                var expectedCode = 12;

             RobotCommand robotCommand = RobotCommand.FromString(rawCommand);

             Assert.True(robotCommand.Code.Equals(expectedCode), "Correct Command Code parsed");
             Assert.Equal(expectedParameters, robotCommand.Parameters);
             Assert.Equal(expectedCommand, robotCommand.ToString());

//                 Assert.True(this.robotService.RelativeMove(robotJoints), "Relative Move operation is successful");
             }

             [Fact]
             public void TestToStringFromEnumAndJointObject() {
                 var robotJoints = new RobotJoints { 
                                                     joint1 = 0,
                                                     joint2 = 100,
                                                     joint3 = 0,
                                                     joint4 = 0,
                                                     joint5 = 0,
                                                     joint6 = 0,
                                                     gripper = 0
                                                     };

                var expectedParameters = "0,100,0,0,0,0,0";
                var expectedCommand = "12,0,100,0,0,0,0,0";
                var expectedCode = 12;

             string rawCommand = $"{(int) RobotCommand.CommandType.DriveTo},{robotJoints}";
             Assert.Equal(expectedCommand, rawCommand );
             RobotCommand robotCommand = RobotCommand.FromString(rawCommand);
             Assert.True(robotCommand.Code.Equals(expectedCode), "Correct Command Code parsed");
             Assert.Equal(expectedParameters, robotCommand.Parameters);
             Assert.Equal(expectedCommand, robotCommand.ToString());
             }
    }

}