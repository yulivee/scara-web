import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RobotJoints } from './RobotJoints';


@Component({
  selector: 'app-rel-drive',
  templateUrl: './rel-drive.component.html',
  styleUrls: ['./drive.component.css']
})
export class RelativeDriveComponent {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
  }

  public robot: RobotJoints = <RobotJoints>{
    joint1: 0,
    joint2: 0,
    joint3: 0,
    joint4: 0,
    joint5: 0,
    joint6: 0,
    gripper: 0
  };

  public increment(field: string): void {
    this.robot[field] += 10;

    this.setPosition(field);
  }

  public decrement(field: string): void {
    this.robot[field] -= 10;

    this.setPosition(field);
  }

  public setPosition(field: string): void {
    const transmitData: RobotJoints = <RobotJoints>{
      joint1: 0,
      joint2: 0,
      joint3: 0,
      joint4: 0,
      joint5: 0,
      joint6: 0,
      gripper: 0
    };
    transmitData[field] = this.robot[field];

    console.log(this.robot);

    this._http.post<any>(this._baseUrl + 'api/RobotJoint/relMove', transmitData).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
}