import { AuthenticationService } from "./authentication/authentication.service";
import { CeremoniesService } from "./ceremonies/ceremonies.service";
import { CeremonyTypeParticipantsService } from "./ceremonies/ceremony-type-participants.service";
import { CeremonyTypesService } from "./ceremonies/ceremony-types.service";
import { DependencyService } from "./dependencies/dependency.service";
import { HttpService } from "./http/http.service";

function configureDependencies() {
    DependencyService.getInstance().setDependency(HttpService.serviceName, new HttpService());
    DependencyService.getInstance().setDependency(AuthenticationService.serviceName, new AuthenticationService());
    DependencyService.getInstance().setDependency(CeremonyTypesService.serviceName, new CeremonyTypesService());
    DependencyService.getInstance().setDependency(CeremonyTypeParticipantsService.serviceName, new CeremonyTypeParticipantsService());
    DependencyService.getInstance().setDependency(CeremoniesService.serviceName, new CeremoniesService());
}

export default configureDependencies;