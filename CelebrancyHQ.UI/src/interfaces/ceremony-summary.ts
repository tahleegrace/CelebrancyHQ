import { OrganisationKeyDetailsDTO } from "./organisation-key-details";

export interface CeremonySummaryDTO {
    id: number;
    name: string;
    ceremonyDate: Date,
    primaryVenue: OrganisationKeyDetailsDTO;
}