import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyParticipants extends CommonTab<CeremonyParticipantsProps, CeremonyParticipantsState> {
    static tabName = "participants";

    constructor(props: CeremonyParticipantsProps) {
        super(props);
    }

    async componentDidMount() {
        this.setCurrentTab(CeremonyParticipants.tabName);
    }

    render() {
        return (
            <div>Insert ceremony participants content here</div>  
        );
    }
}

export default withRouter(CeremonyParticipants);

interface CeremonyParticipantsProps {

}

interface CeremonyParticipantsState {

}