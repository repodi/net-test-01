export class BaseResponseApiDataModel {
    success: boolean;
    message: string = "";
    errors: string[] =[];
    data: any;

    constructor(success: boolean, message: string, errors: string[], data: any){
        this.success = success;
        this.message = message;
        this.errors = errors;
        this.data = data;
    }
}
