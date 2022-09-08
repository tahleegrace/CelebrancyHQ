import { RootContextProps } from "../../context/root-context";
import { CeremonyMeetingDTO } from "../../interfaces/ceremony-meeting";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyMeetingsService {
    static serviceName = 'ceremony-meetings-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getMeetings(ceremonyId: number, context: RootContextProps): Promise<CeremonyMeetingDTO[]> {
        const url = `ceremonies/${ceremonyId}/meetings`;

        return await this.httpService.get<CeremonyMeetingDTO[]>(url, context);
    }
}