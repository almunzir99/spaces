import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Region extends Base{
    code?:string;
    title?:Translation;
    description?:Translation;
    image?:Image;

}