import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { apiUrl } from '../config';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private httpClient: HttpClient) { }

  register(user: User): Promise<boolean> {
    return this.httpClient.post<boolean>(`${apiUrl}/account/register`, user).toPromise();
  }

  signIn(user: User): Promise<any> {
    return this.httpClient.post<any>(`${apiUrl}/account/sign-in`, user)
      .pipe(
        map(response => {
          console.log(response);
        })).toPromise();
  }
}
