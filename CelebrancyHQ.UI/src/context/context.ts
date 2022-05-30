import React from "react";
import { UserDTO } from "../interfaces/user";

export interface ContextProps {
    currentUser: UserDTO | null;
    setCurrentUser: (user: UserDTO | null) => void;

    currentPage: string | null;
    setCurrentPage: (page: string) => void;
}

const contextData: ContextProps = {
    currentUser: null,
    setCurrentUser: (user: UserDTO | null) => { },

    currentPage: null,
    setCurrentPage: (page: string) => { }
};

export const CelebrancyHQContext = React.createContext(contextData);