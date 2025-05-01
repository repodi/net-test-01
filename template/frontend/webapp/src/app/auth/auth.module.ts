import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { AuthService } from './service/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtDecodeService } from './service/jwt-decode.service';
import { UnauthorizedComponent } from './pages/unauthorized/unauthorized.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  providers:[
    AuthService,    
    JwtDecodeService
  ],
  declarations: [   
   LoginComponent, UnauthorizedComponent
  ],
  imports: [    
    CommonModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  exports: [
    UnauthorizedComponent
  ]
})
export class AuthModule { }
