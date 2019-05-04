using System;

namespace scara_web_backend.Services {
    public interface IRosInteractionService
    {
        void SendMove(RobotJoints robotJoints);
    }
}