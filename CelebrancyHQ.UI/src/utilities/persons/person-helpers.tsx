import { Fragment } from "react";
import { PersonDTO } from "../../interfaces/person";

export function getUserFullName(user: PersonDTO, includePreferredName = false) {
    return `${user.firstName} ${user.lastName} ${includePreferredName && user.preferredName ? `(${user.preferredName})` : ''}`;
}

export function getFullNamesForUsers(users: PersonDTO[], includePreferredNames = false) {
    return users.map(user => getUserFullName(user, includePreferredNames)).join(", ");
}

export function getUserFullNameAndBusinessName(user: PersonDTO) {
    return `${getUserFullName(user)} ${user.organisationName ? `(${user.organisationName})` : ''}`;
};

export function getUserAndContactDetailsDisplay(user: PersonDTO) {
    return (
        <p className="mb-0" key={user.personId}>
            {getUserFullName(user, true)}
            {user.primaryPhoneNumber ? (<Fragment><br /><a href={'tel:' + user.primaryPhoneNumber}>{user.primaryPhoneNumber}</a></Fragment>) : ''}
            {user.emailAddress ? (<Fragment><br /><a href={'mailto:' + user.emailAddress}>{user.emailAddress}</a></Fragment>) : ''}
        </p>  
    );
}