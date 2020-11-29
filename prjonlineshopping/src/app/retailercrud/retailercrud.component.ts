import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from '../mustmatch';
import { RegistrationModel } from '../models/registration-model';
import { RegistrationService } from '../services/registration.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-retailercrud',
  templateUrl: './retailercrud.component.html',
  styleUrls: ['./retailercrud.component.css']
})
export class RetailercrudComponent implements OnInit {
  registrationModel: RegistrationModel = new RegistrationModel();
  registerForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private registrationService: RegistrationService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    },
      { validator: MustMatch('password', 'confirmPassword') }
    );
  }
  get f() { return this.registerForm.controls; }

  onSubmit(model) {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }
    model.Role = 'User';
    this.registrationService.Register(model).subscribe((response: any) => {
      this.submitted = false;
      alert("Retailer Registered Succesfully");
      this.registrationModel = new RegistrationModel();
      if (response.IsValid) {

      }
    });

  }
  // GetProducts() {
  //   this.prodservice.getProduct().subscribe((data: any) => {
  //     this.products = data;
  //   });
  // openDeletePopup(contentdelete, id) {
  //   this.deleteProductId = id;
  //   this.modalService.open(contentdelete);
  // }


}
