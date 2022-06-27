import { RootContextProps } from "../../context/root-context";
import { CeremonyTypeParticipantDTO } from "../../interfaces/ceremony-type-participant";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyTypeParticipantsService {
    static serviceName = 'ceremony-type-participants-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getAll(ceremonyTypeId: number, codeToExclude: string, context: RootContextProps): Promise<CeremonyTypeParticipantDTO[]> {
        return await this.httpService.get<CeremonyTypeParticipantDTO[]>(`ceremony-types/${ceremonyTypeId}/participants?codeToExclude=${codeToExclude}`, context);
    }
}