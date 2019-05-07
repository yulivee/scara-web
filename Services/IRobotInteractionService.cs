using System;

namespace scara_web_backend.Services {
    public interface IRobotInteractionService
    {
        void RelativeMove(RobotJoints robotJoints);
        void AbsoluteMove(RobotJoints robotJoints);
    }
}