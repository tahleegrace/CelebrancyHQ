import { Navigate, useLocation } from "react-router-dom"
import { AuthenticationService } from "../../services/authentication/authentication.service";
import { DependencyService } from "../../services/dependencies/dependency.service";

// SOURCE: https://stackoverflow.com/a/70357802/3713362
// Redirects to the dashboard or login page based on whether a user is logged in or not.
const DefaultPage = (): JSX.Element => {
    const location = useLocation();

    const authenticationService = DependencyService.getInstance().getDependency<AuthenticationService>(AuthenticationService.serviceName);
    const page = authenticationService.currentUser() ? 'dashboard' : 'login';

    return (
        <Navigate
            replace={true}
            to={page}
            state={{ from: `${location.pathname}${location.search}` }}
        />
    );
}

export default DefaultPage;