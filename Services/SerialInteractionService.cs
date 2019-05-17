using System;
using System.Linq;
using System.IO.Ports;
using System.Collections.Generic;

namespace scara_web_backend.Services
{
    public class SerialInteractionService : IRobotInteractionService
    {

        private SerialPort _serialPort {get; set;}
        private readonly Dictionary<string, int> commands = new Dictionary<string, int>{
            { "DriveTo", 12 },
            { "DriveDist", 10 },
            { "Home", 0 },
            { "SetPidState", 1 }
        }

        public SerialInteractionService()
        {
            _serialPort.PortName = SerialPort.GetPortNames().First();
            _serialPort.BaudRate = 9600;
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.Handshake = Handshake.None;
            _serialPort.NewLine = "\r\n";
            _serialPort.Open();
            //_continue = true;

        }

        ~SerialInteractionService() {
            _serialPort.Close();
        }

        public void RelativeMove(RobotJoints robotJoints)
        {
             _serialPort.WriteLine(commands["DriveTo"].ToString()+","+robotJoints.ToString());
        }

        public void AbsoluteMove(RobotJoints robotJoints)
        {
             _serialPort.WriteLine(commands["DriveDist"].ToString()+","+robotJoints.ToString());
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