import React from "react";
import { User } from "../interfaces/user";

export interface ContextProps {
    currentUser: User | null;
    setCurrentUser: (user: User | null) => void;

    currentPage: string | null;
    setCurrentPage: (page: string) => void;
}

const contextData: ContextProps = {
    currentUser: null,
    setCurrentUser: (user: User | null) => { },

    currentPage: null,
    setCurrentPage: (page: string) => { }
};

export const CelebrancyHQContext = React.createContext(contextData);