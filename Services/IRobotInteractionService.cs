using System;

namespace scara_web_backend.Services {
    public interface IRobotInteractionService
    {
        void RelativeMove(RobotJoints robotJoints);
        void AbsoluteMove(RobotJoints robotJoints);
        void SetParameters(RobotParameters robotParameters);
        void SetMotorState(bool State);
        void ZeroAxis();
        RobotJoints GetCurrentPosition();
        void RunProgram(RobotProgram program);

        void RunCommand(RobotCommand command);
    }
}