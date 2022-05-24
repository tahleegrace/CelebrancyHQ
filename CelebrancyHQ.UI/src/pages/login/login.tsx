import React from "react";

export class Login extends React.Component<LoginProps, LoginState> {
    constructor(props: LoginProps) {
        super(props);

        this.state = {
            emailAddress: '',
            password: ''
        };
    }

    setEmail(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ emailAddress: event.target.value });
    }

    setPassword(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ password: event.target.value });
    }

    render() {
        return (
            <main>
                <h1>Login</h1>
                <form id="login-form">
                    <div className="container-fluid p-0">
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="email-address" className="col-form-label">Email address:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                {this.state.emailAddress}
                                <input id="email-address" type="email" className="form-control" value={this.state.emailAddress} onChange={this.setEmail.bind(this)} />
                            </div>
                        </div>
                        <div className="row form-group">
                            <div className="col-lg-2 col-sm-3 col-12">
                                <label htmlFor="password" className="col-form-label">Password:</label>
                            </div>
                            <div className="col-lg-10 col-sm-9 col-12">
                                {this.state.password}
                                <input id="password" type="password" className="form-control" value={this.state.password} onChange={this.setPassword.bind(this)} />
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