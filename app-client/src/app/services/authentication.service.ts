import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserLoginApiResult } from '../models/UserLoginApiResult';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private httpClient: HttpClient) { }

  register(user: User): Promise<boolean> {
    return this.httpClient.post<boolean>(`${environment.basePath}/account/register`, user).toPromise();
  }

  signIn(user: User): Promise<boolean> {
    return this.httpClient.post<UserLoginApiResult>(`${environment.basePath}/account/sign-in`, user)
      .pipe(
        map(response => {
          if(response.token){
            localStorage.setItem('token', response.token);
          }

          return response.isSuccessed;
        })).toPromise();
  }
}
