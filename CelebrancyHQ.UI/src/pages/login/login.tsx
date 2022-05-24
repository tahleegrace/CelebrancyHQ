import React from "react";
import { AuthenticationService } from "../../services/authentication/authentication.service";
import { DependencyService } from "../../services/dependencies/dependency.service";

export class Login extends React.Component<LoginProps, LoginState> {
    private authenticationService = DependencyService.getInstance().getDependency<AuthenticationService>(AuthenticationService.serviceName);

    constructor(props: LoginProps) {
        super(props);

        this.state = {
            emailAddress: '',
            password: '',
        };

        this.setEmail = this.setEmail.bind(this);
        this.setPassword = this.setPassword.bind(this);
        this.login = this.login.bind(this);
    }

    setEmail(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ emailAddress: event.target.value });
    }

    setPassword(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ password: event.target.value });
    }

    async login(event: React.ChangeEvent<HTMLFormElement>) {
        event.preventDefault();

        const result = await this.authenticationService.login(this.state.emailAddress, this.state.password);

        // TODO: Handle invalid login details here.
    }

    // TODO: Add validation to this page.
    render() {
        return (
            <main>
                <h1>Login</h1>
                <form id="login-form" onSubmit={this.login}>
                    <div className="container-fluid p-0">
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="email-address" className="col-form-label">Email address:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                <input id="email-address" type="email" className="form-control" value={this.state.emailAddress} onChange={this.setEmail} />
                            </div>
                        </div>
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="password" className="col-form-label">Password:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                <input id="password" type="password" className="form-control" value={this.state.password} onChange={this.setPassword} />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-lg-10 col-sm-9 col-12 offset-lg-2 offset-sm-3">
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
    emailAddress: string;
    password: string;
}