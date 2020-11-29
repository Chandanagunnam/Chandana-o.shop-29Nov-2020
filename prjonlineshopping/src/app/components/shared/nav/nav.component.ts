import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  title: string = 'prjonlineshopping';
  loginsession: boolean;
  userName: string = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  ngDoCheck() {
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
