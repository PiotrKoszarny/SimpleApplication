import { Component, OnInit, Input } from '@angular/core';
import { GetCarDto } from 'src/app/api/base';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-car-element',
  templateUrl: './car-element.component.html',
  styleUrls: ['./car-element.component.scss']
})
export class CarElementComponent implements OnInit {
  @Input() car: GetCarDto;
  public baseUrl = environment.baseUrl;
  constructor() { }

  ngOnInit() {
    console.log(this.car);
  }
}
