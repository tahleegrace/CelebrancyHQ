import { CeremonyParticipantsList } from "../../../../components/ceremonies/ceremony-participants-list/ceremony-participants-list";
import { CeremonyParticipantCodes } from "../../../../constants/ceremonies/ceremony-participant-codes";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyTypeParticipantDTO } from "../../../../interfaces/ceremony-type-participant";
import { CeremonyTypeParticipantsService } from "../../../../services/ceremonies/ceremony-type-participants.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";
import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyParticipants extends CommonTab<CeremonyParticipantsProps, CeremonyParticipantsState> {
    static tabName = "participants";

    private ceremonyTypeParticipantsService = DependencyService.getInstance().getDependency<CeremonyTypeParticipantsService>(CeremonyTypeParticipantsService.serviceName);

    constructor(props: CeremonyParticipantsProps) {
        super(props);

        this.state = {
            ceremonyTypeParticipants: []
        };
    }

    async componentDidMount() {
        this.setCurrentTab(CeremonyParticipants.tabName);

        const context = this.context as CeremonyDetailsContextProps;

        // Load the ceremony type participants.
        const ceremonyTypeParticipants = await this.ceremonyTypeParticipantsService.getAll(context.ceremony.ceremonyTypeId, CeremonyParticipantCodes.InvitedGuest,
            context.rootContext as RootContextProps);

        this.setState({
            ceremonyTypeParticipants: ceremonyTypeParticipants
        });
    }

    render() {
        return (
            <div className="container-fluid p-0">
                {this.state.ceremonyTypeParticipants.map(ceremonyTypeParticipant => 
                (
                    <CeremonyParticipantsList key={ceremonyTypeParticipant.id} ceremonyTypeParticipant={ceremonyTypeParticipant} />
                ))
                }
            </div>
        );
    }
}

export default withRouter(CeremonyParticipants);

interface CeremonyParticipantsProps {

}

interface CeremonyParticipantsState {
    ceremonyTypeParticipants: CeremonyTypeParticipantDTO[];
}