import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Sector extends Base{
    title?:Translation;
    description?:Translation;
    icon?:Image;
    image?:Image;
}