import { CeremonyDateDTO } from "../../interfaces/ceremony-date";

export function findOrCreateDateByCode(dates: CeremonyDateDTO[], code: string): CeremonyDateDTO {
    var date = dates.filter(date => date.code === code)[0];

    if (!date) {
        date = {
            code: code,
            date: null as any
        } as CeremonyDateDTO;
    }

    return date;
}