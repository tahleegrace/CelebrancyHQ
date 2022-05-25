import React from "react";

export class Dashboard extends React.Component<DashboardProps, DashboardState> {
    constructor(props: DashboardProps) {
        super(props);
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