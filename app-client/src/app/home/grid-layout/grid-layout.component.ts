import { Component, OnInit } from '@angular/core';
import { CarService, GetCarDto } from 'base';

@Component({
  selector: 'app-grid-layout',
  templateUrl: './grid-layout.component.html',
  styleUrls: ['./grid-layout.component.scss']
})
export class GridLayoutComponent implements OnInit {

  constructor(
    private carService: CarService
  ) { }

  async ngOnInit() {
    await this.getCars();
  }


  async getCars() {
    const cars = await this.carService.getCars();
    console.log(cars);

  }
}
