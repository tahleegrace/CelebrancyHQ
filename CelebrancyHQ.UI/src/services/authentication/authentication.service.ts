import { ContextProps } from "../../context/context";
import { LoginDetailsDTO } from "../../interfaces/login-details";
import { UserDTO } from "../../interfaces/user";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class AuthenticationService {
    static serviceName = 'authentication-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async login(emailAddress: string, password: string, context: ContextProps): Promise<UserDTO> {
        const request: LoginDetailsDTO = {
            emailAddress: emailAddress,
            password: password
        };

        const result = await this.httpService.post<LoginDetailsDTO, UserDTO>("auth/login", request);
        context.setCurrentUser(result);

        return result;
    }
}