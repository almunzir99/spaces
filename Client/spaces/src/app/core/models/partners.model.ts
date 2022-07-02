import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Partners extends Base{
    logo?:Image;
    name?:Translation;
    url?:string;
}