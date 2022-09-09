import { PersonDTO } from "./person";

export interface CeremonyMeetingDTO {
    id: number;
    ceremonyTypeMeetingCode: string;
    ceremonyTypeMeetingName: string;
    ceremonyTypeMeetingId: number;
    name: string;
    description: string;
    date: Date;
    participants: PersonDTO[];
}