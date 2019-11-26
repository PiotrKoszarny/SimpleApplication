import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { apiUrl } from '../config';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  register(user: User): Promise<boolean> {
    return this.httpClient.post<boolean>(`${apiUrl}/account/register`, user).toPromise();
  }
}
