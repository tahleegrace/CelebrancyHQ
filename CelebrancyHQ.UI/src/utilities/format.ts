import { AddressDTO } from "../interfaces/address";
import { PersonDTO } from "../interfaces/person";

export function getUserFullName(user: PersonDTO) {
    return `${user.firstName} ${user.lastName} ${user.businessName ? `(${user.businessName})` : ''}`;
};

export function formatAddress(address: AddressDTO) {
    return `${address.streetAddress}, ${address.suburb}, ${address.state}, ${address.postcode}`;
}