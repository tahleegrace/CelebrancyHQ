import { cloneDeep } from "lodash";
import React from "react";
import { Fragment } from "react";
import ContentEditable, { ContentEditableEvent } from "react-contenteditable";
import { Link, Outlet } from "react-router-dom";
import { CeremonyFieldNames } from "../../../constants/ceremonies/ceremony-field-names";
import { CeremonyDetailsContext, CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { UpdateCeremonyRequest } from "../../../interfaces/update-ceremony-request";
import { CeremoniesService } from "../../../services/ceremonies/ceremonies.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";
import { getCeremonyPermission } from "../../../utilities/ceremonies/ceremony-permission-helpers";
import { withRouter } from "../../../utilities/with-router";
import { CommonPage } from "../../common-page/common-page";

// TODO: Split the tab panel and tab links into a separate component.
class CeremonyDetails extends CommonPage<CeremonyDetailsProps, CeremonyDetailsState> {
    static pageName = 'my-ceremonies';

    private ceremoniesService = DependencyService.getInstance().getDependency<CeremoniesService>(CeremoniesService.serviceName);
    private ceremonyNameContentEditable: React.RefObject<HTMLHeadingElement>;

    constructor(props: CeremonyDetailsProps) {
        super(props);

        this.state = {
            ceremonyId: null,
            ceremony: null as any,
            canEditKeyDetails: false,
            canViewDates: false,
            loading: true,
            ceremonyNotAccessible: false,
            rootContext: null,
            oldCeremonyName: '',

            currentTab: null,
            setCurrentTab: (tab: string) => {
                this.setState({ currentTab: tab })
            }
        };

        this.ceremonyNameContentEditable = React.createRef<HTMLHeadingElement>();
    }

    async componentDidMount() {
        try {
            const ceremony = await this.ceremoniesService.getKeyDetails(this.props.params.ceremonyId as number, (this.context as RootContextProps));

            this.setState({
                ceremonyId: this.props.params.ceremonyId,
                ceremony: ceremony,
                oldCeremonyName: ceremony.name,
                canEditKeyDetails: getCeremonyPermission(ceremony.effectivePermissions, CeremonyFieldNames.KeyDetails)?.canEdit || false,
                canViewDates: getCeremonyPermission(ceremony.effectivePermissions, CeremonyFieldNames.Dates)?.canView || false,
                loading: false,
                ceremonyNotAccessible: false,
                rootContext: this.context as RootContextProps
            });
        }
        catch {
            this.setState({
                loading: false,
                ceremonyNotAccessible: false
            })
        }

        this.setCurrentPage(CeremonyDetails.pageName);
    }

    isTabActive(tab: string) {
        return this.state.currentTab === tab;
    }

    ceremonyNameChanged(event: ContentEditableEvent) {
        const ceremony = cloneDeep(this.state.ceremony);
        ceremony.name = event.target.value;

        this.setState({ ceremony: ceremony });
    }

    ceremonyNameOnKeyUp(event: React.KeyboardEvent<HTMLDivElement>) {
        if (event.key === "Escape") {
            const ceremony = cloneDeep(this.state.ceremony);
            ceremony.name = this.state.oldCeremonyName;

            this.setState({ ceremony: ceremony });
            (this.ceremonyNameContentEditable as any).current.blur();
        }
    }

    saveCeremonyName(event: React.FocusEvent<HTMLDivElement>) {
        setTimeout(async () => {
            if (this.state.ceremony.name != this.state.oldCeremonyName) {
                let request: UpdateCeremonyRequest = {
                    id: this.state.ceremonyId as number,
                    name: this.state.ceremony.name
                };

                await this.ceremoniesService.update(request, (this.context as RootContextProps));
                this.setState({ oldCeremonyName: this.state.ceremony.name });
            }
        });
    }

    render() {
        return (
            <main>
                {!this.state.loading ?
                    !this.state.ceremonyNotAccessible ?
                        <Fragment>
                            <ContentEditable innerRef={this.ceremonyNameContentEditable}
                                html={this.state.ceremony.name}
                                tagName="h1"
                                disabled={!this.state.canEditKeyDetails}
                                onChange={this.ceremonyNameChanged.bind(this)}
                                onKeyUp={this.ceremonyNameOnKeyUp.bind(this)}
                                onBlur={this.saveCeremonyName.bind(this)}/>

                            <div className="container-fluid p-0">
                                <ul className="nav nav-tabs">
                                    <li className="nav-item">
                                        <Link className={`nav-link ${this.isTabActive('key-details') ? 'active' : ''}`} to="">Key Details</Link>
                                    </li>
                                    {this.state.canViewDates ?
                                        (<li className="nav-item">
                                            <Link className={`nav-link ${this.isTabActive('dates') ? 'active' : ''}`} to="dates">Dates</Link>
                                        </li>) : ""}
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
                                        <a className={`nav-link ${this.isTabActive('documentation') ? 'active' : ''}`}>Documentation and Forms</a>
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
    canEditKeyDetails: boolean;
    canViewDates: boolean;
    oldCeremonyName: string;
}