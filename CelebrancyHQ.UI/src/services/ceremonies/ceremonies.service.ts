import moment from "moment";
import { ContextProps } from "../../context/context";
import { CeremonySummaryDTO } from "../../interfaces/ceremony-summary";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremoniesService {
    static serviceName = 'ceremonies-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async listCeremonies(weeksInFuture: number, participantTypeCode: string, context: ContextProps): Promise<CeremonySummaryDTO[]> {
        let from = moment().add(weeksInFuture, 'weeks').startOf('isoWeek').format('YYYY-MM-DD');
        let to = moment().add(weeksInFuture, 'weeks').endOf('isoWeek').format('YYYY-MM-DD');

        const url = `ceremonies/${participantTypeCode}?from=${from}&to=${to}`;

        return await this.httpService.get<CeremonySummaryDTO[]>(url, context)
    }
}