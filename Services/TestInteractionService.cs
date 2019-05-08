
using System;

namespace scara_web_backend.Services {
    public class TestInteractionService : IRobotInteractionService
    {
        public void AbsoluteMove(RobotJoints robotJoints)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(robotJoints.ToString()+" <-");
        }

        public RobotJoints GetCurrentPosition()
        {
            return new RobotJoints();
        }

        public void RelativeMove(RobotJoints robotJoints)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(robotJoints.ToString()+" <-");
        }

        public void RunCommand(RobotCommand command)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(command.ToString()+" <-");
        }

        public void RunProgram(RobotProgram program)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(program.ToString()+" <-");
        }

        public void SetMotorState(bool state)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(state.ToString()+" <-");
        }

        public void SetParameters(RobotParameters robotParameters)
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine(robotParameters.ToString()+" <-");
        }

        public void ZeroAxis()
        {
            Console.Write("-> Test - ", System.Reflection.MethodBase.GetCurrentMethod().Name +" ->");
            Console.WriteLine("Homing Robot");
        }
    }
}