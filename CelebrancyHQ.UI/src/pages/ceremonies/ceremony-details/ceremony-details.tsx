import { withRouter } from "../../../utilities/with-router";
import { CommonPage } from "../../common-page/common-page";

class CeremonyDetails extends CommonPage<CeremonyDetailsProps, CeremonyDetailsState> {
    static pageName = 'my-ceremonies';

    constructor(props: CeremonyDetailsProps) {
        super({
            params: {
                ceremonyId: null
            }
        });
    }

    componentDidMount() {
        // TODO: Add validation to check that we're not accessing a ceremony the user is not a participant in.
        this.setCurrentPage(CeremonyDetails.pageName);
    }

    render() {
        return (
            <main>
                <h1>Ceremony {this.props.params.ceremonyId}</h1>
                <div>Insert ceremony details content here</div>
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

interface CeremonyDetailsState {

}