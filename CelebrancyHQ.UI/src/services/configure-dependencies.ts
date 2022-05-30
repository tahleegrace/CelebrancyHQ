import { AuthenticationService } from "./authentication/authentication.service";
import { CeremoniesService } from "./ceremonies/ceremonies.service";
import { DependencyService } from "./dependencies/dependency.service";
import { HttpService } from "./http/http.service";

function configureDependencies() {
    DependencyService.getInstance().setDependency(HttpService.serviceName, new HttpService());
    DependencyService.getInstance().setDependency(AuthenticationService.serviceName, new AuthenticationService());
    DependencyService.getInstance().setDependency(CeremoniesService.serviceName, new CeremoniesService());
}

export default configureDependencies;