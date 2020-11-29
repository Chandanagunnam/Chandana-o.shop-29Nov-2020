import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Forgotmodel } from '../forgotmodel';
import { MustMatch } from '../mustmatch';
import { RegistrationService } from '../services/registration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  forgotModel: Forgotmodel = new Forgotmodel();
  forgotForm: FormGroup;
  submitted = false;
  emailId: string = '';
  isValidEmailId: boolean = false;
  errorMsg: string = '';

  constructor(private formBuilder: FormBuilder, private registrationService: RegistrationService, private router: Router) { }

  ngOnInit(): void {
    this.forgotForm = this.formBuilder.group({
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      OTP: ['', [Validators.required, Validators.minLength(6)]]
    },
      { validator: MustMatch('password', 'confirmPassword') }
    );
  }

  get f() { return this.forgotForm.controls; }

  VerifyEmail() {
    this.registrationService.ForgotPassword(this.emailId).subscribe((response: any) => {
      if (response == "Success") {
        this.isValidEmailId = true;
        this.errorMsg = '';
      }
      else {
        this.errorMsg = 'Invalid User';
      }
    });
  }

  ChangePassword(model) {
    this.submitted = true;
    if (this.forgotForm.invalid) {
      return;
    }
    model.EmailId = this.emailId;
    this.registrationService.ChangePassword(model).subscribe((response: any) => {
      if (response == "Success") {
        alert("Password changed Successfully.");
        this.router.navigate(['login']);
      }
      else {
        this.errorMsg = response;
      }
    });
  }
}
