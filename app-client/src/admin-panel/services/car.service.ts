import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Car } from 'src/app/models/Car';
import { apiUrl } from 'src/app/config';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public addCar(car: Car): Promise<Car> {
    return this.httpClient.post<Car>(`${apiUrl}/admin/create-car`, car).toPromise();
  }
}
