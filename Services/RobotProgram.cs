using System.Collections.Generic;

namespace scara_web_backend.Services
{
    public class RobotProgram
    {
        public List<RobotCommand> Commands { get; set; } = new List<RobotCommand>();
    }
}