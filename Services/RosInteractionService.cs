using System;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.Protocols;
using std_msgs = RosSharp.RosBridgeClient.Messages.Standard;
using std_geo = RosSharp.RosBridgeClient.Messages.Geometry;

namespace scara_web_backend {
    public class RosInteractionService : IRosInteractionService {
        public RosInteractionService () {

            var socket = new RosSocket(new WebSocketNetProtocol("ws://127.0.0.1:9090"));

            var pubId = socket.Advertise<std_msgs.String>("test_topic");
        }

    }
}