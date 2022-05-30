import config from "../../config";

export class HttpService {
    static serviceName = 'http-service';

    public async post<BodyType, ReturnType>(url: string, body: BodyType): Promise<ReturnType> {
        const response = await fetch(`${config.api.url}/${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        });

        return await response.json();
    }
}