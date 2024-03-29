import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { AddressDTO } from "../../../interfaces/address";
import { CeremonySummaryDTO } from "../../../interfaces/ceremony-summary";
import { formatAddress } from "../../../utilities/addresses/address-helper";
import { formatDate } from "../../../utilities/format";

export class CeremoniesSummary extends React.Component<CeremoniesSummaryProps, CeremoniesSummaryState> {
    constructor(props: CeremoniesSummaryProps) {
        super(props);
    }

    getCeremonyDescription(ceremony: CeremonySummaryDTO) {
        return `${formatDate(ceremony.ceremonyDate)} - ${ceremony.name}: ${ceremony.primaryVenue.name}, ${formatAddress(ceremony.primaryVenue.address as AddressDTO)}`;
    }

    render() {
        return (
            <div className="container-fluid pt-0 pb-3 pl-0 pr-0">
                <h2>{this.props.title}</h2>
                <ul className="list-group">
                    {this.props.ceremonies && this.props.ceremonies.length > 0 ?
                        <Fragment>
                            {this.props.ceremonies.map(ceremony =>
                            (<Link key={ceremony.id} to={`/ceremonies/${ceremony.id}`} className="list-group-item list-group-item-action">
                                {this.getCeremonyDescription(ceremony)}
                            </Link>))
                            }
                        </Fragment>
                        : <a className="list-group-item">No ceremonies</a>
                    }
                </ul>
            </div>
        );
    }
}

interface CeremoniesSummaryProps {
    title: string;
    ceremonies: CeremonySummaryDTO[];
}

interface CeremoniesSummaryState {

}