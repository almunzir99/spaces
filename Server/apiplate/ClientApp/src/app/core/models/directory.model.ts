import { FileModel } from "./File.Model";

export class DirectoryModel {
    title: string;
    uri: string;
    parentDirectory: string;
    files: FileModel[];
    directories: DirectoryModel[];
    size: string;
    createdAt: Date;
    lastUpdate: Date;
}
