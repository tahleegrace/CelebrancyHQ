import React from "react";

export class Login extends React.Component<LoginProps, LoginState> {
    constructor(props: LoginProps) {
        super(props);
    }

    render() {
        return (
            <main>
                <h1>Login</h1>
                <div>Insert login page content here</div>
            </main>
        );
    }
}

interface LoginProps {

}

interface LoginState {

}