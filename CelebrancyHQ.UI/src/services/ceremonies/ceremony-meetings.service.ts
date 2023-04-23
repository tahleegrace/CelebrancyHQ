import { RootContextProps } from "../../context/root-context";
import { CeremonyFileDTO } from "../../interfaces/ceremony-file";
import { CeremonyMeetingDTO } from "../../interfaces/ceremony-meeting";
import { UpdateCeremonyMeetingQuestionRequest } from "../../interfaces/update-ceremony-meeting-question-request";
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

    public async updateMeeting(ceremonyId: number, meeting: UpdateCeremonyMeetingRequest, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremonyId}/meetings/${meeting.id}`;

        await this.httpService.putWithNoResponse(url, meeting, context);
    }

    public async updateQuestion(ceremonyId: number, meetingId: number, question: UpdateCeremonyMeetingQuestionRequest, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremonyId}/meetings/${meetingId}/questions`;

        return this.httpService.putWithNoResponse(url, question, context);
    }

    public async deleteParticipant(ceremonyId: number, meetingId: number, personId: number, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremonyId}/meetings/${meetingId}/participants?personId=${personId}`;

        return this.httpService.delete(url, context);
    }

    public async getMeetingFiles(ceremonyId: number, meetingId: number, context: RootContextProps): Promise<CeremonyFileDTO[]> {
        const url = `ceremonies/${ceremonyId}/meetings/${meetingId}/files`;

        return this.httpService.get<CeremonyFileDTO[]>(url, context);
    }
}