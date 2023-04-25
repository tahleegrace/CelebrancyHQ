import fileDownload from "js-file-download";
import { DownloadFileDTO } from "../../interfaces/file";

export class FilesService {
    static serviceName = 'files-service';

    public downloadFile(file: DownloadFileDTO): void {
        const binaryFileData = atob(file.fileData);

        fileDownload(binaryFileData, file.name, file.contentType);
    }
}