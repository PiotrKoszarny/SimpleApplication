import { Component, OnInit } from '@angular/core';
import { CarService, GetCarDetailsDto } from 'src/app/api/base';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.scss']
})
export class CarDetailsComponent implements OnInit {
  car: GetCarDetailsDto;
  public baseUrl = environment.baseUrl;

  constructor(
    private route: ActivatedRoute,
    private carService: CarService
  ) { }

  async ngOnInit() {
    const carId = this.route.snapshot.paramMap.get('id');
        
    this.car = await this.carService.getCar(Number(carId));

    console.log(this.car);
    
  }
}
