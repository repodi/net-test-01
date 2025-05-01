import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { RoleEnum } from '../../shared/enum/role.enum';

@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const roles = route.data['roles'];
    if(!roles){
      this.router.navigate(['/unauthorized']);
      return false;
    }

    if (!this.authService.role)
      return false; 
    
    let expectedRoles: string[] = Array.isArray(roles)
      ? roles.filter(item => typeof item === "string") 
      : [];
    
    if (!expectedRoles.includes(this.authService.role)) {
      this.router.navigate(['/unauthorized']);
      return false;
    }
    return true;
  }
}