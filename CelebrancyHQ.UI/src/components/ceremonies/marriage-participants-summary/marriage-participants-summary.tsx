import React, { Fragment } from "react";
import { CeremonyKeyDetailsDTO } from "../../../interfaces/ceremony-key-details";

export class MarriageParticipantsSummary extends React.Component<MarriageParticipantsSummaryProps, MarriageParticipantsSummaryState> {
    constructor(props: MarriageParticipantsSummaryProps) {
        super(props);
    }

    render() {
        return (
            <Fragment>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Celebrant:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        Add celebrant here.
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Couple:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        Add couple here.
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Organiser:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        Add organiser here.
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Bridal Party:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        Add bridal party here.
                    </div>
                </div>
            </Fragment>
        );
    }
}

interface MarriageParticipantsSummaryProps {
    ceremony: CeremonyKeyDetailsDTO;
}

interface MarriageParticipantsSummaryState {

}