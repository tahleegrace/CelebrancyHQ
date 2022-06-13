import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyDates extends CommonTab<CeremonyDatesProps, CeremonyDatesState> {
    static tabName = 'dates';

    constructor(props: CeremonyDatesProps) {
        super(props);
    }

    componentDidMount() {
        this.setCurrentTab(CeremonyDates.tabName);
    }

    render() {
        return (
            <div> Insert ceremony dates content here.</div>
        );
    }
}

export default withRouter(CeremonyDates);

export interface CeremonyDatesProps {

}

export interface CeremonyDatesState {

}