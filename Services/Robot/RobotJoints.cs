using System.Text;

namespace scara_web_backend.Services.Robot
{
    public class RobotJoints
    {
        public int joint1 { get; set; }
        public int joint2 { get; set; }
        public int joint3 { get; set; }
        public int joint4 { get; set; }
        public int joint5 { get; set; }
        public int joint6 { get; set; }
        public int gripper { get; set; }


        public override string ToString ()
        {
            var jointString = new StringBuilder();
            
            jointString
            .Append(joint1).Append(",")
            .Append(joint2).Append(",")
            .Append(joint3).Append(",")
            .Append(joint4).Append(",")
            .Append(joint5).Append(",")
            .Append(joint6).Append(",")
            .Append(gripper);

            return jointString.ToString();

        }

    }
}