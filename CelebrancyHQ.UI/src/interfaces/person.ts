import { AddressDTO } from "./address";
import { PhoneNumberDTO } from "./phone-number";

export interface PersonDTO {
    personId: number;
    userId?: number;
    firstName: string;
    middleNames?: string;
    lastName: string;
    preferredName?: string;
    title?: string;
    gender: string;
    organisationName?: string;
    emailAddress: string;
    primaryPhoneNumber?: string;
    phoneNumbers: PhoneNumberDTO[];
    address: AddressDTO;
}