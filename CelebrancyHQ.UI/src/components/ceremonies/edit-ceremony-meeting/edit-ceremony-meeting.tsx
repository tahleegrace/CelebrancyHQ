import { cloneDeep } from "lodash";
import React, { Fragment } from "react";
import ContentEditable, { ContentEditableEvent } from "react-contenteditable";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { UpdateCeremonyMeetingRequest } from "../../../interfaces/update-ceremony-meeting-request";
import { CeremonyMeetingsService } from "../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";

export class EditCeremonyMeeting extends React.Component<EditCeremonyMeetingProps, EditCeremonyMeetingState> {
    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    private nameContentEditable: React.RefObject<HTMLHeadingElement>;

    constructor(props: EditCeremonyMeetingProps) {
        super(props);

        this.state = {
            meeting: null,
            oldName: ''
        };

        this.nameContentEditable = React.createRef<HTMLHeadingElement>();
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

    nameChanged(event: ContentEditableEvent) {
        if (this.state.meeting) {
            const meeting = cloneDeep(this.state.meeting);
            meeting.name = event.target.value;

            this.setState({ meeting: meeting });
        }
    }

    nameOnKeyUp(event: React.KeyboardEvent<HTMLDivElement>) {
        if (event.key === "Escape" && this.state.meeting) {
            const meeting = cloneDeep(this.state.meeting);
            meeting.name = this.state.oldName;

            this.setState({ meeting: meeting });
            (this.nameContentEditable as any).current.blur();
        }
    }

    saveName(event: React.FocusEvent<HTMLDivElement>) {
        setTimeout(async () => {
            if (this.state.meeting && this.state.meeting.name != this.state.oldName) {
                const request: UpdateCeremonyMeetingRequest = {
                    id: this.state.meeting.id,
                    name: {
                        value: this.state.meeting.name,
                        updated: true
                    }
                };

                await this.ceremonyMeetingsService.update(this.props.ceremonyId, request, this.props.context.rootContext as RootContextProps);
                this.setState({ oldName: this.state.meeting.name });

                if (this.props.meetingUpdated != null) {
                    this.props.meetingUpdated(this.state.meeting);
                }
            }
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
                                <ContentEditable innerRef={this.nameContentEditable}
                                    html={this.state.meeting?.name || ""}
                                    tagName="h5"
                                    disabled={!this.props.canEdit}
                                    onChange={this.nameChanged.bind(this)}
                                    onKeyUp={this.nameOnKeyUp.bind(this)}
                                    onBlur={this.saveName.bind(this)} />

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
    canEdit: boolean;
    meetingUpdated: (meeting: CeremonyMeetingDTO) => void;
}

interface EditCeremonyMeetingState {
    meeting: CeremonyMeetingDTO | null;
    oldName: string;
}