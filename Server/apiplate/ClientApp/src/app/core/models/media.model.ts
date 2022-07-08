import { Base } from "./base.model";
import { Image } from "./image.model";

export class Media extends Base {
    thumbnail: Image;
    url: string;
    mediaType: string;
    mainVideo: boolean | null;
}