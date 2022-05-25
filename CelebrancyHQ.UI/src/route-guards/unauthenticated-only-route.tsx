import { Navigate, useLocation } from "react-router-dom"
import { AuthenticationService } from "../services/authentication/authentication.service";
import { DependencyService } from "../services/dependencies/dependency.service";

// SOURCE: https://stackoverflow.com/a/70357802/3713362
const UnauthenticatedOnlyRoute = (props: { children: React.ReactNode }): JSX.Element => {
    const { children } = props;
    const location = useLocation();

    const authenticationService = DependencyService.getInstance().getDependency<AuthenticationService>(AuthenticationService.serviceName);

    return !authenticationService.currentUser() ? (
        <>{children}</>
    ) : (
        <Navigate
            replace={true}
            to="/dashboard"
            state={{ from: `${location.pathname}${location.search}` }}
        />
    )
}

export default UnauthenticatedOnlyRoute;