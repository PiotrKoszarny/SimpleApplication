import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCarFormComponent } from './add-car-form/add-car-form.component';
import { HomepageComponent } from './homepage/homepage.component';


const adminRoutes: Routes = [
  {
    path: '', component: HomepageComponent
  },
  {
    path: 'add-car', component: AddCarFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminPanelRoutingModule { }
