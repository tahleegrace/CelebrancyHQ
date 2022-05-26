import { useContext } from "react";
import { Navigate, useLocation } from "react-router-dom"
import { CelebrancyHQContext } from "../../context/context";

// SOURCE: https://stackoverflow.com/a/70357802/3713362
// Redirects to the dashboard or login page based on whether a user is logged in or not.
const DefaultPage = (): JSX.Element => {
    const location = useLocation();
    const context = useContext(CelebrancyHQContext);
    const page = context.currentUser ? 'dashboard' : 'login';

    return (
        <Navigate
            replace={true}
            to={page}
            state={{ from: `${location.pathname}${location.search}` }}
        />
    );
}

export default DefaultPage;