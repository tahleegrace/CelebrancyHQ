import React from "react";

export class CeremoniesSummary extends React.Component<CeremoniesSummaryProps, CeremoniesSummaryState> {
    constructor(props: CeremoniesSummaryProps) {
        super(props);
    }

    render() {
        return (
            <div className="container-fluid pt-0 pb-3 pl-0 pr-0">
                <h2>{this.props.title}</h2>
                <ul className="list-group">
                    <a className="list-group-item list-group-item-action">
                        Thursday 26 May 2:00PM - Wedding: John Smith and Angela Jones, 12 Bank Rd, Graceville
                    </a>
                    <a className="list-group-item list-group-item-action">
                        Thursday 26 May 2:00PM - Wedding: John Smith and Angela Jones, 12 Bank Rd, Graceville
                    </a>
                    <a className="list-group-item list-group-item-action">
                        Thursday 26 May 2:00PM - Wedding: John Smith and Angela Jones, 12 Bank Rd, Graceville
                    </a>
                </ul>
            </div>
        );
    }
}

interface CeremoniesSummaryProps {
    title: string;
}

interface CeremoniesSummaryState {

}