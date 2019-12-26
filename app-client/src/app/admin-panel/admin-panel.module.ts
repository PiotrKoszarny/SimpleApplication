import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomepageComponent } from './homepage/homepage.component';
import { AddCarFormComponent } from './add-car-form/add-car-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { MatFormFieldModule, MatInputModule, MatDatepickerModule, MatNativeDateModule } from '@angular/material';
import { DragFileComponent } from './drag-file/drag-file.component';
import { DragDropDirective } from './drag-file/DragDropDirective';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AdminPanelRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  declarations: [
    HomepageComponent,
    AddCarFormComponent,
    DragFileComponent,
    DragDropDirective
  ],
  providers: [
    // {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUtc: true}}
  ]
})
export class AdminPanelModule { }
