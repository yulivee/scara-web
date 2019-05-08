using System;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using std_msgs = RosSharp.RosBridgeClient.Messages.Standard;
using System.Reflection;

namespace scara_web_backend.Services
{
    public class RosInteractionService : IRobotInteractionService
    {
        private readonly Dictionary<string, IRosTopicPublisher> topics;

        private interface IRosTopicPublisher
        {
            string Name { get; }
            string PubId { get; set; }
            Type Type { get; }
            RosSocket Socket {set;}
            void Publish(Message msg);

            void Advertise();
        }

        private class RosTopicPublisher<T> : IRosTopicPublisher where T : Message
        {
            public RosTopicPublisher(string name, RosSocket socket)
            {
                this.Name = name;
                this.Socket = socket;
                this.Advertise();
            }

            public string Name { get; private set; }
            public Type Type { get { return typeof(T); } }
            public string PubId { get; set; }

            public RosSocket Socket { get; set; }

            public void Advertise()
            {
               PubId =  Socket.Advertise<T>(Name);
            }

            public void Publish(Message msg) {
                Socket.Publish(this.PubId, msg);
            }

    
        }

        public RosInteractionService()
        {

            var socket = new RosSocket(new WebSocketNetProtocol("ws://127.0.0.1:9090"));

            topics = (new IRosTopicPublisher[]{
                new RosTopicPublisher<std_msgs.String>("DriveTo", socket),
                new RosTopicPublisher<std_msgs.String>("DriveDist", socket),
                new RosTopicPublisher<std_msgs.String>("Home", socket),
                new RosTopicPublisher<std_msgs.Time>("SetPidState", socket)
                //new RosTopicPublisher<std_msgs.Bool>("CheckTargetReached", socket)
                //new RosTopicPublisher<std_msgs.Int32>("SetSpeed", socket)
                //new RosTopicPublisher<std_msgs.Int32>("SetZone", socket)
            }).ToDictionary(x => x.Name);


        }

        public void RelativeMove(RobotJoints robotJoints) {
        //driveDist  - Achsweise händisch verfahren um z.b. +10
            topics["DriveDist"].Publish(new std_msgs.String(robotJoints.ToString()));
        }

        public void AbsoluteMove(RobotJoints robotJoints) {
        //driveTo - einen Punkt anfahren
            topics["DriveTo"].Publish(new std_msgs.String(robotJoints.ToString()));

        }

        public void SetParameters(RobotParameters robotParameters)
        {
            throw new NotImplementedException();
        }

        public void SetMotorState(bool State)
        {
            throw new NotImplementedException();
        }

        public void ZeroAxis()
        {
            throw new NotImplementedException();
        }

        public RobotJoints GetCurrentPosition()
        {
            throw new NotImplementedException();
        }

        public void RunProgram(RobotProgram program)
        {
            throw new NotImplementedException();
        }

        public void RunCommand(RobotCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

#region ImplementationNotes
/* 
    driveDist  - Achsweise händisch verfahren um z.b. +10
    driveTo - einen Punkt anfahren
 */
#endregion