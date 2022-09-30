import { Editor } from "@tinymce/tinymce-react";
import { cloneDeep } from "lodash";
import React, { Fragment } from "react";
import { EditorEvent } from "tinymce";
import config from "../../../../config";
import { CeremonyMeetingQuestionTypeCodes } from "../../../../constants/ceremonies/ceremony-meeting-question-type-codes";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyMeetingQuestionDTO } from "../../../../interfaces/ceremony-meeting-question";
import { UpdateCeremonyMeetingQuestionRequest } from "../../../../interfaces/update-ceremony-meeting-question-request";
import { CeremonyMeetingsService } from "../../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";

export class EditCeremonyMeetingQuestion extends React.Component<EditCeremonyMeetingQuestionProps, EditCeremonyMeetingQuestionState> {
    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    constructor(props: EditCeremonyMeetingQuestionProps) {
        super(props);

        this.state = {
            question: props.question,
            oldAnswer: props.question.answer
        };
    }

    render() {
        return (
            <Fragment>
                <div>
                    <h3>{this.props.question.question}</h3>
                </div>
                {this.getAnswerDisplay()}
            </Fragment>
        );
    }

    getAnswerDisplay() {
        if (this.props.question.questionTypeCode === CeremonyMeetingQuestionTypeCodes.Text) {
            return this.getTextQuestionAnswerDisplay();
        } else {
            return (<div>Question type not supported.</div>);
        }
    }

    // Text questions.
    getTextQuestionAnswerDisplay() {
        return (
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
                initialValue={this.props.question.answer}
                disabled={!this.props.canEdit}
                onChange={this.textAnswerChanged.bind(this)}
                onKeyUp={this.textAnswerOnKeyUp.bind(this)}
                onBlur={this.saveTextAnswer.bind(this)} />
        );
    }

    textAnswerChanged(event: any, editor: any) {
        if (this.state.question) {
            const question = cloneDeep(this.state.question);
            question.answer = editor.getContent();

            this.setState({ question: question });
        }
    }

    textAnswerOnKeyUp(event: EditorEvent<KeyboardEvent>) {
        if (event.key === "Escape" && this.state.question) {
            const question = cloneDeep(this.state.question);
            question.answer = this.state.oldAnswer;

            this.setState({ question: question });
        }
    }

    saveTextAnswer(event: any) {
        setTimeout(async () => {
            if (this.state.question && this.state.question.answer != this.state.oldAnswer) {
                const request: UpdateCeremonyMeetingQuestionRequest = {
                    ceremonyTypeQuestionId: this.state.question.ceremonyTypeQuestionId,
                    answer: this.state.question.answer
                };

                await this.ceremonyMeetingsService.updateQuestion(this.props.ceremonyId, this.props.meetingId, request, this.props.context.rootContext as RootContextProps);
                this.setState({ oldAnswer: this.state.question.answer });

                if (this.props.questionUpdated != null) {
                    this.props.questionUpdated(this.state.question);
                }
            }
        });
    }
}

interface EditCeremonyMeetingQuestionProps {
    question: CeremonyMeetingQuestionDTO;
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    meetingId: number;
    canEdit: boolean;
    questionUpdated: (meeting: CeremonyMeetingQuestionDTO) => void;
}

interface EditCeremonyMeetingQuestionState {
    question: CeremonyMeetingQuestionDTO;
    oldAnswer?: string;
}