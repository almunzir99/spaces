import { Base } from "./base.model";
import { Permission } from "./permission.model";

export class Role extends Base{
    title:string;
    messagesPermissions:Permission;
    rolesPermissions:Permission;
    usersPermissions:Permission;
    articlesPermissions:Permission;
    projectsPermissions:Permission;
    sectorsPermissions:Permission;
    regionsPermissions:Permission;
    sliderPermissions:Permission;
    teamPermissions:Permission;
    partnersPermissions:Permission;
    testimonialsPermissions:Permission;
    mediaPermissions:Permission;
    volunteersPermissions:Permission;

    

}