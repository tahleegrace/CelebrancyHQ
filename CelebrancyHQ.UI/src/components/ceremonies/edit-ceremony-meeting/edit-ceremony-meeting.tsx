import React, { Fragment } from "react";

export class EditCeremonyMeeting extends React.Component<EditCeremonyMeetingProps, EditCeremonyMeetingState> {
    constructor(props: EditCeremonyMeetingProps) {
        super(props);
    }

    getModalId() {
        return `edit-meeting-${this.props.meetingId}`;
    }

    render() {
        // TODO: Split the modal component into a separate component or library.
        return (
            <Fragment>
                <button type="button" className="btn btn-primary" data-toggle="modal" data-target={`#${this.getModalId()}`}>
                    View
                </button>

                <div className="modal fade" id={this.getModalId()} role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">Meeting {this.props.meetingId}</h5>
                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">
                                <p>Modal body text goes here.</p>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-primary">Save changes</button>
                                <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </Fragment>
        );
    }
}

interface EditCeremonyMeetingProps {
    meetingId: number;
}

interface EditCeremonyMeetingState {

}