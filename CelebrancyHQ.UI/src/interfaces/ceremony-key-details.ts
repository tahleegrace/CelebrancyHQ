import { CeremonyParticipantDTO } from "./ceremony-participant";
import { OrganisationKeyDetailsDTO } from "./organisation-key-details";

export interface CeremonyKeyDetailsDTO {
    id: number;
    name: string;
    ceremonyTypeName: string;
    ceremonyTypeCode: string;
    ceremonyDate: Date;
    primaryVenue: OrganisationKeyDetailsDTO;
    participants: CeremonyParticipantDTO[];
}