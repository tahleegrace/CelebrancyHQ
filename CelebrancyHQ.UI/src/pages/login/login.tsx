import React from "react";

export class Login extends React.Component<LoginProps, LoginState> {
    constructor(props: LoginProps) {
        super(props);
    }

    render() {
        return (
            <main>
                <h1>Login</h1>
                <form id="login-form">
                    <div className="container-fluid p-0">
                        <div className="row form-group">
                            <div className="col-2">
                                <label htmlFor="email-address" className="col-form-label">Email address:</label>
                            </div>
                            <div className="col-10">
                                <input id="email-address" type="email" className="form-control" />
                            </div>
                        </div>
                        <div className="row form-group">
                            <div className="col-2">
                                <label htmlFor="password" className="col-form-label">Password:</label>
                            </div>
                            <div className="col-10">
                                <input id="password" type="password" className="form-control" />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-2">
                            </div>
                            <div className="col-10">
                                <button type="submit" className="btn btn-primary">Login</button>
                            </div>
                        </div>
                    </div>
                </form>
            </main>
        );
    }
}

interface LoginProps {

}

interface LoginState {

}