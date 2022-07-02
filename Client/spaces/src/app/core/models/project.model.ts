import { Article } from "./article.model";
import { Region } from "./region.model";
import { Sector } from "./sector.model";

export class Project extends Article{
    sectorId?:number;
    sector?:Sector;
    regionId?:number;
    region?:Region;
}