import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { User } from '../models/User';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: AuthenticationService
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
    const register = <User>{
      email: this.registerForm.get('email').value,
      password: this.registerForm.get('password').value,
      confirmPassword: this.registerForm.get('confirmPassword').value,
    }
    const result = await this.userService.register(register)
    console.log(result);

  }

  private checkPasswords(group: FormGroup) {
    const password = group.get('password').value;
    const confirmPassword = group.get('confirmPassword').value;

    return password === confirmPassword ? null : { notSame: true }
  }

}
