import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RobotJoints } from './RobotJoints';

@Component({
  selector: 'app-abs-drive',
  templateUrl: './abs-drive.component.html',
  styleUrls: ['./drive.component.css']
})
export class AbsoluteDriveComponent {

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

  public setPosition(): void {
    console.log(this.robot);

    this._http.post<any>(this._baseUrl + 'api/RobotJoint/absMove', this.robot).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
}