import React from "react";
import { CelebrancyHQRootContext, RootContextProps } from "../../context/root-context";

export abstract class CommonPage<P, S> extends React.Component<P, S> {
    static contextType = CelebrancyHQRootContext;

    constructor(props: P) {
        super(props);
    }

    setCurrentPage(page: string) {
        (this.context as RootContextProps).setCurrentPage(page);
    }
}