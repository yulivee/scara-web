import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RobotJoints } from './RobotJoints';

@Component({
  selector: 'app-abs-drive',
  templateUrl: './abs-drive.component.html'
})
export class AbsoluteDriveComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const data = <RobotJoints> {
      joint1: 1
    };
    
    http.post<any>(baseUrl + 'api/RobotJoint/absMove',data).subscribe(result => {
    }, error => console.error(error));
  }

  private robotInstance = <RobotJoints>{}; 
  setPosition() {
      this.robotInstance.joint1 = robot.j1;
      this.robotInstance.joint2 = robot.j2;
      this.robotInstance.joint3 = robot.j3;
      this.robotInstance.joint4 = robot.j4;
      this.robotInstance.joint5 = robot.j5;
      this.robotInstance.joint6 = robot.j6;
      this.robotInstance.gripper = robot.gripper;

  } 
}