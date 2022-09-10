import React, { Fragment } from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { CeremonyMeetingsService } from "../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";

export class EditCeremonyMeeting extends React.Component<EditCeremonyMeetingProps, EditCeremonyMeetingState> {
    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    constructor(props: EditCeremonyMeetingProps) {
        super(props);

        this.state = {
            meeting: null
        };
    }

    getModalId() {
        return `edit-meeting-${this.props.meetingId}`;
    }

    async openModal(event: React.MouseEvent<HTMLButtonElement>) {
        const meeting = await this.ceremonyMeetingsService.getMeeting(this.props.ceremonyId, this.props.meetingId, this.props.context.rootContext as RootContextProps);

        this.setState({
            meeting: meeting
        });
    }

    render() {
        // TODO: Split the modal component into a separate component or library.
        return (
            <Fragment>
                <button type="button" className="btn btn-primary" data-toggle="modal" data-target={`#${this.getModalId()}`} onClick={this.openModal.bind(this)}>
                    View
                </button>

                <div className="modal fade" id={this.getModalId()} role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog modal-lg" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{this.state.meeting?.name}</h5>
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
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meetingId: number;
}

interface EditCeremonyMeetingState {
    meeting: CeremonyMeetingDTO | null;
}