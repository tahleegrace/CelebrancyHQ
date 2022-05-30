import { ContextProps } from "../../context/context";
import { UserDTO } from "../../interfaces/user";

export class AuthenticationService {
    static serviceName = 'authentication-service';

    public async login(emailAddress: string, password: string, context: ContextProps): Promise<UserDTO | null> {
        // TODO: Call a web service to login.
        if (emailAddress === 'error@example.com') {
            throw new Error('User name or password is incorrect');
        } else {
            const user: UserDTO = {
                id: 1,
                firstName: 'Tahlee-Joy',
                lastName: 'Grace',
                businessName: 'Q Celebrancy',
                emailAddress: emailAddress
            };

            context.setCurrentUser(user);

            return user;
        }
    }
}