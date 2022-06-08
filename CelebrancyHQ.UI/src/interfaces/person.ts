export interface PersonDTO {
    personId: number;
    userId?: number;
    firstName: string;
    lastName: string;
    preferredName?: string;
    title?: string;
    gender: string;
    organisationName?: string;
    emailAddress: string;
}