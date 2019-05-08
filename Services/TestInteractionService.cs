
using System;

namespace scara_web_backend.Services {
    public class TestInteractionService : IRobotInteractionService
    {
        public void AbsoluteMove(RobotJoints robotJoints)
        {
            Console.WriteLine(robotJoints.ToString());
        }

        public RobotJoints GetCurrentPosition()
        {
            return new RobotJoints();
        }

        public void RelativeMove(RobotJoints robotJoints)
        {
            Console.WriteLine(robotJoints.ToString());
        }

        public void RunCommand(RobotCommand command)
        {
            Console.WriteLine(command.ToString());
        }

        public void RunProgram(RobotProgram program)
        {
            Console.WriteLine(program.ToString());
        }

        public void SetMotorState(bool state)
        {
            Console.WriteLine(state.ToString());
        }

        public void SetParameters(RobotParameters robotParameters)
        {
            Console.WriteLine(robotParameters.ToString());
        }

        public void ZeroAxis()
        {
            Console.WriteLine("Homing Robot");
        }
    }
}