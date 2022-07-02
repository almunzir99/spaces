import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Slider extends Base {
    title?:Translation;
    subtitle?:Translation;
    description?:Translation;
    image?:Image;
    url?:string;
}