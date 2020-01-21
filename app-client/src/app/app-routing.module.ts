import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { SignInComponent } from './signIn/sign-in.component';
import { CarDetailsComponent } from './car/car-details/car-details.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path:'car-details/:id',
    component: CarDetailsComponent
  },
  {
    path: 'sign-in',
    component: SignInComponent
  },
  {
    path: 'register',
    component: RegistrationComponent
  },
  {
    path: 'admin-panel',
    loadChildren: () => import('./admin-panel/admin-panel.module').then(mod => mod.AdminPanelModule),
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
