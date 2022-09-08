import React from "react";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { CeremonyMeetingDetails } from "../ceremony-meeting-details/ceremony-meeting-details";

export class CeremonyMeetingsList extends React.Component<CeremonyMeetingsListProps, CeremonyMeetingsListState> {
    constructor(props: CeremonyMeetingsListProps) {
        super(props);
    }

    render() {
        return (
            <div className="container border border-dark rounded p-2 m-2">
                {this.props.meetings.length > 0 ?
                    this.props.meetings.map(meeting => (<CeremonyMeetingDetails key={meeting.id} meeting={meeting} />)) :
                    (<div>No participants</div>)
                }
            </div>
        );
    }
}

interface CeremonyMeetingsListProps {
    meetings: CeremonyMeetingDTO[];
    canEditMeetings: boolean;
}

interface CeremonyMeetingsListState {

}