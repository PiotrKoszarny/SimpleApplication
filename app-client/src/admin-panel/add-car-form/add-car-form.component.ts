import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Car } from 'src/app/models/Car';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-add-car-form',
  templateUrl: './add-car-form.component.html',
  styleUrls: ['./add-car-form.component.scss']
})
export class AddCarFormComponent implements OnInit {
  addCarForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private carService: CarService
  ) { }

  ngOnInit() {
    this.addCarForm = this.formBuilder.group({
      'brand': [''],
      'model': [''],
      'productionDate': [''],
      'mileage': ['']
    })
  }

  public async onSubmit() {
    const car = <Car>{
      brand: this.addCarForm.get('brand').value,
      model: this.addCarForm.get('model').value,
      productionDate: this.addCarForm.get('productionDate').value,
      mileage: parseInt(this.addCarForm.get('mileage').value),
    }
console.log(car);

    const result = await this.carService.addCar(car);
    console.log(result);
  }

}
