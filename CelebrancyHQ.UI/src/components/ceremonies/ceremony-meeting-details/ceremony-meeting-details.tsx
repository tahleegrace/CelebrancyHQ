import React from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { EditCeremonyMeeting } from "../edit-ceremony-meeting/edit-ceremony-meeting";

export class CeremonyMeetingDetails extends React.Component<CeremonyMeetingDetailsProps, CeremonyMeetingDetailsState> {
    constructor(props: CeremonyMeetingDetailsProps) {
        super(props);
    }

    render() {
        return (
            <div className="border border-dark rounded p-2 m-2">
                <div className="d-inline-block">
                    <strong>{this.props.meeting.name} ({this.props.meeting.ceremonyTypeMeetingName})</strong>
                    <p>{this.props.meeting.description}</p>
                </div>
                <div className="d-inline-block float-right">
                    <EditCeremonyMeeting context={this.props.context} ceremonyId={this.props.ceremonyId} meetingId={this.props.meeting.id} />
                </div>
            </div>
        );
    }
}

interface CeremonyMeetingDetailsProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meeting: CeremonyMeetingDTO;
}

interface CeremonyMeetingDetailsState {

}