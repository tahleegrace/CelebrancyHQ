export interface CeremonyDateDTO {
    id?: number;
    code: string;
    name: string;
    customName?: string;
    date: Date,
    notes?: string;
}