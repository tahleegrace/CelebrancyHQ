import moment from "moment";
import { RootContextProps } from "../../context/root-context";
import { CeremonyDateDTO } from "../../interfaces/ceremony-date";
import { CeremonyKeyDetailsDTO } from "../../interfaces/ceremony-key-details";
import { CeremonySummaryDTO } from "../../interfaces/ceremony-summary";
import { UpdateCeremonyRequest } from "../../interfaces/update-ceremony";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremoniesService {
    static serviceName = 'ceremonies-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async listCeremonies(weeksInFuture: number, participantTypeCode: string, context: RootContextProps): Promise<CeremonySummaryDTO[]> {
        let from = moment().add(weeksInFuture, 'weeks').startOf('isoWeek').format('YYYY-MM-DD');
        let to = moment().add(weeksInFuture, 'weeks').endOf('isoWeek').format('YYYY-MM-DD');

        const url = `ceremonies/${participantTypeCode}?from=${from}&to=${to}`;

        return await this.httpService.get<CeremonySummaryDTO[]>(url, context)
    }

    public async getKeyDetails(ceremonyId: number, context: RootContextProps): Promise<CeremonyKeyDetailsDTO> {
        const url = `ceremonies/${ceremonyId}/key-details`;

        return await this.httpService.get<CeremonyKeyDetailsDTO>(url, context);
    }

    public async getDates(ceremonyId: number, context: RootContextProps): Promise<CeremonyDateDTO[]> {
        const url = `ceremonies/${ceremonyId}/dates`;

        return await this.httpService.get<CeremonyDateDTO[]>(url, context);
    }

    public async update(ceremony: UpdateCeremonyRequest, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremony.id}`;

        await this.httpService.putWithNoResponse(url, ceremony, context);
    }
}