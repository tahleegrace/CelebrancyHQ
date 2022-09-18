import React, { Fragment } from "react";
import { CeremonyMeetingQuestionTypeCodes } from "../../../constants/ceremonies/ceremony-meeting-question-type-codes";
import { CeremonyMeetingQuestionDTO } from "../../../interfaces/ceremony-meeting-question";

export class EditCeremonyMeetingQuestion extends React.Component<EditCeremonyMeetingQuestionProps, EditCeremonyMeetingQuestionState> {
    constructor(props: EditCeremonyMeetingQuestionProps) {
        super(props);
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

    getTextQuestionAnswerDisplay() {
        return (
            <div>{this.props.question.answer}</div>
        );
    }
}

interface EditCeremonyMeetingQuestionProps {
    question: CeremonyMeetingQuestionDTO;
}

interface EditCeremonyMeetingQuestionState {

}