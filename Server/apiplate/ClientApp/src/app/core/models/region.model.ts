import { Base } from "./base.model";
import { Translation } from "./translation.model";

export class Region extends Base{
    code:string;
    title:Translation;
    description:Translation;
    Image:Translation;

}