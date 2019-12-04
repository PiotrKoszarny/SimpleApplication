import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomepageComponent } from './homepage/homepage.component';
import { AddCarFormComponent } from './add-car-form/add-car-form.component';
import { FormsModule } from '@angular/forms';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AdminPanelRoutingModule
  ],
  declarations: [
    HomepageComponent,
    AddCarFormComponent
  ]
})
export class AdminPanelModule { }
