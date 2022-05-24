import { User } from "../../interfaces/user";
import { DependencyService } from "../dependencies/dependency.service";
import { StorageService } from "../storage/storage.service";

export class AuthenticationService {
    static serviceName = 'authentication-service';

    private static currentUserKey = 'currentUser';

    private _storageService = DependencyService.getInstance().getDependency<StorageService>(StorageService.name);

    public currentUser(): User | null {
        return this._storageService.getItem<User>(AuthenticationService.currentUserKey);
    }

    public async login(emailAddress: string, password: string) {
        // TODO: Call a web service to login.
        const user: User = {
            id: 1,
            firstName: 'Tahlee-Joy',
            lastName: 'Grace',
            emailAddress: 'tahlee.grace@gmail.com'
        };

        this._storageService.setItem(AuthenticationService.currentUserKey, user);
    }
}