import { MarriageParticipantsSummary } from "../../../../components/ceremonies/marriage-participants-summary/marriage-participants-summary";
import { CeremonyTypeCodes } from "../../../../constants/ceremonies/ceremony-type-codes";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { CeremonyKeyDetailsDTO } from "../../../../interfaces/ceremony-key-details";
import { formatAddress, formatDate } from "../../../../utilities/format";
import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyKeyDetails extends CommonTab<CeremonyKeyDetailsProps, CeremonyKeyDetailsState> {
    constructor(props: CeremonyKeyDetailsProps) {
        super(props);
    }

    render() {
        const ceremony = (this.context as CeremonyDetailsContextProps).ceremony as CeremonyKeyDetailsDTO;

        return (
            <div className="container-fluid p-0">
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Type of Ceremony:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {ceremony.ceremonyTypeName}
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Date:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {formatDate(ceremony.ceremonyDate)}
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Venue:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {ceremony.primaryVenueName}
                    </div>
                </div>
                <div className="row form-group">
                    <div className="col-lg-2 col-sm-3 col-12">
                        <strong>Venue Address:</strong>
                    </div>
                    <div className="col-lg-10 col-sm-9 col-12">
                        {formatAddress(ceremony.primaryVenueAddress)}
                    </div>
                </div>
                {ceremony.ceremonyTypeCode === CeremonyTypeCodes.Marriage ? <MarriageParticipantsSummary ceremony={ceremony} /> : ''}
            </div>
        );
    }
}

export default withRouter(CeremonyKeyDetails);

export interface CeremonyKeyDetailsProps {

}

export interface CeremonyKeyDetailsState {

}