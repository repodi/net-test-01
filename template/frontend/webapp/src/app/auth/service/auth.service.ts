import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, catchError, Observable, tap, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { BaseResponseApiModel } from '../../shared/model/base-response-api.model';
import { AuthModel } from '../model/auth.model';
import { JwtDecodeService } from './jwt-decode.service';
import { ProfileModel as UserProfileModel } from '../model/profile.model';
import { JWTTokenModel } from '../model/jwt-token.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenSubject = new BehaviorSubject<string | null>(null);
  private userRole = new BehaviorSubject<string | null>(null);
  userRole$ = this.userRole.asObservable();
  private authenticated = new BehaviorSubject<boolean>(false);
  authenticated$ = this.authenticated.asObservable();
  private userProfile = new BehaviorSubject<UserProfileModel | null>(null);
  userProfile$ = this.userProfile.asObservable();

  constructor(private http: HttpClient, 
    private router: Router,
    private jwtDecodeService: JwtDecodeService) {
    const token = localStorage.getItem('token');
    if (token) {
      this.tokenSubject.next(token);
      this.authenticated.next(true);
    }else 
      this.authenticated.next(false);
  }

  login(credentials: { username: string; password: string }) {
    return this.http.post<any>(`${environment.apiBaseUrl}/Auth`, credentials).pipe(
      tap(res => {
        const response = res as BaseResponseApiModel;
        if (response.success && response.data.success){
            const authenticatedResult = response.data.data as AuthModel;
            localStorage.setItem('token', authenticatedResult.token);
            let tokenJSON = this.jwtDecodeService.jwtDecode(authenticatedResult.token);
            //localStorage.setItem('refreshToken', res.refreshToken);
            this.tokenSubject.next(authenticatedResult.token);
            if (tokenJSON){
              this.userRole.next(tokenJSON.role);
              this.setUserProfileModel(tokenJSON, response.data.data);
            }
            this.authenticated.next(true);
        }else
         throwError(() => new Error('An error occurred while fetching data.'));
      })
    );
  }

  

  logout() {
    localStorage.clear();
    this.tokenSubject.next(null);
    this.userRole.next(null);
    this.authenticated.next(false);
    this.router.navigate(['/login']);
  }

  get token() {
    return this.tokenSubject.value;
  }

  get role() {
    return this.userRole.value;
  }

  get isAuthenticated() {
    return this.authenticated.value;
  }

  isInRole(acceptedRoles: string[]): boolean {
    if (!acceptedRoles)
      return false;

    if (!this.role)
      return false; 

    if (!acceptedRoles.includes(this.role)) {
      return false;
    }
    return true;
  }

  refreshToken() {
    const refreshToken = localStorage.getItem('refreshToken');
    return this.http.post<any>(`${environment.apiBaseUrl}/auth/refresh`, { refreshToken }).pipe(
      tap(res => {
        localStorage.setItem('token', res.token);
        this.tokenSubject.next(res.token);
      })
    );
  }

  setUserProfileModel(token: JWTTokenModel, dataResponse: any): void{
    let userProfile = new UserProfileModel();
    userProfile.email = dataResponse.email;
    userProfile.role = token.role;
    userProfile.name = dataResponse.name;
    this.userProfile.next(userProfile);
  }
}
