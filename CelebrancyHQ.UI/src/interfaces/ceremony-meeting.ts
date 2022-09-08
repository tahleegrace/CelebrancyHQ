import { PersonDTO } from "./person";

export interface CeremonyMeetingDTO {
    id: number;
    code: string;
    name: string;
    ceremonyTypeMeetingId: number;
    description: string;
    date: Date;
    participants: PersonDTO[];
}