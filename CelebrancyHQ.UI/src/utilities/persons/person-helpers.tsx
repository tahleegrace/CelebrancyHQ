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
        <p className="mb-0">
            {getUserFullName(user, true)}
            <br />
            0472581931
            <br />
            john.smith@test.com
        </p>  
    );
}