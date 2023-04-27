import React, { Fragment } from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { RootContextProps } from "../../../context/root-context";
import { CeremonyFileDTO } from "../../../interfaces/ceremony-file";
import { CeremonyFilesService } from "../../../services/ceremonies/ceremony-files.service";
import { DependencyService } from "../../../services/dependencies/dependency.service";
import { FilesService } from "../../../services/files/files.service";

export class CeremonyFilesList extends React.Component<CeremonyFilesListProps, CeremonyFilesListState> {
    private ceremonyFilesService = DependencyService.getInstance().getDependency<CeremonyFilesService>(CeremonyFilesService.serviceName);
    private filesService = DependencyService.getInstance().getDependency<FilesService>(FilesService.serviceName);

    constructor(props: CeremonyFilesListProps) {
        super(props);
    }

    render() {
        return (
            <Fragment>
                <div className="row">
                    <div className="col-1"></div>
                    <div className="col-1"></div>
                    <div className="col-3"><strong>Name</strong></div>
                    <div className="col-3"><strong>Description</strong></div>
                    <div className="col-2"><strong>Size</strong></div>
                    <div className="col-2"><strong>Status</strong></div>
                </div>
                {this.props.files && this.props.files.length > 0 ?
                    <Fragment>
                        {this.props.files.map(file =>
                            <div className="row" key={file.id}>
                                {this.props.canEdit ?
                                <Fragment>
                                    <div className="col-1">
                                        <button>Edit</button>
                                    </div>
                                    <div className="col-1">
                                        <button onClick={this.deleteFile.bind(this, file)}>Delete</button>
                                    </div>
                                </Fragment>: ""}
                                <div className="col-3">
                                    <a href="#" onClick={this.downloadFile.bind(this, file)}>{file.file.name}</a>
                                </div>
                                <div className="col-3">
                                    {file.description}
                                </div>
                                <div className="col-2">
                                    {file.file.size}
                                </div>
                                <div className="col-2">
                                    {file.file.status}
                                </div>
                            </div>
                        )}
                    </Fragment>
                : ""}
            </Fragment>
        );
    }

    async downloadFile(file: CeremonyFileDTO) {
        let fileToDownload = await this.ceremonyFilesService.getFileForDownload(this.props.ceremonyId, file.id, this.props.context.rootContext as RootContextProps);

        this.filesService.downloadFile(fileToDownload);
    }

    deleteFile(file: CeremonyFileDTO) {
        if (this.props.fileDeleted != null) {
            this.props.fileDeleted(file);
        }
    }
}

interface CeremonyFilesListProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    files: CeremonyFileDTO[];
    canEdit: boolean;
    fileDeleted: (file: CeremonyFileDTO) => void;
}

interface CeremonyFilesListState {

}