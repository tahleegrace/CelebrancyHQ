import React from "react";
import { AuthTokenDTO } from "../interfaces/auth-token";

export interface ContextProps {
    currentUser: AuthTokenDTO | null;
    setCurrentUser: (user: AuthTokenDTO | null) => void;

    currentPage: string | null;
    setCurrentPage: (page: string) => void;
}

const contextData: ContextProps = {
    currentUser: null,
    setCurrentUser: (user: AuthTokenDTO | null) => { },

    currentPage: null,
    setCurrentPage: (page: string) => { }
};

export const CelebrancyHQContext = React.createContext(contextData);