using System;
using System.Linq;
using System.IO.Ports;
using System.Collections.Generic;
using scara_web_backend.Services.Robot;

namespace scara_web_backend.Services
{
    public class SerialInteractionService : IRobotInteractionService, IDisposable
    {

        private SerialPort _serialPort {get; set;}
        public SerialInteractionService()
        {
            var serialPort = this.findGoodPort();
            if(serialPort == null || !serialPort.IsOpen) {
                throw new Exception("Unable to connect to Serial Port");
            }

            this._serialPort = serialPort;
        }

        private void configurePort(SerialPort port){
            port.BaudRate = 9600;
            port.ReadTimeout = 500;
            port.WriteTimeout = 500;
            port.Handshake = Handshake.None;
            port.NewLine = "\r\n";
        }

        private SerialPort findGoodPort(){
		var portNames = SerialPort.GetPortNames().Where(x => x.ToLower().Contains("usb"));
		foreach(var portName in portNames) {

			var goodPort = true;
			var _serialPort = new SerialPort();
			this.configurePort(_serialPort);
			_serialPort.PortName = portName;
			
			try {
				_serialPort.Open();
			} catch {
				goodPort = false;
				_serialPort.Dispose();
			}
			if(goodPort) {
				return _serialPort;
			}
		}
		return null;
	}

        ~SerialInteractionService() {
            _serialPort.Close();
        }

        public bool RelativeMove(RobotJoints robotJoints)
        {
             Console.WriteLine($"RelMove: {RobotCommand.CommandType.DriveTo},{robotJoints}");
             var successfulWrite = true;

             try {
             _serialPort.WriteLine($"{RobotCommand.CommandType.DriveTo},{robotJoints}");
             } catch {
                 successfulWrite = false;
             }

             return successfulWrite;
        }

        public void AbsoluteMove(RobotJoints robotJoints)
        {
             Console.WriteLine($"AbsMove: {RobotCommand.CommandType.DriveDist},{robotJoints}");
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

        public void Dispose()
        {
            	if(this._serialPort != null) {
                    try {
                        if(this._serialPort.IsOpen)
                            this._serialPort.Close();
                    } catch { }			
                    this._serialPort.Dispose();
                }
		}

        void IRobotInteractionService.RelativeMove(RobotJoints robotJoints)
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