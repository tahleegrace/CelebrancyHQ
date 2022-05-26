import React from "react";
import { User } from "../interfaces/user";

export interface ContextProps {
    currentUser: User | null;
    setCurrentUser: (user: User) => void;
}

const contextData: ContextProps = {
    currentUser: null,
    setCurrentUser: (user: User) => { }
};

export const CelebrancyHQContext = React.createContext(contextData);