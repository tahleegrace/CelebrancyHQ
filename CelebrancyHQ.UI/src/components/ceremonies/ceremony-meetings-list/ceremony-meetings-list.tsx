import React from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { CeremonyMeetingDetails } from "../ceremony-meeting-details/ceremony-meeting-details";

export class CeremonyMeetingsList extends React.Component<CeremonyMeetingsListProps, CeremonyMeetingsListState> {
    constructor(props: CeremonyMeetingsListProps) {
        super(props);
    }

    meetingUpdated(meeting: CeremonyMeetingDTO) {
        if (this.props.meetingUpdated != null) {
            this.props.meetingUpdated(meeting);
        }
    }

    render() {
        return (
            <div className="container border border-dark rounded p-2 m-2">
                {this.props.meetings.length > 0 ?
                    this.props.meetings.map(meeting => (<CeremonyMeetingDetails key={meeting.id} context={this.props.context} ceremonyId={this.props.ceremonyId} meeting={meeting} canEdit={this.props.canEdit} meetingUpdated={this.props.meetingUpdated} />)) :
                    (<div>No meetings</div>)
                }
            </div>
        );
    }
}

interface CeremonyMeetingsListProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meetings: CeremonyMeetingDTO[];
    canEdit: boolean;
    meetingUpdated: (meeting: CeremonyMeetingDTO) => void;
}

interface CeremonyMeetingsListState {

}