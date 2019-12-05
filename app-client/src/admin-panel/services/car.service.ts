import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Car } from 'src/app/models/Car';
import { apiUrl } from 'src/app/config';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(
    private httpClient: HttpClient
  ) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  }

  public addCar(car: Car): Promise<Car> {
    return this.httpClient.post<Car>(`${apiUrl}/admin/car/create-car`, car, this.httpOptions).toPromise();
  }
}
