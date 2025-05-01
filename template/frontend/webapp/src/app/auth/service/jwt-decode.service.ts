import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { JWTTokenModel } from '../model/jwt-token.model';

@Injectable({
  providedIn: 'root'
})
export class JwtDecodeService {

  constructor() { }

  public jwtDecode(token: string): JWTTokenModel | null {
    try {
      const decodedToken = jwtDecode(token);
      console.log(decodedToken); // This will output the decoded token as a JSON object
      const model = decodedToken as JWTTokenModel;
      return model;
    } catch(Error) {
      console.error('Invalid JWT format');
      return null;
    }
  }
}
