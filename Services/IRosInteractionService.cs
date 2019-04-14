using System;

namespace scara_web_backend.Services {
    public interface IRosInteractionService
    {
        void Shutdown();

        void SendMove(RobotJoints robotJoints);
    }
}