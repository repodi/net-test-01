import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/service/auth.service';
import { RoleEnum } from '../../enum/role.enum';
import { ProfileModel } from '../../../auth/model/profile.model';

@Component({
  selector: 'app-menu',
  standalone: false,
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {
  role: string | null;
  authenticatedUser = false;
  roleEnum: typeof RoleEnum = RoleEnum;
  showProfile = false;
  profile: ProfileModel;
  
  constructor(private authService: AuthService, private router: Router) {
    this.role = null; 
    this.profile = new ProfileModel();
    if (this.authService.role)
      this.role = this.authService.role;
  }

  ngOnInit(): void{
    this.authService.authenticated$.subscribe(status => {
      this.authenticatedUser = status;
    });
    this.authService.userRole$.subscribe(role => {
      if (role){
        this.role = role;
      }
      else 
        this.role = null;
    });
    this.authService.userProfile$.subscribe(prof => {
      if (prof){        
        this.profile = prof;
      }
      else 
        this.profile = new ProfileModel();
    });
  }

  logout() {
    this.authService.logout();
  }

  isInRole(acceptedRoles: string[]): boolean{
    return this.authService.isInRole(acceptedRoles);
  }


  toggleProfile() {
    this.showProfile = !this.showProfile;
  }
  
}
