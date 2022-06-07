import moment from "moment";
import { AddressDTO } from "../interfaces/address";
import { PersonDTO } from "../interfaces/person";

export function getUserFullName(user: PersonDTO) {
    return `${user.firstName} ${user.lastName}`;
}

export function getUserFullNameAndBusinessName(user: PersonDTO) {
    return `${getUserFullName(user)} ${user.businessName ? `(${user.businessName})` : ''}`;
};

export function formatDate(date: Date) {
    return moment(date).format('dddd MMMM DD YYYY h:mm A');
}

export function formatAddress(address: AddressDTO) {
    return `${address.streetAddress}, ${address.suburb}, ${address.state}, ${address.postcode}`;
}