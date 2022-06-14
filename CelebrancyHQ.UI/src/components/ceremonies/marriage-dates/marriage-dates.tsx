import React, { Fragment } from "react";
import { CeremonyDateCodes } from "../../../constants/ceremonies/ceremony-date-codes";
import { CeremonyDateDTO } from "../../../interfaces/ceremony-date";
import { findDateByCode } from "../../../utilities/ceremonies/ceremony-date-helpers";
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
        let initialPhoneCall = findDateByCode(this.props.dates, CeremonyDateCodes.InitialPhoneCall);
        let initialInterview = findDateByCode(this.props.dates, CeremonyDateCodes.InitialInterview);
        let rehearsal = findDateByCode(this.props.dates, CeremonyDateCodes.Rehearsal);
        let ceremony = findDateByCode(this.props.dates, CeremonyDateCodes.Ceremony);
        let reception = findDateByCode(this.props.dates, CeremonyDateCodes.Reception);

        return (
            <Fragment>
                <CeremonyDateDetails date={initialPhoneCall} name="Initial phone call" />
                <CeremonyDateDetails date={initialInterview} name="Initial interview" />
                <CeremonyDateDetails date={rehearsal} name="Rehearsal" />
                <CeremonyDateDetails date={ceremony} name="Ceremony" />
                <CeremonyDateDetails date={reception} name="Reception" />
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