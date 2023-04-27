import { RootContextProps } from "../../context/root-context";
import { DownloadFileDTO } from "../../interfaces/file";
import { UpdateCeremonyFileRequest } from "../../interfaces/update-ceremony-file-request";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class CeremonyFilesService {
    static serviceName = 'ceremony-files-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async getFileForDownload(ceremonyId: number, fileId: number, context: RootContextProps): Promise<DownloadFileDTO> {
        const url = `ceremonies/${ceremonyId}/files/${fileId}`;

        return this.httpService.get<DownloadFileDTO>(url, context);
    }

    public async update(ceremonyId: number, file: UpdateCeremonyFileRequest, context: RootContextProps): Promise<void> {
        const url = `ceremonies/${ceremonyId}/files/${file.id}`;

        return this.httpService.putWithNoResponse(url, file, context);
    }
}