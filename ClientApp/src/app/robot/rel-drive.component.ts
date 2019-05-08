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
    this.robot[field] += this.stepWidth;

    this.setPosition(field);
  }

  public decrement(field: string): void {
    this.robot[field] -= this.stepWidth;

    this.setPosition(field);
  }

  public setPosition(field: string): void {
    const transmitData: RobotJoints = new RobotJoints();
    transmitData[field] = this.robot[field];

    console.log(this.robot);

    this._robotService.relativeMove(this.robot);
  }
}