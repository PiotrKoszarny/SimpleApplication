import { Component, OnInit } from '@angular/core';
import { CarService, GetCarDto } from 'base';

@Component({
  selector: 'app-grid-layout',
  templateUrl: './grid-layout.component.html',
  styleUrls: ['./grid-layout.component.scss']
})
export class GridLayoutComponent implements OnInit {

  cars: GetCarDto[] = [];

  constructor(
    private carService: CarService
  ) { }

  async ngOnInit() {
    await this.getCars();
  }


  async getCars() {
    this.cars = await this.carService.getCars();
  }
}
