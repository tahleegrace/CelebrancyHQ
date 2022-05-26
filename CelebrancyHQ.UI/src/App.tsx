import React, { Fragment } from 'react';
import { Link, Outlet } from 'react-router-dom';
import { CelebrancyHQContext, ContextProps } from './context/context';
import { User } from './interfaces/user';
import { getUserFullName } from './utilities/format';

export class App extends React.Component<AppProps, AppState> {
    constructor(props: AppProps) {
        super(props);

        this.state = {
            currentUser: null,
            setCurrentUser: (user: User | null) => {
                this.setState({ currentUser: user })
            },

            currentPage: null,
            setCurrentPage: (page: string) => {
                this.setState({ currentPage: page })
            }
        };
    }

    isPageActive(page: string) {
        return this.state.currentPage === page;
    }

    render() {
        return (
            <CelebrancyHQContext.Provider value={this.state}>
                <div className="container-fluid p-3 bg-light">
                    <header>
                        <nav className="navbar navbar-expand-lg navbar-light">
                            <a className="navbar-brand" href="#">CelebrancyHQ</a>
                            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                                <span className="navbar-toggler-icon"></span>
                            </button>

                            {this.state.currentUser ?
                                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                                    <ul className="navbar-nav mr-auto">
                                        <li className={`nav-item ${this.isPageActive('dashboard') ? 'active' : ''}`}>
                                            <Link className="nav-link" to="/dashboard">Dashboard</Link>
                                        </li>
                                        <li className={`nav-item ${this.isPageActive('my-ceremonies') ? 'active' : ''}`}>
                                            <Link className="nav-link" to="/my-ceremonies">My Ceremonies</Link>
                                        </li>
                                        <li className={`nav-item ${this.isPageActive('my-business') ? 'active' : ''}`}>
                                            <a className="nav-link" href="#">My Business</a>
                                        </li>
                                        <li className={`nav-item ${this.isPageActive('my-account') ? 'active' : ''}`}>
                                            <a className="nav-link" href="#">My Account</a>
                                        </li>
                                        <li className="nav-item">
                                            <a className="nav-link" href="#">Logout</a>
                                        </li>
                                    </ul>
                                    <div className="inline">
                                        {getUserFullName(this.state.currentUser)}
                                    </div>
                                </div>
                                : <Fragment />
                            }
                        </nav>
                    </header>
                    <div className="container m-0">
                        <Outlet />
                    </div>
                </div>
            </CelebrancyHQContext.Provider>
        );
    }
}

interface AppProps {

}

interface AppState extends ContextProps {
}