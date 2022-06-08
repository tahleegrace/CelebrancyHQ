import React, { Fragment } from "react";
import { CeremonyParticipantCodes } from "../../../constants/ceremonies/ceremony-participant-codes";
import { CeremonyKeyDetailsDTO } from "../../../interfaces/ceremony-key-details";
import { findParticipantsByCode } from "../../../utilities/ceremonies/ceremony-participant-helpers";
import { getFullNamesForUsers, getUserAndContactDetailsDisplay } from "../../../utilities/persons/person-helpers";

export class MarriageParticipantsSummary extends React.Component<MarriageParticipantsSummaryProps, MarriageParticipantsSummaryState> {
    constructor(props: MarriageParticipantsSummaryProps) {
        super(props);
    }

    render() {
        var celebrant = findParticipantsByCode(this.props.ceremony.participants, CeremonyParticipantCodes.Celebrant)[0];
        var couple = findParticipantsByCode(this.props.ceremony.participants, CeremonyParticipantCodes.Couple);
        var organiser = findParticipantsByCode(this.props.ceremony.participants, CeremonyParticipantCodes.Organiser)[0];
        var bridalParty = findParticipantsByCode(this.props.ceremony.participants, CeremonyParticipantCodes.BridalParty);
        var witnesses = findParticipantsByCode(this.props.ceremony.participants, CeremonyParticipantCodes.Witness);

        return (
            <Fragment>
                {celebrant ?
                    (<div className="row form-group">
                        <div className="col-lg-2 col-sm-3 col-12">
                            <strong>Celebrant:</strong>
                        </div>
                        <div className="col-lg-10 col-sm-9 col-12">
                            {getUserAndContactDetailsDisplay(celebrant)}
                        </div>
                    </div>) : ""}
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Couple:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {couple.map(participant => getUserAndContactDetailsDisplay(participant))}
                    </div>
                </div>
                {organiser ?
                    (<div className="row form-group">
                        <div className="col-lg-2 col-sm-3 col-12">
                            <strong>Organiser:</strong>
                        </div>
                        <div className="col-lg-10 col-sm-9 col-12">
                            {getUserAndContactDetailsDisplay(organiser)}
                        </div>
                    </div>) : ""}
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Bridal Party:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {bridalParty.length > 0 ? getFullNamesForUsers(bridalParty, true) : "No bridal party"}
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Witnesses:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {witnesses.length > 0 ? getFullNamesForUsers(witnesses, true) : "No witnesses"}
                    </div>
                </div>
            </Fragment>
        );
    }
}

interface MarriageParticipantsSummaryProps {
    ceremony: CeremonyKeyDetailsDTO;
}

interface MarriageParticipantsSummaryState {

}