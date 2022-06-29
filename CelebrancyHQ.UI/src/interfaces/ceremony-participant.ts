import { PersonDTO } from "./person";

export interface CeremonyParticipantDTO extends PersonDTO {
    id: number;
    code: string;
    name: string;
}