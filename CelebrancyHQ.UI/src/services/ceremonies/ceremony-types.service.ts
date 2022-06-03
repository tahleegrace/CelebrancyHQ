import { ContextProps } from "../../context/context";
import { CeremonyTypeDTO } from "../../interfaces/ceremony-type";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyTypesService {
    static serviceName = 'ceremony-types-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getAll(context: ContextProps): Promise<CeremonyTypeDTO[]> {
        return await this.httpService.get<CeremonyTypeDTO[]>("ceremony-types", context);
    }
}