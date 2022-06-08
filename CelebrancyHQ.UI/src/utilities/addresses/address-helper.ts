import { AddressDTO } from "../../interfaces/address";

export function formatAddress(address: AddressDTO | null) {
    if (address) {
        return `${address.streetAddress}, ${address.suburb}, ${address.state}, ${address.postcode}`;
    } else {
        return null;
    }
}