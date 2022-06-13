import React from "react";
import { CeremonyDateDTO } from "../../../interfaces/ceremony-date";
import { formatDate } from "../../../utilities/format";

export class CeremonyDateDetails extends React.Component<CeremonyDateDetailsProps, CeremonyDateDetailsState> {
    constructor(props: CeremonyDateDetailsProps) {
        super(props);
    }

    render() {
        return (
            <div className="row form-group">
                <div className="col-lg-2 col-sm-3 col-12">
                    <strong>{this.props.name}</strong>
                </div>
                <div className="col-lg-10 col-sm-9 col-12">
                    {this.props.date ? formatDate(this.props.date.date) : "None" }
                </div>
            </div>
        );
    }
}

interface CeremonyDateDetailsProps {
    name: string;
    date: CeremonyDateDTO;
}

interface CeremonyDateDetailsState {

}