export interface PhoneNumberDTO {
    id: number;
    type: string;
    isPrimary: boolean;
    description?: string;
    phoneNumber: string;
}