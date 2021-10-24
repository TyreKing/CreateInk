import { RequiredValidator } from "@angular/forms";
import { User } from "./user";

export class NewUser{

    constructor(){}

    public firstName: string;
    public lastName: string;
    public birthDate: Date;
    public password: string;
    public email: string;
    public username: string;
    public confirmPassword: string;
    public confirmEmail: string;
}