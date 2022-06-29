import { CeremonyParticipantsList } from "../../../../components/ceremonies/ceremony-participants-list/ceremony-participants-list";
import { CeremonyFieldNames } from "../../../../constants/ceremonies/ceremony-field-names";
import { CeremonyParticipantCodes } from "../../../../constants/ceremonies/ceremony-participant-codes";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyParticipantDTO } from "../../../../interfaces/ceremony-participant";
import { CeremonyTypeParticipantDTO } from "../../../../interfaces/ceremony-type-participant";
import { CeremonyParticipantsService } from "../../../../services/ceremonies/ceremony-participants.service";
import { CeremonyTypeParticipantsService } from "../../../../services/ceremonies/ceremony-type-participants.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";
import { getCeremonyPermission } from "../../../../utilities/ceremonies/ceremony-permission-helpers";
import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyParticipants extends CommonTab<CeremonyParticipantsProps, CeremonyParticipantsState> {
    static tabName = "participants";

    private ceremonyTypeParticipantsService = DependencyService.getInstance().getDependency<CeremonyTypeParticipantsService>(CeremonyTypeParticipantsService.serviceName);
    private ceremonyParticipantsService = DependencyService.getInstance().getDependency<CeremonyParticipantsService>(CeremonyParticipantsService.serviceName);

    constructor(props: CeremonyParticipantsProps) {
        super(props);

        this.state = {
            ceremonyTypeParticipants: [],
            participants: [],
            canEditParticipants: false
        };
    }

    async componentDidMount() {
        this.setCurrentTab(CeremonyParticipants.tabName);

        const context = this.context as CeremonyDetailsContextProps;

        // Load the ceremony type participants.
        const ceremonyTypeParticipants = await this.ceremonyTypeParticipantsService.getAll(context.ceremony.ceremonyTypeId, CeremonyParticipantCodes.InvitedGuest,
            context.rootContext as RootContextProps);

        // Load the ceremony participants.
        const participants = await this.ceremonyParticipantsService.getParticipants(context.ceremonyId as number, context.rootContext as RootContextProps);

        this.setState({
            ceremonyTypeParticipants: ceremonyTypeParticipants,
            participants: participants,
            canEditParticipants: getCeremonyPermission(context.ceremony.effectivePermissions, CeremonyFieldNames.Participants)?.canEdit || false
        });
    }

    getParticipantsByCode(code: string) {
        return this.state.participants.filter(p => p.code === code);
    }

    render() {
        return (
            <div className="container-fluid p-0">
                {this.state.ceremonyTypeParticipants.map(ceremonyTypeParticipant => 
                (
                    <CeremonyParticipantsList key={ceremonyTypeParticipant.id}
                        ceremonyTypeParticipant={ceremonyTypeParticipant}
                        participants={this.getParticipantsByCode(ceremonyTypeParticipant.code)}
                        canEditParticipants={this.state.canEditParticipants} />
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
    participants: CeremonyParticipantDTO[];
    canEditParticipants: boolean;
}