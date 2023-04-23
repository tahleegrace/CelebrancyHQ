import React, { Fragment } from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { CeremonyFileDTO } from "../../../interfaces/ceremony-file";

export class CeremonyFilesList extends React.Component<CeremonyFilesListProps, CeremonyFilesListState> {
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
                            <div className="row">
                                <div className="col-1">
                                    <button className="btn btn-link" role="link">Edit</button>
                                </div>
                                <div className="col-1">
                                    <button className="btn btn-link" role="link">Delete</button>
                                </div>
                                <div className="col-3">
                                    {file.file.name}
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
}

interface CeremonyFilesListProps {
    context: CeremonyDetailsContextProps;
    ceremonyId: number;
    files: CeremonyFileDTO[];
    canEdit: boolean;
}

interface CeremonyFilesListState {

}