import React from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { EditCeremonyMeeting } from "../edit-ceremony-meeting/edit-ceremony-meeting";

export class CeremonyMeetingDetails extends React.Component<CeremonyMeetingDetailsProps, CeremonyMeetingDetailsState> {
    constructor(props: CeremonyMeetingDetailsProps) {
        super(props);
    }

    meetingUpdated(meeting: CeremonyMeetingDTO) {
        if (this.props.meetingUpdated != null) {
            this.props.meetingUpdated(meeting);
        }
    }

    render() {
        return (
            <div className="border border-dark rounded p-2 m-2">
                <div className="d-inline-block">
                    <strong>{this.props.meeting.name} ({this.props.meeting.ceremonyTypeMeetingName})</strong>
                    <div dangerouslySetInnerHTML={{ __html: this.props.meeting.description }}></div>
                </div>
                <div>
                    <EditCeremonyMeeting context={this.props.context} ceremonyId={this.props.ceremonyId} meetingId={this.props.meeting.id} canEdit={this.props.canEdit} meetingUpdated={this.props.meetingUpdated} />
                </div>
            </div>
        );
    }
}

interface CeremonyMeetingDetailsProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meeting: CeremonyMeetingDTO;
    canEdit: boolean;
    meetingUpdated: (meeting: CeremonyMeetingDTO) => void;
}

interface CeremonyMeetingDetailsState {

}