import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './pages/menu/menu.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppRoutingModule } from '../app-routing.module';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [  
    MenuComponent, 
    DashboardComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    AppRoutingModule,
    MatIconModule
  ],
  exports: [
    MenuComponent,
    MatSnackBarModule
  ]
})
export class SharedModule { }
