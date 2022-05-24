import { User } from "../../interfaces/user";
import { DependencyService } from "../dependencies/dependency.service";
import { StorageService } from "../storage/storage.service";

export class AuthenticationService {
    static serviceName = 'authentication-service';

    private static currentUserKey = 'currentUser';

    private storageService = DependencyService.getInstance().getDependency<StorageService>(StorageService.serviceName);

    public currentUser(): User | null {
        return this.storageService.getItem<User>(AuthenticationService.currentUserKey);
    }

    public async login(emailAddress: string, password: string): Promise<User | null> {
        // TODO: Call a web service to login.
        if (emailAddress === 'error@example.com') {
            throw new Error('User name or password is incorrect');
        } else {
            const user: User = {
                id: 1,
                firstName: 'Tahlee-Joy',
                lastName: 'Grace',
                emailAddress: emailAddress
            };

            this.storageService.setItem(AuthenticationService.currentUserKey, user);

            return user;
        }
    }
}