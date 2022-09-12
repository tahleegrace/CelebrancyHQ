import { RootContextProps } from "../../context/root-context";
import { CeremonyMeetingDTO } from "../../interfaces/ceremony-meeting";
import { UpdateCeremonyMeetingRequest } from "../../interfaces/update-ceremony-meeting-request";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyMeetingsService {
    static serviceName = 'ceremony-meetings-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getMeetings(ceremonyId: number, context: RootContextProps): Promise<CeremonyMeetingDTO[]> {
        const url = `ceremonies/${ceremonyId}/meetings`;

        return await this.httpService.get<CeremonyMeetingDTO[]>(url, context);
    }

    public async getMeeting(ceremonyId: number, meetingId: number, context: RootContextProps): Promise<CeremonyMeetingDTO> {
        const url = `ceremonies/${ceremonyId}/meetings/${meetingId}`;

        return await this.httpService.get<CeremonyMeetingDTO>(url, context);
    }

    public async update(ceremonyId: number, meeting: UpdateCeremonyMeetingRequest, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremonyId}/meetings/${ceremonyId}`;

        await this.httpService.putWithNoResponse(url, meeting, context);
    }
}