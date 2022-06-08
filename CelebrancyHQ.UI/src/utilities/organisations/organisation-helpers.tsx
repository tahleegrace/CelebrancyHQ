import { Fragment } from "react";
import { OrganisationKeyDetailsDTO } from "../../interfaces/organisation-key-details";

export function getOrganisationAndContactDetailsDisplay(organisation: OrganisationKeyDetailsDTO) {
    return (
        <p className="mb-0">
            {organisation.name}
            {organisation.primaryPhoneNumber ? (<Fragment><br /><a href={'tel:' + organisation.primaryPhoneNumber}>{organisation.primaryPhoneNumber}</a></Fragment>) : ''}
            {organisation.emailAddress ? (<Fragment><br /><a href={'mailto:' + organisation.emailAddress}>{organisation.emailAddress}</a></Fragment>) : ''}
        </p>
    );
}