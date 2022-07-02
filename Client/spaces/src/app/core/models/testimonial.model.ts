import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Testimonial extends Base{
    content?:Translation;
    author?:Translation;
    job?:Translation;
    image?:Image;


}