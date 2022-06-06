import { AddressDTO } from "../interfaces/address";
import { UserDTO } from "../interfaces/user";

export function getUserFullName(user: UserDTO) {
    return `${user.firstName} ${user.lastName} ${user.businessName ? `(${user.businessName})` : ''}`;
};

export function formatAddress(address: AddressDTO) {
    return `${address.streetAddress}, ${address.suburb}, ${address.state}, ${address.postcode}`;
}