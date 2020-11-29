import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistrationService } from '../services/registration.service';
import { login } from '../login/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  loginobject: login = new login();
  err: string;
  loginForm: FormGroup;
  constructor(private router: Router, private registrationService: RegistrationService) {
    this.loginForm = new FormGroup({
      mailid: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, Validators.required)
    });

  }

  doLogin() {
    this.registrationService.Login(this.loginobject).subscribe((response: any) => {
      if (response.IsValidUser) {
        sessionStorage.setItem('email', this.loginobject.email);
        sessionStorage.setItem('userId', response.UserId);
        sessionStorage.setItem('userName', response.UserName);
        this.router.navigate(['home']);
      }
      else {
        this.err = 'Invalid username or password!!';
      }
    });
  }


  ngOnInit(): void {
  }

}
