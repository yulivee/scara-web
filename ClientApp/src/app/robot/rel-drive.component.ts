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

    this._http.post<any>(this._baseUrl + 'api/RobotJoint/relMove', transmitData).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
}