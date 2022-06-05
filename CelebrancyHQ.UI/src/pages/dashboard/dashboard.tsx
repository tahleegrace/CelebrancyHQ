import React from "react";
import { CeremoniesSummary } from "../../components/ceremonies-summary/ceremonies-summary";
import { ContextProps } from "../../context/context";
import { CeremonySummaryDTO } from "../../interfaces/ceremony-summary";
import { CeremonyTypeDTO } from "../../interfaces/ceremony-type";
import { CeremoniesService } from "../../services/ceremonies/ceremonies.service";
import { CeremonyTypesService } from "../../services/ceremonies/ceremony-types.service";
import { DependencyService } from "../../services/dependencies/dependency.service";
import { CommonPage } from "../common-page/common-page";

export class Dashboard extends CommonPage<DashboardProps, DashboardState> {
    static pageName = 'dashboard';

    private ceremonyTypesService = DependencyService.getInstance().getDependency<CeremonyTypesService>(CeremonyTypesService.serviceName);
    private ceremoniesService = DependencyService.getInstance().getDependency<CeremoniesService>(CeremoniesService.serviceName);

    constructor(props: DashboardProps) {
        super(props);

        this.state = {
            ceremoniesThisWeek: [],
            ceremoniesNextWeek: [],
            ceremonyTypes: []
        };
    }

    async componentDidMount() {
        this.setCurrentPage(Dashboard.pageName);

        const ceremoniesThisWeek = await this.ceremoniesService.listCeremonies(0, 'celebrant', (this.context as ContextProps));
        const ceremoniesNextWeek = await this.ceremoniesService.listCeremonies(1, 'celebrant', (this.context as ContextProps));
        const ceremonyTypes = await this.ceremonyTypesService.getAll((this.context as ContextProps));

        this.setState({
            ceremoniesThisWeek: ceremoniesThisWeek,
            ceremoniesNextWeek: ceremoniesNextWeek,
            ceremonyTypes: ceremonyTypes
        });
    }

    render() {
        return (
            <main>
                <h1>Dashboard</h1>

                <CeremoniesSummary key="this-weeks-ceremonies" title="This week" ceremonies={this.state.ceremoniesThisWeek} />
                <CeremoniesSummary key="next-weeks-ceremonies" title="Next week" ceremonies={this.state.ceremoniesNextWeek} />

                <div className="container-fluid p-0">
                    <h2>Tasks</h2>
                    <ul className="list-group">
                        {this.state.ceremonyTypes.map(type =>
                        (
                            <a key={type.id} className="list-group-item list-group-item-action">
                                Host a {type.name.toLowerCase()}
                            </a>
                        ))
                        }
                    </ul>
                </div>
            </main>
        );
    }
}

interface DashboardProps {

}

interface DashboardState {
    ceremoniesThisWeek: CeremonySummaryDTO[];
    ceremoniesNextWeek: CeremonySummaryDTO[];
    ceremonyTypes: CeremonyTypeDTO[];
}