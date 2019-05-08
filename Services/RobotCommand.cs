using System.Linq;

namespace scara_web_backend.Services
{
    public class RobotCommand {
        public static RobotCommand FromString (string rawCommand)
        {
            rawCommand = rawCommand.TrimEnd('\n');
            var robotCommand = new RobotCommand();
            robotCommand.Code = int.Parse(rawCommand.Split(',').FirstOrDefault());
            robotCommand.Parameters = string.Join(",", rawCommand.Split(',').Skip(1));
            return robotCommand;
        }

        public int Code { get; set; }
        public string Parameters { get; set; }
        public string Terminator { get; set; } = "\n";

        public override string ToString () {
            return Code.ToString() + ',' + Parameters + Terminator;
        }
    }
}