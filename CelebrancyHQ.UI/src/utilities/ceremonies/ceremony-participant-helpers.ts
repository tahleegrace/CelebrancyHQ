import { CeremonyParticipantDTO } from "../../interfaces/ceremony-participant";

export function findParticipantsByCode(participants: CeremonyParticipantDTO[], code: string): CeremonyParticipantDTO[] {
    return participants.filter(participant => participant.code === code);
}