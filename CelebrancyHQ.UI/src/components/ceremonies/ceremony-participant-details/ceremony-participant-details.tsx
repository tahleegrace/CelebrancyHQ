import React, { Fragment } from "react";
import { CeremonyParticipantDTO } from "../../../interfaces/ceremony-participant";
import { formatAddress } from "../../../utilities/addresses/address-helper";
import { getPersonFullName } from "../../../utilities/persons/person-helpers";
import { getPhoneNumberDisplay } from "../../../utilities/phone-numbers/phone-number-helpers";

export class CeremonyParticipantDetails extends React.Component<CeremonyParticipantDetailsProps, CeremonyParticipantDetailsState> {
    constructor(props: CeremonyParticipantDetailsProps) {
        super(props);
    }

    render() {
        return (
            <div className="border border-dark rounded p-2 m-2">
                <div className="d-inline-block">
                    <strong>{getPersonFullName(this.props.participant, true)}</strong>
                    <Fragment><br /><a href={'mailto:' + this.props.participant.emailAddress}>{this.props.participant.emailAddress}</a></Fragment>
                    {this.props.participant.phoneNumbers.map(number => (<Fragment><br />{getPhoneNumberDisplay(number)}</Fragment>))}
                        {this.props.participant.address ? (<Fragment><br />{formatAddress(this.props.participant.address)}</Fragment>) : ""}
                </div>
                <div className="d-inline-block float-right">
                    Edit
                </div>
            </div>
        );
    }
}

interface CeremonyParticipantDetailsProps {
    participant: CeremonyParticipantDTO;
}

interface CeremonyParticipantDetailsState {

}