import React from "react";
import { CeremonyDetailsContext, CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";

export abstract class CommonTab<P, S> extends React.Component<P, S> {
    static contextType = CeremonyDetailsContext;

    constructor(props: P) {
        super(props);
    }

    setCurrentTab(tab: string) {
        (this.context as CeremonyDetailsContextProps).setCurrentTab(tab);
    }
}