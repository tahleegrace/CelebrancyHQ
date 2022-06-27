import { CeremonyParticipantDTO } from "./ceremony-participant";
import { CeremonyPermissionDTO } from "./ceremony-permission";
import { OrganisationKeyDetailsDTO } from "./organisation-key-details";

export interface CeremonyKeyDetailsDTO {
    id: number;
    name: string;
    ceremonyTypeId: number;
    ceremonyTypeName: string;
    ceremonyTypeCode: string;
    ceremonyDate: Date;
    primaryVenue: OrganisationKeyDetailsDTO;
    participants: CeremonyParticipantDTO[];
    effectivePermissions: CeremonyPermissionDTO[];
}