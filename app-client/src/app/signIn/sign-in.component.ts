import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService, UserLoginDto } from '../api/base';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  public signInForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private accountService: AccountService
  ) { }

  ngOnInit() {
    this.signInForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required])],
      password: ['', [Validators.required, Validators.minLength(2)]]
    });
  }

  private get form() { return this.signInForm.controls }

  async signIn() {
    const user = <UserLoginDto>{
      email: this.form.email.value,
      password: this.form.password.value
    }

    const result = await this.accountService.postSignIn(user);
  }
}
