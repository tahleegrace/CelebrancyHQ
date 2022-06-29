import React from "react";
import { CeremonyParticipantDTO } from "../../../interfaces/ceremony-participant";
import { CeremonyTypeParticipantDTO } from "../../../interfaces/ceremony-type-participant";
import { CeremonyParticipantDetails } from "../ceremony-participant-details/ceremony-participant-details";

export class CeremonyParticipantsList extends React.Component<CeremonyParticipantsListProps, CeremonyParticipantsListState> {
    constructor(props: CeremonyParticipantsListProps) {
        super(props);
    }

    render() {
        return (
            <div className="container border border-dark rounded p-2 m-2">
                <strong>{this.props.ceremonyTypeParticipant.name}</strong>
                {this.props.participants.length > 0 ?
                    this.props.participants.map(participant => (<CeremonyParticipantDetails key={participant.id} participant={participant} />)) :
                    (<div>No participants</div>)
                }
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