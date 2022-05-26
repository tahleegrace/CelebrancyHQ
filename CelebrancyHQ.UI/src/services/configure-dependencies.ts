import { AuthenticationService } from "./authentication/authentication.service";
import { DependencyService } from "./dependencies/dependency.service";

function configureDependencies() {
    DependencyService.getInstance().setDependency(AuthenticationService.serviceName, new AuthenticationService());
}

export default configureDependencies;