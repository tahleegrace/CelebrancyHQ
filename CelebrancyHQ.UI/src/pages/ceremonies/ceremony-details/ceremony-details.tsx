import { Fragment } from "react";
import { Outlet } from "react-router-dom";
import { CeremonyDetailsContext, CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { CeremoniesService } from "../../../services/ceremonies/ceremonies.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";
import { withRouter } from "../../../utilities/with-router";
import { CommonPage } from "../../common-page/common-page";

// TODO: Split the tab panel and tab links into a separate component.
class CeremonyDetails extends CommonPage<CeremonyDetailsProps, CeremonyDetailsState> {
    static pageName = 'my-ceremonies';

    private ceremoniesService = DependencyService.getInstance().getDependency<CeremoniesService>(CeremoniesService.serviceName);

    constructor(props: CeremonyDetailsProps) {
        super(props);

        this.state = {
            ceremonyId: null,
            ceremony: null,
            loading: true,
            ceremonyNotAccessible: false,
            rootContext: null,

            currentTab: null,
            setCurrentTab: (tab: string) => {
                this.setState({ currentTab: tab })
            }
        };
    }

    async componentDidMount() {
        try {
            const ceremony = await this.ceremoniesService.getKeyDetails(this.props.params.ceremonyId as number, (this.context as RootContextProps));

            this.setState({ ceremonyId: this.props.params.ceremonyId, ceremony: ceremony, loading: false, ceremonyNotAccessible: false, rootContext: this.context as RootContextProps });
        }
        catch {
            this.setState({ loading: false, ceremonyNotAccessible: false })
        }

        this.setCurrentPage(CeremonyDetails.pageName);
    }

    isTabActive(tab: string) {
        return this.state.currentTab === tab;
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
                                        <a className={`nav-link ${this.isTabActive('key-details') ? 'active' : ''}`}>Key Details</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('key-dates') ? 'active' : ''}`}>Key Dates</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('participants') ? 'active' : ''}`}>Participants</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('guests') ? 'active' : ''}`}>Guests</a>
                                    </li>                     
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('service-providers') ? 'active' : ''}`}>Service Providers</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('order-of-service') ? 'active' : ''}`}>Order of Service</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('meetings') ? 'active' : ''}`}>Meetings</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('documentation') ? 'active' : ''}`}>Documentation</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('checklists') ? 'active' : ''}`}>Checklists</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('invoices') ? 'active' : ''}`}>Invoices and Payments</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={`nav-link ${this.isTabActive('history') ? 'active' : ''}`}>History</a>
                                    </li>
                                </ul>
                                <div className="container pt-2 pb-0 pl-0 pr-0">
                                    <CeremonyDetailsContext.Provider value={this.state}>
                                        <Outlet />
                                    </CeremonyDetailsContext.Provider>
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

interface CeremonyDetailsState extends CeremonyDetailsContextProps {
    loading: boolean;
    ceremonyNotAccessible: boolean;
}