import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyMeetings extends CommonTab<CeremonyMeetingsProps, CeremonyMeetingsState> {
    static tabName = "meetings";

    constructor(props: CeremonyMeetingsProps) {
        super(props);
    }

    render() {
        return (
            <div className="container-fluid p-0">
                This is the ceremony meetings tab.
            </div>
        );
    }
}

export default withRouter(CeremonyMeetings);

interface CeremonyMeetingsProps {

}

interface CeremonyMeetingsState {

}