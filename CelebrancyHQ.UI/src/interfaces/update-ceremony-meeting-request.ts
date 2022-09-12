import { UpdateFieldRequest } from "./update-field-request";

export interface UpdateCeremonyMeetingRequest {
    id: number;
    name?: UpdateFieldRequest<string>;
    description?: UpdateFieldRequest<string>;
    date?: UpdateFieldRequest<Date>;
}