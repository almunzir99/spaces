import { Base } from "./base.model";
import { Sector } from "./sector.model";


export interface Volunteer extends Base {
    firstName: string;
    lastName: string;
    email: string;
    phone: string;
    birthDate: string;
    gender: number;
    cVLink: string;
    reason: string;
    educationLevel: number;
    sectorId: number;
    sector: Sector;
}