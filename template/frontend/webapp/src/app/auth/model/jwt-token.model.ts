export class JWTTokenModel {
    role: string = "";
    email: string = "";
    
    constructor(jwtObject: any){
        this.role = jwtObject.role;
        this.email = jwtObject.email;
    }
}
