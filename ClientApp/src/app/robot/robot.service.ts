import { Injectable, Inject } from '@angular/core';
import { RobotJoints } from './RobotJoints';
import { HttpClient } from '@angular/common/http';
import { RobotParameters } from './RobotParameters';


@Injectable({
  providedIn: 'root'
})
/**
 * this is the central robot interaction service
 */
export class RobotService {
  
  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
    this._baseUrl += 'api/RobotJoint/';
  }

  public relativeMove(robotJoints: RobotJoints): void {
    this._http.post<any>(this._baseUrl + 'relMove', robotJoints).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }

  public absoluteMove(robotJoints: RobotJoints): void {
    this._http.post<any>(this._baseUrl + 'absMove', robotJoints).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }

  public setRobotParameters(parameters: RobotParameters): void {
    this._http.post<any>(this._baseUrl + 'params', parameters).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
  public setMotorState(state: boolean): void {
    this._http.post<any>(this._baseUrl + 'motorState', state).subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }

  public zeroAxis(): void {
    this._http.get<any>(this._baseUrl + 'zeroAxis').subscribe(result => {
      console.log('result of http post!', result);
    }, error => console.error(error));
  }
}
