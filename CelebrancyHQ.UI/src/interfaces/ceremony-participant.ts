import { PersonDTO } from "./person";

export interface CeremonyParticipantDTO extends PersonDTO {
    code: string;
    name: string;
}