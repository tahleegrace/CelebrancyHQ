import { ContextProps } from "../../context/context";
import { CeremonySummaryDTO } from "../../interfaces/ceremony-summary";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremoniesService {
    static serviceName = 'ceremonies-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async listCeremonies(thisWeeksCeremonies: boolean, participantTypeCode: string, context: ContextProps): Promise<CeremonySummaryDTO[]> {
        // TODO: Add support for a custom date range.
        return await this.httpService.get<CeremonySummaryDTO[]>(`ceremonies/${participantTypeCode}`, context)
    }
}