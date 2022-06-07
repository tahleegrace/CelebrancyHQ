import { useContext } from "react";
import { Navigate, useLocation } from "react-router-dom"
import { CelebrancyHQRootContext } from "../context/root-context";

// SOURCE: https://stackoverflow.com/a/70357802/3713362
const UnauthenticatedOnlyRoute = (props: { children: React.ReactNode }): JSX.Element => {
    const { children } = props;
    const location = useLocation();
    const context = useContext(CelebrancyHQRootContext);

    return !context.currentUser ? (
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