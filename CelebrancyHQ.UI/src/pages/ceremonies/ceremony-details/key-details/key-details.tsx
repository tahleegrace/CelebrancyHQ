import { withRouter } from "../../../../utilities/with-router";
import { CommonPage } from "../../../common-page/common-page";

class CeremonyKeyDetails extends CommonPage<CeremonyKeyDetailsProps, CeremonyKeyDetailsState> {
    constructor(props: CeremonyKeyDetailsProps) {
        super(props);
    }

    render() {
        return (
            <div>Insert key details content here.</div>
        );
    }
}

export default withRouter(CeremonyKeyDetails);

export interface CeremonyKeyDetailsProps {

}

export interface CeremonyKeyDetailsState {

}