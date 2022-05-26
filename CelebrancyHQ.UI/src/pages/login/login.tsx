import React from "react";
import { Navigate } from "react-router-dom";
import { CelebrancyHQContext, ContextProps } from "../../context/context";
import { AuthenticationService } from "../../services/authentication/authentication.service";
import { DependencyService } from "../../services/dependencies/dependency.service";

export class Login extends React.Component<LoginProps, LoginState> {
    static contextType = CelebrancyHQContext;

    private authenticationService = DependencyService.getInstance().getDependency<AuthenticationService>(AuthenticationService.serviceName);
    private loginForm: React.RefObject<HTMLFormElement>;

    constructor(props: LoginProps) {
        super(props);

        this.state = {
            emailAddress: '',
            password: '',
            formSubmitted: false,
            loginFailed: false,
            loginSuccessful: false
        };

        this.setEmail = this.setEmail.bind(this);
        this.setPassword = this.setPassword.bind(this);
        this.login = this.login.bind(this);

        this.loginForm = React.createRef<HTMLFormElement>();
    }

    setEmail(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ emailAddress: event.target.value });
    }

    setPassword(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ password: event.target.value });
    }

    async login(event: React.ChangeEvent<HTMLFormElement>) {
        event.preventDefault();

        this.setState({ formSubmitted: true })

        if (this.loginForm.current && this.loginForm.current.checkValidity()) {
            try {
                await this.authenticationService.login(this.state.emailAddress, this.state.password, (this.context as ContextProps));
                this.setState({ loginFailed: false, loginSuccessful: true });
            } catch {
                this.setState({ loginFailed: true, loginSuccessful: false });
            }
        }
        
        // TODO: Handle invalid login details here.
    }

    // TODO: Add validation to this page.
    render() {
        return (
            this.state.loginSuccessful ?
            <Navigate to = "/dashboard" /> :
            <main>
                <h1>Login</h1>
                <div className={`alert alert-danger ${!this.state.loginFailed ? 'd-none' : ''}`}>
                    Your user name and/or password were incorrect. Please try again.
                </div>
                <form id="login-form" ref={this.loginForm} className={`needs-validation ${this.state.formSubmitted ? 'was-validated' : ''}`} noValidate onSubmit={this.login}>
                    <div className="container-fluid p-0">
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="email-address" className="col-form-label">Email address:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                <input id="email-address" type="email" className="form-control" required value={this.state.emailAddress} onChange={this.setEmail} />
                                <div className="invalid-feedback">
                                    Please provide an email address.
                                </div>
                            </div>
                        </div>
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="password" className="col-form-label">Password:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                <input id="password" type="password" className="form-control" required value={this.state.password} onChange={this.setPassword} />
                                <div className="invalid-feedback">
                                    Please provide a password.
                                </div>
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
    formSubmitted: boolean;
    loginFailed: boolean;
    loginSuccessful: boolean;
}