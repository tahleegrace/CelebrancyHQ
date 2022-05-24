import { AuthenticationService } from "./authentication/authentication.service";
import { DependencyService } from "./dependencies/dependency.service";
import { StorageService } from "./storage/storage.service";

function configureDependencies() {
    DependencyService.getInstance().setDependency(StorageService.serviceName, new StorageService());
    DependencyService.getInstance().setDependency(AuthenticationService.serviceName, new AuthenticationService());
}

export default configureDependencies;