import { AddressDTO } from "./address";

export interface CeremonySummaryDTO {
    id: number;
    name: string;
    ceremonyDate: Date,
    primaryVenueName: string;
    primaryVenueAddress: AddressDTO;
}