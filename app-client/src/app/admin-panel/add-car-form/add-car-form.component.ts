import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CarService } from '../services/car.service';
import { ImgFile } from 'src/app/base/models/ImgFile';
import { AddCarDto } from 'src/app/base/models/AddCarDto';

@Component({
  selector: 'app-add-car-form',
  templateUrl: './add-car-form.component.html',
  styleUrls: ['./add-car-form.component.scss']
})
export class AddCarFormComponent implements OnInit {
  addCarForm: FormGroup;
  imgFiles: ImgFile[] = [];
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

  onFileUploaded(event) {
    console.log(event);
    this.imgFiles = event;
  }

  public async onSubmit() {
    const car = <AddCarDto>{
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
