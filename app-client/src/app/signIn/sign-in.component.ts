import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { User } from '../base/models/User';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  public signInForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: AuthenticationService
  ) { }

  ngOnInit() {
    this.signInForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required])],
      password: ['', [Validators.required, Validators.minLength(2)]]
    });
  }

  private get form() { return this.signInForm.controls }

  async signIn() {
    const user = <User>{
      email: this.form.email.value,
      password: this.form.password.value
    }

    const result = await this.userService.signIn(user);
  }
}
