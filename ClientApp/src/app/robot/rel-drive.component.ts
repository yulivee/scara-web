import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RobotJoints } from './RobotJoints';


@Component({
  selector: 'app-rel-drive',
  templateUrl: './rel-drive.component.html'
})
export class RelativeDriveComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const data = <RobotJoints> {
      joint1: 1
    };
    
    http.post<any>(baseUrl + 'api/RobotJoint/relMove',data).subscribe(result => {
    }, error => console.error(error));
  }
}