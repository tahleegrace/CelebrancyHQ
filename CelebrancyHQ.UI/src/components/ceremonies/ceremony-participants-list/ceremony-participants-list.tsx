import React from "react";
import { CeremonyParticipantDTO } from "../../../interfaces/ceremony-participant";
import { CeremonyTypeParticipantDTO } from "../../../interfaces/ceremony-type-participant";
import { getPersonFullName } from "../../../utilities/persons/person-helpers";

export class CeremonyParticipantsList extends React.Component<CeremonyParticipantsListProps, CeremonyParticipantsListState> {
    constructor(props: CeremonyParticipantsListProps) {
        super(props);
    }

    render() {
        return (
            <div className="container border border-dark rounded p-2 mb-2">
                <strong>{this.props.ceremonyTypeParticipant.name}</strong>
                {this.props.participants.map(participant => (<div>{getPersonFullName(participant)}</div>))}
            </div>
        );
    }
}

interface CeremonyParticipantsListProps {
    ceremonyTypeParticipant: CeremonyTypeParticipantDTO;
    participants: CeremonyParticipantDTO[];
    canEditParticipants: boolean;
}

interface CeremonyParticipantsListState {

}