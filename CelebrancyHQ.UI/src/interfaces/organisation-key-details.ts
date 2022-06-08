import { AddressDTO } from "./address";

export interface OrganisationKeyDetailsDTO {
    id: number;
    name: string;
    emailAddress?: string;
    primaryPhoneNumber?: string;
    address?: AddressDTO;
}