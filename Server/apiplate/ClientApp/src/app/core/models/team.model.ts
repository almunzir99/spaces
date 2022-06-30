import { Base } from "./base.model";
import { Image } from "./image.model";
import { Translation } from "./translation.model";

export class Team extends Base {
   name:Translation;
   position:Translation;
   image:Image;
   priority:number;
   facebook:string;
   twitter:string;
   instgram:string;
   linkedIn:string;
}