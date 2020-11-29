import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit {
  loginsession: boolean;
  userName: string = '';

  constructor(private router: Router) { }

  ngOnInit() {

    if (sessionStorage.getItem('email'))
    {
      this.loginsession = true;
      this.userName = sessionStorage.getItem('userName');
    } else {
      this.loginsession = false;
    }
  }

  logOff() {
    sessionStorage.clear();
    this.loginsession = false;
    this.router.navigate(['/home']);
  }

}
