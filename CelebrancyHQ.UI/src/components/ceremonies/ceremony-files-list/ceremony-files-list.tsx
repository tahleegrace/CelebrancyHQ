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

        this.state = {
            fileBeingEdited: null,
            oldDescription: null,
            newDescription: null
        };
    }

    fileInEditing(file: CeremonyFileDTO) {
        return this.state.fileBeingEdited == file.id;
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
                                        {
                                            !this.state.fileBeingEdited ? <button onClick={this.editFile.bind(this, file)}>Edit</button>
                                            : this.fileInEditing(file) ? <button onClick={this.saveFile.bind(this, file)}>Save</button> : ""
                                        }
                                    </div>
                                    <div className="col-1">
                                        {
                                                this.fileInEditing(file) ? <button onClick={this.cancelChanges.bind(this, file)}>Cancel</button>
                                                : <button onClick={this.deleteFile.bind(this, file)}>Delete</button>
                                        }
                                    </div>
                                </Fragment>: ""}
                                <div className="col-3">
                                    <a href="#" onClick={this.downloadFile.bind(this, file)}>{file.file.name}</a>
                                </div>
                                <div className="col-3">
                                    {this.fileInEditing(file) ?
                                        <input type="text" className="form-control" required value={this.state.newDescription as string} onChange={this.setDescription.bind(this)} />
                                        : file.description}
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

    editFile(file: CeremonyFileDTO) {
        if (!this.state.fileBeingEdited) {
            this.setState({ fileBeingEdited: file.id, oldDescription: file.description, newDescription: file.description });
        }
    }

    setDescription(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ newDescription: event.target.value });
    }

    async saveFile(file: CeremonyFileDTO) {
        if (this.props.fileSaved != null) {
            await this.props.fileSaved(file, this.state.newDescription);
        }

        this.setState({ fileBeingEdited: null, oldDescription: null, newDescription: null });
    }

    cancelChanges(file: CeremonyFileDTO) {
        this.setState({ fileBeingEdited: null, oldDescription: null, newDescription: null });
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
    fileSaved: (file: CeremonyFileDTO, newDescription: string | undefined | null) => Promise<void>;
    fileDeleted: (file: CeremonyFileDTO) => void;
}

interface CeremonyFilesListState {
    fileBeingEdited: number | null;

    oldDescription: string | undefined | null;
    newDescription: string | undefined | null;
}