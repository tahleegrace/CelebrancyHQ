import { CeremonySummaryDTO } from "../../interfaces/ceremony-summary";

export class CeremoniesService {
    static serviceName = 'ceremonies-service';

    public async listCeremonies(thisWeeksCeremonies: boolean): Promise<CeremonySummaryDTO[]> {
        // TODO: Call a web service to retrieve a list of ceremonies.
        // TODO: Add support for a custom date range.
        let ceremonies: CeremonySummaryDTO[] = [];

        if (thisWeeksCeremonies) {
            ceremonies = [
                {
                    id: 1,
                    ceremonyName: 'Wedding',
                    date: new Date(2022, 4, 26, 10, 30, 0),
                    clientName: 'John Smith and Angela Jones',
                    venueName: 'Graceville Presbyterian Church',
                    address: '12 Bank Rd, Graceville'
                },
                {
                    id: 2,
                    ceremonyName: 'Funeral',
                    date: new Date(2022, 4, 26, 14, 30, 0),
                    clientName: 'Scott Morrison',
                    venueName: 'Executive Building',
                    address: '1 William St, Brisbane City'
                },
                {
                    id: 3,
                    ceremonyName: 'Wedding',
                    date: new Date(2022, 4, 26, 16, 30, 0),
                    clientName: 'Anthony Albanese and Richard Marles',
                    venueName: 'Queensland Parliament House',
                    address: '2A George St, Brisbane City'
                }
            ];
        } else {
            ceremonies = [
                {
                    id: 4,
                    ceremonyName: 'Wedding',
                    date: new Date(2022, 4, 29, 10, 30, 0),
                    clientName: 'David Doe and Jane Smith',
                    venueName: 'Graceville Presbyterian Church',
                    address: '12 Bank Rd, Graceville'
                },
            ];
        }

        return Promise.resolve(ceremonies);
    }
}