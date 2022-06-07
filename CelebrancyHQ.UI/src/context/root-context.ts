import React from "react";
import { AuthTokenDTO } from "../interfaces/auth-token";

export interface RootContextProps {
    currentUser: AuthTokenDTO | null;
    setCurrentUser: (user: AuthTokenDTO | null) => void;

    currentPage: string | null;
    setCurrentPage: (page: string) => void;
}

const contextData: RootContextProps = {
    currentUser: null,
    setCurrentUser: (user: AuthTokenDTO | null) => { },

    currentPage: null,
    setCurrentPage: (page: string) => { }
};

export const CelebrancyHQRootContext = React.createContext(contextData);