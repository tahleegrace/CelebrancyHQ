import React from "react";
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
                <div>Insert dashboard content here</div>
            </main>
        );
    }
}

interface DashboardProps {

}

interface DashboardState {

}