import { Base } from "./base.model";
import { Image } from "./image.model";
import { Tag } from "./tag.model";
import { Translation } from "./translation.model";
import { User } from "./user.model";

export class Article extends Base {
    title?: Translation;
    subtitle?: Translation;
    content?: Translation;
    comment?: Translation;
    tags?: Tag[];
    comments?:Comment[];
    image?:Image;
    authorId?:number;
    author?:User;

}