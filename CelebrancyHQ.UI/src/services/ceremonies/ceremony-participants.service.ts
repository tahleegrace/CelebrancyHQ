import { RootContextProps } from "../../context/root-context";
import { CeremonyParticipantDTO } from "../../interfaces/ceremony-participant";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyParticipantsService {
    static serviceName = 'ceremony-participants-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getParticipants(ceremonyId: number, context: RootContextProps): Promise<CeremonyParticipantDTO[]> {
        const url = `ceremonies/${ceremonyId}/participants`;

        return await this.httpService.get<CeremonyParticipantDTO[]>(url, context);
    }
}