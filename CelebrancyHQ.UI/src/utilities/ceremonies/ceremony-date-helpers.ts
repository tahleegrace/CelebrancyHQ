import { CeremonyDateDTO } from "../../interfaces/ceremony-date";

export function findDateByCode(dates: CeremonyDateDTO[], code: string): CeremonyDateDTO {
    return dates.filter(date => date.code === code)[0];
}