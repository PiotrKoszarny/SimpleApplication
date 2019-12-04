import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Car } from 'src/app/models/Car';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-add-car-form',
  templateUrl: './add-car-form.component.html',
  styleUrls: ['./add-car-form.component.scss']
})
export class AddCarFormComponent implements OnInit {
  addCarForm: any;

  constructor(
    private formBuilder: FormBuilder,
    private carService: CarService
  ) {
    this.addCarForm = this.formBuilder.group({
      'brand': [''],
      'model': [''],
      'productionDate': [''],
      'mileage': [''],
    })
  }

  ngOnInit() {
  }

  public async addCar() {
    const car = <Car>{
      brand: this.addCarForm.get('brand').value,
      model: this.addCarForm.get('model').value,
      productionDate: this.addCarForm.get('productionDate').value,
      mileage: this.addCarForm.get('mileage').value,
    }

    const result = await this.carService.addCar(car);
    console.log(result);

  }

}
