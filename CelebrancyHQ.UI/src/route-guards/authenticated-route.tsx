import { useContext } from "react";
import { Navigate, useLocation } from "react-router-dom"
import { CelebrancyHQContext } from "../context/context";

// SOURCE: https://stackoverflow.com/a/70357802/3713362
const AuthenticatedRoute = (props: { children: React.ReactNode }): JSX.Element => {
    const { children } = props;
    const location = useLocation();
    const context = useContext(CelebrancyHQContext);

    return context.currentUser ? (
        <>{children}</>
    ) : (
        <Navigate
            replace={true}
            to="/login"
            state={{ from: `${location.pathname}${location.search}` }}
        />
    )
}

export default AuthenticatedRoute;