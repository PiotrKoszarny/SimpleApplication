import { Component, OnInit } from '@angular/core';
import { CarService, GetCarDetailsDto } from 'src/app/api/base';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.scss']
})
export class CarDetailsComponent implements OnInit {
  car: GetCarDetailsDto;

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
