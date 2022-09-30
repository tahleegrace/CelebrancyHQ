import { cloneDeep } from "lodash";
import React from "react";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyMeetingDTO } from "../../../../interfaces/ceremony-meeting";
import { PersonDTO } from "../../../../interfaces/person";
import { CeremonyMeetingsService } from "../../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";
import { getPersonFullName } from "../../../../utilities/persons/person-helpers";

export class CeremonyMeetingParticipantsList extends React.Component<CeremonyMeetingParticipantsListProps, CeremonyMeetingParticipantsListState> {
    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    constructor(props: CeremonyMeetingParticipantsListProps) {
        super(props);

        this.state = {
            participants: props.meeting.participants
        };
    }

    async deleteParticipant(participant: PersonDTO) {
        await this.ceremonyMeetingsService.deleteParticipant(this.props.ceremonyId, this.props.meeting.id, participant.personId, this.props.context.rootContext as RootContextProps);

        let newParticipants = cloneDeep(this.state.participants);
        newParticipants = newParticipants.filter(p => p.personId != participant.personId);

        this.setState({
            participants: newParticipants
        });

        if (this.props.participantsUpdated != null) {
            this.props.participantsUpdated(newParticipants);
        }
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
                    {this.props.canEdit ? <button className="btn" onClick={this.deleteParticipant.bind(this, participant)}>Delete</button> : ""}
                </div>
            </div>
        );
    }
}

interface CeremonyMeetingParticipantsListProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meeting: CeremonyMeetingDTO;
    canEdit: boolean;
    participantsUpdated: (participants: PersonDTO[]) => void;
}

interface CeremonyMeetingParticipantsListState {
    participants: PersonDTO[];
}