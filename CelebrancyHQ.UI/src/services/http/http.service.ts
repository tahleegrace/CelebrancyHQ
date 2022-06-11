import config from "../../config";
import { RootContextProps } from "../../context/root-context";
import { HttpHeaders } from "../../interfaces/http-headers";

export class HttpService {
    static serviceName = 'http-service';

    getHeaders(context?: RootContextProps): HttpHeaders {
        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        if (context?.currentUser) {
            headers['Authorization'] = `Bearer ${context.currentUser.token}`
        }

        return headers;
    }

    public async get<ReturnType>(url: string, context?: RootContextProps): Promise<ReturnType> {
        const response = await fetch(`${config.api.url}/${url}`, {
            method: 'GET',
            headers: this.getHeaders(context) as any,
        });

        return await response.json();
    }

    public async post<BodyType, ReturnType>(url: string, body: BodyType, context?: RootContextProps): Promise<ReturnType> {
        const response = await fetch(`${config.api.url}/${url}`, {
            method: 'POST',
            headers: this.getHeaders(context) as any,
            body: JSON.stringify(body)
        });

        return await response.json();
    }

    public async putWithNoResponse<BodyType>(url: string, body: BodyType, context?: RootContextProps): Promise<void> {
        await fetch(`${config.api.url}/${url}`, {
            method: 'PUT',
            headers: this.getHeaders(context) as any,
            body: JSON.stringify(body)
        });
    }
}