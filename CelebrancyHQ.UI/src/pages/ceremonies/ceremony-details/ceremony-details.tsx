import { Fragment } from "react";
import { Outlet } from "react-router-dom";
import { RootContextProps } from "../../../context/root-context";
import { CeremonyKeyDetailsDTO } from "../../../interfaces/ceremony-key-details";
import { CeremoniesService } from "../../../services/ceremonies/ceremonies.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";
import { withRouter } from "../../../utilities/with-router";
import { CommonPage } from "../../common-page/common-page";

class CeremonyDetails extends CommonPage<CeremonyDetailsProps, CeremonyDetailsState> {
    static pageName = 'my-ceremonies';

    private ceremoniesService = DependencyService.getInstance().getDependency<CeremoniesService>(CeremoniesService.serviceName);

    constructor(props: CeremonyDetailsProps) {
        super({
            params: {
                ceremonyId: null
            }
        });

        this.state = {
            ceremony: null,
            loading: true,
            ceremonyNotAccessible: false
        };
    }

    async componentDidMount() {
        try {
            const ceremony = await this.ceremoniesService.getKeyDetails(this.props.params.ceremonyId as number, (this.context as RootContextProps));

            this.setState({ ceremony: ceremony, loading: false, ceremonyNotAccessible: false });
        }
        catch {
            this.setState({ loading: false, ceremonyNotAccessible: false })
        }

        this.setCurrentPage(CeremonyDetails.pageName);
    }

    render() {
        return (
            <main>
                {!this.state.loading ?
                    !this.state.ceremonyNotAccessible ?
                        <Fragment>
                            <h1>{this.state.ceremony?.name}</h1>
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
                                    <Outlet />
                                </div>
                            </div>
                        </Fragment>
                        : <div>This ceremony either does not exist or you may not have permission to access it.</div>
                    : <div>Loading ceremony, please wait ...</div>}
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
    ceremony: CeremonyKeyDetailsDTO | null;
    loading: boolean;
    ceremonyNotAccessible: boolean;
}