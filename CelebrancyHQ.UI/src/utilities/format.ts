import { UserDTO } from "../interfaces/user";

export function getUserFullName(user: UserDTO) {
    return `${user.firstName} ${user.lastName} ${user.businessName ? `(${user.businessName})` : ''}`;
};