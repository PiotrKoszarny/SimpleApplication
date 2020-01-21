import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule, MatInputModule, MatIconModule } from '@angular/material';
import {MatSidenavModule} from '@angular/material/sidenav';
import { SignInComponent } from './signIn/sign-in.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ToastrModule } from 'ngx-toastr';
import { CarElementComponent } from './car/car-element/car-element.component';
import { GridLayoutComponent } from './car/grid-layout/grid-layout.component';
import { CarDetailsComponent } from './car/car-details/car-details.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    SignInComponent,
    HomeComponent,
    NavComponent,
    CarElementComponent,
    GridLayoutComponent,
    CarDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSidenavModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
