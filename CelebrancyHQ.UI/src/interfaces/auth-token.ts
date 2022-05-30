import { UserDTO } from "./user";

export interface AuthTokenDTO {
    token: string;
    expiresIn: number;
    user: UserDTO;
}