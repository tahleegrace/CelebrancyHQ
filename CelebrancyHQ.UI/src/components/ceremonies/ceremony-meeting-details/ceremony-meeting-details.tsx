import React from "react";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";

export class CeremonyMeetingDetails extends React.Component<CeremonyMeetingDetailsProps, CeremonyMeetingDetailsState> {
    constructor(props: CeremonyMeetingDetailsProps) {
        super(props);
    }

    render() {
        return (
            <div className="border border-dark rounded p-2 m-2">
                <div className="d-inline-block">
                    <strong>{this.props.meeting.name}</strong>
                    <p>{this.props.meeting.description}</p>
                </div>
                <div className="d-inline-block float-right">
                    View
                </div>
            </div>
        );
    }
}

interface CeremonyMeetingDetailsProps {
    meeting: CeremonyMeetingDTO;
}

interface CeremonyMeetingDetailsState {

}