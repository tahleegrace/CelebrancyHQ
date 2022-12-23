import { PersonDTO } from "./person";

export interface FileDTO {
    id: number;
    name: string;
    contentType: string;
    size: number;
    status: string;
    createdBy: PersonDTO;
}