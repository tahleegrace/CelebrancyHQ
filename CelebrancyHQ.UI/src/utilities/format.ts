import { User } from "../interfaces/user";

export function getUserFullName(user: User) {
    return `${user.firstName} ${user.lastName} ${user.businessName ? `(${user.businessName})` : ''}`;
};