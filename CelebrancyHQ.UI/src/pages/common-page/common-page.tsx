import React from "react";
import { CelebrancyHQContext, ContextProps } from "../../context/context";

export abstract class CommonPage<P, S> extends React.Component<P, S> {
    static contextType = CelebrancyHQContext;

    constructor(props: P) {
        super(props);
    }

    setCurrentPage(page: string) {
        (this.context as ContextProps).setCurrentPage(page);
    }
}