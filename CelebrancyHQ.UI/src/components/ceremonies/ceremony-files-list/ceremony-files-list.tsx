import React from "react";
import { CeremonyDetailsContextProps } from "../../../context/ceremony-details-context";
import { CeremonyFileDTO } from "../../../interfaces/ceremony-file";

export class CeremonyFilesList extends React.Component<CeremonyFilesListProps, CeremonyFilesListState> {
    constructor(props: CeremonyFilesListProps) {
        super(props);
    }

    render() {
        return (
            <div>This is the ceremony files list.</div>
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