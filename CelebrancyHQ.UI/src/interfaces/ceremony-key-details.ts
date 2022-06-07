import { AddressDTO } from "./address";
import { CeremonyParticipantDTO } from "./ceremony-participant";

export interface CeremonyKeyDetailsDTO {
    id: number;
    name: string;
    ceremonyTypeName: string;
    ceremonyTypeCode: string;
    ceremonyDate: Date;
    primaryVenueName: string;
    primaryVenueAddress: AddressDTO;
    participants: CeremonyParticipantDTO[];
}