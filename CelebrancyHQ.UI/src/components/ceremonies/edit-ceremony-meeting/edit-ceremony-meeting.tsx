import { cloneDeep } from "lodash";
import React, { Fragment, useEffect } from "react";
import { Editor } from '@tinymce/tinymce-react';
import ContentEditable, { ContentEditableEvent } from "react-contenteditable";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { CeremonyMeetingDTO } from "../../../interfaces/ceremony-meeting";
import { UpdateCeremonyMeetingRequest } from "../../../interfaces/update-ceremony-meeting-request";
import { CeremonyMeetingsService } from "../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";
import config from "../../../config";
import { EditorEvent } from "tinymce";
import { EditCeremonyMeetingQuestion } from "../edit-ceremony-meeting-question/edit-ceremony-meeting-question";

export class EditCeremonyMeeting extends React.Component<EditCeremonyMeetingProps, EditCeremonyMeetingState> {
    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    private nameContentEditable: React.RefObject<HTMLHeadingElement>;

    constructor(props: EditCeremonyMeetingProps) {
        super(props);

        this.state = {
            meeting: null,
            oldName: '',
            oldDescription: ''
        };

        this.nameContentEditable = React.createRef<HTMLHeadingElement>();
    }

    getModalId() {
        return `edit-meeting-${this.props.meetingId}`;
    }

    async openModal(event: React.MouseEvent<HTMLButtonElement>) {
        const meeting = await this.ceremonyMeetingsService.getMeeting(this.props.ceremonyId, this.props.meetingId, this.props.context.rootContext as RootContextProps);

        this.setState({
            meeting: meeting,
            oldName: meeting.name,
            oldDescription: meeting.description
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

    descriptionChanged(event: any, editor: any) {
        if (this.state.meeting) {
            const meeting = cloneDeep(this.state.meeting);
            meeting.description = editor.getContent();

            this.setState({ meeting: meeting });
        }
    }

    descriptionOnKeyUp(event: EditorEvent<KeyboardEvent>) {
        if (event.key === "Escape" && this.state.meeting) {
            const meeting = cloneDeep(this.state.meeting);
            meeting.description = this.state.oldDescription;

            this.setState({ meeting: meeting });
        }
    }

    saveDescription(event: any) {
        setTimeout(async () => {
            if (this.state.meeting && this.state.meeting.description != this.state.oldDescription) {
                const request: UpdateCeremonyMeetingRequest = {
                    id: this.state.meeting.id,
                    description: {
                        value: this.state.meeting.description,
                        updated: true
                    }
                };

                await this.ceremonyMeetingsService.update(this.props.ceremonyId, request, this.props.context.rootContext as RootContextProps);
                this.setState({ oldDescription: this.state.meeting.description });

                if (this.props.meetingUpdated != null) {
                    this.props.meetingUpdated(this.state.meeting);
                }
            }
        });
    }

    componentDidMount() {
        const handler = (e: any) => {
            if (e.target.closest(".tox-tinymce-aux, .moxman-window, .tam-assetmanager-root") !== null) {
                e.stopImmediatePropagation();
            }
        };

        document.addEventListener("focusin", handler);
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
                                    tagName="h1"
                                    disabled={!this.props.canEdit}
                                    onChange={this.nameChanged.bind(this)}
                                    onKeyUp={this.nameOnKeyUp.bind(this)}
                                    onBlur={this.saveName.bind(this)} />

                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">
                                <Editor
                                    apiKey={config.tinyMce.apiKey}
                                    init={{
                                        menubar: false,
                                        inline: true,
                                        plugins: [
                                            'link'
                                        ],
                                        toolbar: [
                                            'undo redo | bold italic underline | fontsize',
                                            'forecolor backcolor | numlist bullist outdent indent'
                                        ],
                                        valid_elements: 'p[style],strong,em,span[style],a[href],ul,ol,li',
                                        valid_styles: {
                                            '*': 'font-size,font-family,color,text-decoration,text-align'
                                        },
                                    }}
                                    initialValue={this.state.meeting?.description}
                                    disabled={!this.props.canEdit}
                                    onChange={this.descriptionChanged.bind(this)}
                                    onKeyUp={this.descriptionOnKeyUp.bind(this)}
                                    onBlur={this.saveDescription.bind(this)} />
                                {this.state.meeting?.questions ? this.state.meeting.questions.map(question => (<EditCeremonyMeetingQuestion question={question} />)) : ""}
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
    oldDescription: string;
}