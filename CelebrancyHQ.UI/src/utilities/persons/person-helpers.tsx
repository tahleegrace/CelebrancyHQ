import { Fragment } from "react";
import { PersonDTO } from "../../interfaces/person";

export function getPersonFullName(person: PersonDTO, includePreferredName = false) {
    return `${person.firstName} ${person.lastName} ${includePreferredName && person.preferredName ? `(${person.preferredName})` : ''}`;
}

export function getFullNamesForPersons(persons: PersonDTO[], includePreferredNames = false) {
    return persons.map(person => getPersonFullName(person, includePreferredNames)).join(", ");
}

export function getPersonFullNameAndBusinessName(person: PersonDTO) {
    return `${getPersonFullName(person)} ${person.organisationName ? `(${person.organisationName})` : ''}`;
};

export function getPersonAndContactDetailsDisplay(person: PersonDTO) {
    return (
        <p className="mb-0" key={person.personId}>
            {getPersonFullName(person, true)}
            {person.primaryPhoneNumber ? (<Fragment><br /><a href={'tel:' + person.primaryPhoneNumber}>{person.primaryPhoneNumber}</a></Fragment>) : ''}
            {person.emailAddress ? (<Fragment><br /><a href={'mailto:' + person.emailAddress}>{person.emailAddress}</a></Fragment>) : ''}
        </p>  
    );
}