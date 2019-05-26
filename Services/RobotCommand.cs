using System.Linq;

namespace scara_web_backend.Services
{
    public class RobotCommand {
        public static RobotCommand FromString (string rawCommand)
        {
            rawCommand = rawCommand.Replace("\n",string.Empty)
                                   .Replace("\r", string.Empty)
                                   .Replace(" ", string.Empty);
            var robotCommand = new RobotCommand();
            robotCommand.Code = int.Parse(rawCommand.Split(',').FirstOrDefault());
            robotCommand.Parameters = string.Join(",", rawCommand.Split(',').Skip(1));
            return robotCommand;
        }

        public enum CommandType
        {
            Home = 1,
            DriveTo = 12,
            DriveDist = 10,
            SetPidState = 2,
            SetZone = 16,
            SetSpeed = 15,
            SetMotorState = 3
        }

        public int Code { get; set; }
        public string Parameters { get; set; }

        public override string ToString () {
            var _paramString = Code.ToString();
            if ( Parameters != null || Parameters != "" ) {
                _paramString += "," + Parameters;
            }
            return _paramString;
        }
    }
}