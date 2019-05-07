import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RobotJoints } from './RobotJoints';

@Component({
  selector: 'app-program',
  templateUrl: './programming.component.html',
  styleUrls: ['./drive.component.css']
})

export class ProgrammingComponent {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
  }

  public program : string;

  public robot: RobotJoints = new RobotJoints();

  public teachCurrentPos(): void {
    this._http.get<any>(this._baseUrl + 'api/RobotJoint/currentPos').subscribe(result => {
      console.log('10,', result);
      this.program.concat('10,'+result);
    }, error => console.error(error));
  }

  public runProgram(): void {

      let programLines : Array<string>;
      programLines = this.program.split('\n');
      programLines.forEach( line => { line.concat('\n'); });

      programLines.forEach( line => {
        this._http.post<any>(this._baseUrl + 'api/RobotJoint/runCmd', line).subscribe(result => {
          console.log('result of http post!', result);
        }, error => console.error(error));

      })

  }

  public pauseProgram(): void {

  }

  public stopProgram(): void {

  }
}