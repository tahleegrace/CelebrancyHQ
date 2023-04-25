import { PersonDTO } from "./person";

export interface FileDTO {
    id: number;
    name: string;
    contentType: string;
    size: number;
    status: string;
    createdBy: PersonDTO;
}

export interface DownloadFileDTO extends FileDTO {
    fileData: string; // Stored in Base64.
}