import React from "react";
import { CeremoniesSummary } from "../../components/ceremonies-summary/ceremonies-summary";
import { CommonPage } from "../common-page/common-page";

export class Dashboard extends CommonPage<DashboardProps, DashboardState> {
    static pageName = 'dashboard';

    constructor(props: DashboardProps) {
        super(props);
    }

    componentDidMount() {
        this.setCurrentPage(Dashboard.pageName);
    }

    render() {
        return (
            <main>
                <h1>Dashboard</h1>

                <CeremoniesSummary title="This week" />
                <CeremoniesSummary title="Next week" />

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

}