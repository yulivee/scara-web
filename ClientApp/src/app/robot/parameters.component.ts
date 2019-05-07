import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface RobotParameters {
    zone : number;
    speed: number;
}
@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
  styleUrls: ['./drive.component.css']
})


export class RobotParametersComponent {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
  }
  
  public params : RobotParameters = <RobotParameters>{
    zone : 100,
    speed: 10
  }

  public setParams(): void {
    console.log(this.params);

    this._http.post<any>(this._baseUrl + 'api/RobotJoint/params', this.params).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }

  public setMotorState(state: number): void {
    console.log(this.params);

    this._http.post<any>(this._baseUrl + 'api/RobotJoint/motorState', state).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }

  public zeroAxis(): void {
    console.log(this.params);

    this._http.get<any>(this._baseUrl + 'api/RobotJoint/zeroAxis').subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
}