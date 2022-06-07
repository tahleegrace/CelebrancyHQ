import { RootContextProps } from "../../context/root-context";
import { AuthTokenDTO } from "../../interfaces/auth-token";
import { LoginDetailsDTO } from "../../interfaces/login-details";
import { DependencyService } from "../dependencies/dependency.service";
import { HttpService } from "../http/http.service";

export class AuthenticationService {
    static serviceName = 'authentication-service';

    private httpService = DependencyService.getInstance().getDependency<HttpService>(HttpService.serviceName);

    public async login(emailAddress: string, password: string, context: RootContextProps): Promise<AuthTokenDTO> {
        const request: LoginDetailsDTO = {
            emailAddress: emailAddress,
            password: password
        };

        const result = await this.httpService.post<LoginDetailsDTO, AuthTokenDTO>("auth/login", request);
        context.setCurrentUser(result);

        return result;
    }
}