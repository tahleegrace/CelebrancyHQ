import { DependencyService } from "./dependencies/dependency.service";
import { StorageService } from "./storage/storage.service";

function configureDependencies() {
    DependencyService.getInstance().setDependency(StorageService.serviceName, new StorageService());
}

export default configureDependencies;