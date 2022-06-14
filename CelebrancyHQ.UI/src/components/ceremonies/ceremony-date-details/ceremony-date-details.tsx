import { cloneDeep } from "lodash";
import moment from "moment";
import React, { Fragment } from "react";
import DateTimePicker from "react-datetime-picker";
import { CeremonyDateDTO } from "../../../interfaces/ceremony-date";
import { formatDate } from "../../../utilities/format";

export class CeremonyDateDetails extends React.Component<CeremonyDateDetailsProps, CeremonyDateDetailsState> {
    constructor(props: CeremonyDateDetailsProps) {
        super(props);

        this.state = {
            isInitialised: false,
            isEditing: false,
            selectedDate: null as any
        };
    }

    componentDidUpdate() {
        if (!this.props.date?.date) {
            return;
        }

        const newDate = moment(this.props.date.date).toDate();

        if (!this.state.isInitialised) {
            this.setState({
                selectedDate: newDate as any,
                isInitialised: true
            });
        }
    }

    pageClicked(event: React.MouseEvent<HTMLDivElement>) {
        const isDisplay = (event.target as any).dataset.isdisplay;

        if (isDisplay) {
            this.setState({ isEditing: false });

            const newDate = cloneDeep(this.props.date);
            newDate.date = this.state.selectedDate;

            if (this.props.dateUpdated != null) {
                this.props.dateUpdated(newDate);
            }
        }
    }

    editDateClicked(event: React.MouseEvent<HTMLButtonElement>) {
        event.stopPropagation();

        this.setState({ isEditing: true });
    }

    onDateChange(value: Date) {
        this.setState({ selectedDate: value });
    }

    render() {
        return (
            <div className="row form-group" data-isdisplay="true" onClick={this.pageClicked.bind(this)}>
                <div className="col-lg-2 col-sm-3 col-12" data-isdisplay="true">
                    <strong>{this.props.name}</strong>
                </div>
                <div className="col-lg-10 col-sm-9 col-12" data-isdisplay="true">
                    {this.state.isEditing ?
                        (<DateTimePicker value={this.state.selectedDate} onChange={this.onDateChange.bind(this)} />) :
                        <Fragment>
                            {this.props.date ? formatDate(this.state.selectedDate) : "None"}
                            {this.props.canEdit ? (<span> (<button className="btn btn-link p-0 m-0 border-0 align-top" role="link" onClick={this.editDateClicked.bind(this)}>Edit</button>)</span>) : ""}
                        </Fragment>
                    }
                </div>
            </div>
        );
    }
}

interface CeremonyDateDetailsProps {
    name: string;
    date: CeremonyDateDTO;
    canEdit: boolean;
    dateUpdated: (date: CeremonyDateDTO) => void;
}

interface CeremonyDateDetailsState {
    isInitialised: boolean;
    isEditing: boolean;
    selectedDate: Date;
}