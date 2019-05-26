using System;
using System.Linq;
using System.IO.Ports;
using System.Collections.Generic;

namespace scara_web_backend.Services
{
    public class SerialInteractionService : IRobotInteractionService
    {

        private SerialPort _serialPort {get; set;}
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
             _serialPort.WriteLine($"{RobotCommand.CommandType.DriveTo},{robotJoints}");
        }

        public void AbsoluteMove(RobotJoints robotJoints)
        {
             _serialPort.WriteLine($"{RobotCommand.CommandType.DriveDist},{robotJoints}");
        }

        public void SetParameters(RobotParameters robotParameters)
        {
            if (robotParameters.Zone.HasValue){
                _serialPort.WriteLine($"{RobotCommand.CommandType.SetZone},{robotParameters.Zone.Value}");
            }
            if (robotParameters.Speed.HasValue)
            {
                _serialPort.WriteLine($"{RobotCommand.CommandType.SetSpeed},{robotParameters.Speed.Value}");
            }
            if (robotParameters.MotorState.HasValue)
            {
                _serialPort.WriteLine($"{RobotCommand.CommandType.SetMotorState},{robotParameters.MotorState.Value}");
            }
        }

        public void SetMotorState(bool State)
        {
            throw new NotImplementedException();
        }

        public void ZeroAxis()
        {
            _serialPort.WriteLine($"{RobotCommand.CommandType.Home}");
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