import React from "react";
import { CeremonyTypeParticipantDTO } from "../../../interfaces/ceremony-type-participant";

export class CeremonyParticipantsList extends React.Component<CeremonyParticipantsListProps, CeremonyParticipantsListState> {
    constructor(props: CeremonyParticipantsListProps) {
        super(props);
    }

    render() {
        return (
            <div className="container border border-dark rounded p-2 mb-2">
                <strong>{this.props.ceremonyTypeParticipant.name}</strong>
            </div>
        );
    }
}

interface CeremonyParticipantsListProps {
    ceremonyTypeParticipant: CeremonyTypeParticipantDTO;
}

interface CeremonyParticipantsListState {

}