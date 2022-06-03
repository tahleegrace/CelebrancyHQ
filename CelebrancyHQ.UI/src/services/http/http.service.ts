import config from "../../config";
import { ContextProps } from "../../context/context";
import { HttpHeaders } from "../../interfaces/http-headers";

export class HttpService {
    static serviceName = 'http-service';

    getHeaders(context?: ContextProps): HttpHeaders {
        const headers: HttpHeaders = {
            'Content-Type': 'application/json',
        };

        if (context?.currentUser) {
            headers['Authorization'] = `Bearer ${context.currentUser.token}`
        }

        return headers;
    }

    public async get<ReturnType>(url: string, context?: ContextProps): Promise<ReturnType> {
        const response = await fetch(`${config.api.url}/${url}`, {
            method: 'GET',
            headers: this.getHeaders(context) as any,
        });

        return await response.json();
    }

    public async post<BodyType, ReturnType>(url: string, body: BodyType, context?: ContextProps): Promise<ReturnType> {
        const response = await fetch(`${config.api.url}/${url}`, {
            method: 'POST',
            headers: this.getHeaders(context) as any,
            body: JSON.stringify(body)
        });

        return await response.json();
    }
}