import { User } from "oidc-client";
import { Base } from "./base.model";
import { Image } from "./image.model";
import { Tag } from "./tag.model";
import { Translation } from "./translation.model";

export class Article extends Base {
    title: Translation;
    subtitle: Translation;
    content: Translation;
    comment: Translation;
    tags: Tag[];
    comments:Comment[];
    image:Image;
    authorId:number;
    author:User;

}