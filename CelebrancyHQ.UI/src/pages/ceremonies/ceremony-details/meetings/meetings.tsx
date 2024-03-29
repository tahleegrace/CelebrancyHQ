import { cloneDeep } from "lodash";
import { CeremonyMeetingsList } from "../../../../components/ceremonies/meetings/ceremony-meetings-list/ceremony-meetings-list";
import { CeremonyFieldNames } from "../../../../constants/ceremonies/ceremony-field-names";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyMeetingDTO } from "../../../../interfaces/ceremony-meeting";
import { CeremonyMeetingsService } from "../../../../services/ceremonies/ceremony-meetings.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";
import { getCeremonyPermission } from "../../../../utilities/ceremonies/ceremony-permission-helpers";
import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyMeetings extends CommonTab<CeremonyMeetingsProps, CeremonyMeetingsState> {
    static tabName = "meetings";

    private ceremonyMeetingsService = DependencyService.getInstance().getDependency<CeremonyMeetingsService>(CeremonyMeetingsService.serviceName);

    constructor(props: CeremonyMeetingsProps) {
        super(props);

        this.state = {
            ceremonyId: null,
            meetings: [],
            canEditMeetings: false
        };
    }

    async componentDidMount() {
        this.setCurrentTab(CeremonyMeetings.tabName);

        const context = this.context as CeremonyDetailsContextProps;

        // Load the ceremony meetings.
        const meetings = await this.ceremonyMeetingsService.getMeetings(context.ceremonyId as number, context.rootContext as RootContextProps);

        this.setState({
            ceremonyId: context.ceremonyId as number,
            meetings: meetings,
            canEditMeetings: getCeremonyPermission(context.ceremony.effectivePermissions, CeremonyFieldNames.Meetings)?.canEdit || false
        });
    }

    meetingUpdated(meeting: CeremonyMeetingDTO) {
        const newMeetings = cloneDeep(this.state.meetings);

        const newMeeting = newMeetings.filter(m => m.id == meeting.id)[0];
        newMeeting.name = meeting.name;
        newMeeting.description = meeting.description;
        newMeeting.date = meeting.date;

        this.setState({
            meetings: newMeetings
        });
    }

    render() {
        const context = this.context as CeremonyDetailsContextProps;

        return (
            <div className="container-fluid p-0">
                <CeremonyMeetingsList context={context} ceremonyId={this.state.ceremonyId as number} meetings={this.state.meetings} canEdit={this.state.canEditMeetings} meetingUpdated={this.meetingUpdated.bind(this)} />
            </div>
        );
    }
}

export default withRouter(CeremonyMeetings);

interface CeremonyMeetingsProps {

}

interface CeremonyMeetingsState {
    ceremonyId: number | null;
    meetings: CeremonyMeetingDTO[];
    canEditMeetings: boolean;
}