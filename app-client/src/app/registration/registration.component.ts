import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService, RegisterViewModel } from '../api/base';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private accountService: AccountService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      'email': ['', Validators.compose([Validators.required])],
      'password': ['', [Validators.required, Validators.minLength(2)]],
      'confirmPassword': ['']
    },
      { validator: this.checkPasswords });
  }

  public async register() {
    const register = <RegisterViewModel>{
      email: this.registerForm.get('email').value,
      password: this.registerForm.get('password').value,
      confirmPassword: this.registerForm.get('confirmPassword').value,
    }
    const result = await this.accountService.postRegister(register)
    if (result) {
      this.toastr.success('Registration successful')
    } else {
      this.toastr.error('Something gone wrong!')
    }
  }

  private checkPasswords(group: FormGroup) {
    const password = group.get('password').value;
    const confirmPassword = group.get('confirmPassword').value;

    return password === confirmPassword ? null : { notSame: true }
  }

}
