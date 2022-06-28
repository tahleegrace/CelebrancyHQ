import { RootContextProps } from "../../context/root-context";
import { CeremonyDateDTO } from "../../interfaces/ceremony-date";
import { UpdateCeremonyDateRequest } from "../../interfaces/update-ceremony-date-request";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyDatesService {
    static serviceName = 'ceremony-dates-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getDates(ceremonyId: number, context: RootContextProps): Promise<CeremonyDateDTO[]> {
        const url = `ceremonies/${ceremonyId}/dates`;

        return await this.httpService.get<CeremonyDateDTO[]>(url, context);
    }

    public async update(ceremonyId: number, date: UpdateCeremonyDateRequest, context: RootContextProps): Promise<CeremonyDateDTO> {
        const url = `ceremonies/${ceremonyId}/dates`;

        return await this.httpService.put(url, date, context);
    }
}