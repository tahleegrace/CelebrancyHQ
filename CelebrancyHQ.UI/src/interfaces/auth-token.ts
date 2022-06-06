import { PersonDTO } from "./person";

export interface AuthTokenDTO {
    token: string;
    expiresIn: number;
    user: PersonDTO;
}