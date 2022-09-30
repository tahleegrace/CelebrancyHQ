import React from "react";
import { CeremonyMeetingDTO } from "../../../../interfaces/ceremony-meeting";
import { PersonDTO } from "../../../../interfaces/person";
import { getPersonFullName } from "../../../../utilities/persons/person-helpers";

export class CeremonyMeetingParticipantsList extends React.Component<CeremonyMeetingParticipantsListProps, CeremonyMeetingParticipantsListState> {
    constructor(props: CeremonyMeetingParticipantsListProps) {
        super(props);

        this.state = {
            participants: props.meeting.participants
        };
    }

    render() {
        return (
            <div>
                <h2>Participants</h2>
                {this.state.participants.length > 0 ? this.state.participants.map(participant => this.getParticipantDisplay(participant)) : (<div>No participants</div>)}
            </div>
        );
    }

    getParticipantDisplay(participant: PersonDTO) {
        return (
            <div className="row mb-1">
                <div className="col-md-9">
                    {getPersonFullName(participant, true)}
                </div>
                <div className="col-md-3">
                    {this.props.canEdit ? <button className="btn">Delete</button> : ""}
                </div>
            </div>
        );
    }
}

interface CeremonyMeetingParticipantsListProps {
    meeting: CeremonyMeetingDTO;
    canEdit: boolean;
}

interface CeremonyMeetingParticipantsListState {
    participants: PersonDTO[];
}