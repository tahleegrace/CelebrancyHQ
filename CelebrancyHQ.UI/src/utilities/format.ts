import moment from "moment";
import { AddressDTO } from "../interfaces/address";

export function formatDate(date: Date) {
    return moment(date).format('dddd MMMM DD YYYY h:mm A');
}

export function formatAddress(address: AddressDTO) {
    return `${address.streetAddress}, ${address.suburb}, ${address.state}, ${address.postcode}`;
}