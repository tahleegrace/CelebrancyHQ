export interface CeremonyMeetingQuestionDTO {
    id?: number;
    ceremonyTypeQuestionId: number;
    questionTypeCode: string;
    question: string;
    questionDescription: string;
    answer?: string;
}