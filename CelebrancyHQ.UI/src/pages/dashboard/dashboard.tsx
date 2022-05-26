import React from "react";
import { CeremoniesSummary } from "../../components/ceremonies-summary/ceremonies-summary";
import { CeremonySummary } from "../../interfaces/ceremony-summary";
import { CeremoniesService } from "../../services/ceremonies/ceremonies.service";
import { DependencyService } from "../../services/dependencies/dependency.service";
import { CommonPage } from "../common-page/common-page";

export class Dashboard extends CommonPage<DashboardProps, DashboardState> {
    static pageName = 'dashboard';
    private ceremoniesService = DependencyService.getInstance().getDependency<CeremoniesService>(CeremoniesService.serviceName);

    constructor(props: DashboardProps) {
        super(props);

        this.state = {
            ceremoniesThisWeek: [],
            ceremoniesNextWeek: []
        };
    }

    async componentDidMount() {
        this.setCurrentPage(Dashboard.pageName);

        const ceremoniesThisWeek = await this.ceremoniesService.listCeremonies(true);
        const ceremoniesNextWeek = await this.ceremoniesService.listCeremonies(false);

        this.setState({
            ceremoniesThisWeek: ceremoniesThisWeek,
            ceremoniesNextWeek: ceremoniesNextWeek
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
                        <a className="list-group-item list-group-item-action">
                            Host a wedding
                        </a>
                        <a className="list-group-item list-group-item-action">
                            Host a funeral
                        </a>
                    </ul>
                </div>
            </main>
        );
    }
}

interface DashboardProps {

}

interface DashboardState {
    ceremoniesThisWeek: CeremonySummary[];
    ceremoniesNextWeek: CeremonySummary[];
}