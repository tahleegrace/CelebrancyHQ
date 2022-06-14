import React, { Fragment } from "react";
import { CeremonyDateCodes } from "../../../constants/ceremonies/ceremony-date-codes";
import { CeremonyDateDTO } from "../../../interfaces/ceremony-date";
import { findOrCreateDateByCode } from "../../../utilities/ceremonies/ceremony-date-helpers";
import { CeremonyDateDetails } from "../ceremony-date-details/ceremony-date-details";

export class MarriageDates extends React.Component<MarriageDatesProps, MarriageDatesState> {
    constructor(props: MarriageDatesProps) {
        super(props);
    }

    dateUpdated(newDate: CeremonyDateDTO) {
        if (this.props.dateUpdated != null) {
            this.props.dateUpdated(newDate);
        }
    }

    render() {
        let initialPhoneCall = findOrCreateDateByCode(this.props.dates, CeremonyDateCodes.InitialPhoneCall);
        let initialInterview = findOrCreateDateByCode(this.props.dates, CeremonyDateCodes.InitialInterview);
        let rehearsal = findOrCreateDateByCode(this.props.dates, CeremonyDateCodes.Rehearsal);
        let ceremony = findOrCreateDateByCode(this.props.dates, CeremonyDateCodes.Ceremony);
        let reception = findOrCreateDateByCode(this.props.dates, CeremonyDateCodes.Reception);

        return (
            <Fragment>
                <CeremonyDateDetails date={initialPhoneCall} canEdit={this.props.canEdit} dateUpdated={this.dateUpdated.bind(this)} name="Initial phone call" />
                <CeremonyDateDetails date={initialInterview} canEdit={this.props.canEdit} dateUpdated={this.dateUpdated.bind(this)} name="Initial interview" />
                <CeremonyDateDetails date={rehearsal} canEdit={this.props.canEdit} dateUpdated={this.dateUpdated.bind(this)} name="Rehearsal" />
                <CeremonyDateDetails date={ceremony} canEdit={this.props.canEdit} dateUpdated={this.dateUpdated.bind(this)} name="Ceremony" />
                <CeremonyDateDetails date={reception} canEdit={this.props.canEdit} dateUpdated={this.dateUpdated.bind(this)} name="Reception" />
            </Fragment>
        );
    }
}

interface MarriageDatesProps {
    dates: CeremonyDateDTO[];
    canEdit: boolean;
    dateUpdated: (date: CeremonyDateDTO) => void;
}

interface MarriageDatesState {

}