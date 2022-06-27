export interface CeremonyTypeParticipantDTO {
    id: number;
    code: string;
    name: string;
    description?: string;
    minimumNumberOfParticipants?: number;
    maximumNumberOfParticipants?: number;
    requiresAddress: boolean;
    requiresPhoneNumber: boolean;
}