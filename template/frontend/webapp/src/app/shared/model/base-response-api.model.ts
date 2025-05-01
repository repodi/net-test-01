import { BaseResponseApiDataModel } from "./base-response-api-data.model";

export class BaseResponseApiModel {
    success: boolean;
    message: string = "";
    errors: string[] =[];
    data: BaseResponseApiDataModel;

    constructor(success: boolean, message: string, errors: string[], data: BaseResponseApiDataModel){
        this.success = success;
        this.message = message;
        this.errors = errors;
        this.data = data;
    }
}
