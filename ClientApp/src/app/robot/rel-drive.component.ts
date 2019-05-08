import { Component } from '@angular/core';
import { RobotJoints } from './RobotJoints';
import { RobotService } from './robot.service';


@Component({
  selector: 'app-rel-drive',
  templateUrl: './rel-drive.component.html',
  styleUrls: ['./drive.component.css']
})
export class RelativeDriveComponent {

  constructor(private _robotService: RobotService) {
  }

  public stepWidth : number = 100;

  public robot: RobotJoints =  new RobotJoints();

  public increment(field: string): void {
    
    if ( field === "joint5") {
      this.robot["joint5"] = this.stepWidth;
      this.robot["joint6"] = this.stepWidth;
    }
    else if ( field === "joint6"){
      this.robot["joint5"] = this.stepWidth;
      this.robot["joint6"] = -(this.stepWidth);
    }
    else {
      this.robot[field] = this.stepWidth;
    }


    this.setPosition(field);
  }

  public decrement(field: string): void {

    if ( field === "joint5") {
      this.robot["joint5"] = -(this.stepWidth);
      this.robot["joint6"] = -(this.stepWidth);
    }
    else if ( field === "joint6"){
      this.robot["joint5"] = -(this.stepWidth);
      this.robot["joint6"] = this.stepWidth;
    }
    else {
      this.robot[field] = -(this.stepWidth);
    }

    this.setPosition(field);
  }

  public setPosition(field: string): void {
    const transmitData: RobotJoints = new RobotJoints();
    if ( field === "joint5" || field === "joint6") {
      transmitData["joint5"] = this.robot["joint5"]; 
      transmitData["joint6"] = this.robot["joint6"];
    }
    else {
      transmitData[field] = this.robot[field];
    }

    console.log(transmitData);

    this._robotService.relativeMove(transmitData);
  }
}