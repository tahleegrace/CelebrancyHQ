import { PersonDTO } from "../../interfaces/person";

// TODO: Add support for preferred names here.
export function getUserFullName(user: PersonDTO) {
    return `${user.firstName} ${user.lastName}`;
}

export function getUserFullNameAndBusinessName(user: PersonDTO) {
    return `${getUserFullName(user)} ${user.businessName ? `(${user.businessName})` : ''}`;
};