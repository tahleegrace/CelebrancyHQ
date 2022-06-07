import React from "react";
import { CeremonyKeyDetailsDTO } from "../interfaces/ceremony-key-details";
import { RootContextProps } from "./root-context";

export interface CeremonyDetailsContextProps {
    ceremonyId: number | null;
    ceremony: CeremonyKeyDetailsDTO | null;
    rootContext: RootContextProps | null;

    currentTab: string | null;
    setCurrentTab: (tab: string) => void;
}

const contextData: CeremonyDetailsContextProps = {
    ceremonyId: null,
    ceremony: null,
    rootContext: null,

    currentTab: null,
    setCurrentTab: (tab: string) => { }
};

export const CeremonyDetailsContext = React.createContext(contextData);