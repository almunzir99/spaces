import { Activity } from "./activity.model";
import { ApiNotification } from "./api-notification.model";
import { Base } from "./base.model";
import { Role } from "./role.model";

export class User extends Base{
    username:string;
    phone:string;
    password?:string;
    image:string;
    email:string;
    activities:Activity[];
    roleId:number;
    role:Role;
    token:string;
    isManager:boolean;
    notification:ApiNotification[]
}
