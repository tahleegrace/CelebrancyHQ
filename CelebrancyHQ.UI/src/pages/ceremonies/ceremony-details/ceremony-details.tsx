import { withRouter } from "../../../utilities/with-router";
import { CommonPage } from "../../common-page/common-page";

class CeremonyDetails extends CommonPage<CeremonyDetailsProps, CeremonyDetailsState> {
    static pageName = 'my-ceremonies';

    constructor(props: CeremonyDetailsProps) {
        super({
            params: {
                ceremonyId: null
            }
        });
    }

    componentDidMount() {
        // TODO: Add validation to check that we're not accessing a ceremony the user is not a participant in.
        this.setCurrentPage(CeremonyDetails.pageName);
    }

    render() {
        return (
            <main>
                <h1>Ceremony {this.props.params.ceremonyId}</h1>
                <div className="container-fluid p-0">
                    <ul className="nav nav-tabs">
                        <li className="nav-item">
                            <a className="nav-link active">Key Details</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Key Dates</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Participants</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Guests</a>
                        </li>                     
                        <li className="nav-item">
                            <a className="nav-link">Service Providers</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Order of Service</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Meetings</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Documentation</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Checklists</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">Invoices and Payments</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link">History</a>
                        </li>
                    </ul>
                    <div className="container pt-2 pb-0 pl-0 pr-0">
                        Insert tab content here.
                    </div>
                </div>
            </main>
        );
    }
}

export default withRouter(CeremonyDetails);

interface CeremonyDetailsProps {
    params: {
        ceremonyId: number | null
    }
}

interface CeremonyDetailsState {

}