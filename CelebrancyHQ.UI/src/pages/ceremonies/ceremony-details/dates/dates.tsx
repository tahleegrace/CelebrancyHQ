import { cloneDeep } from "lodash";
import { MarriageDates } from "../../../../components/ceremonies/marriage-dates/marriage-dates";
import { CeremonyFieldNames } from "../../../../constants/ceremonies/ceremony-field-names";
import { CeremonyTypeCodes } from "../../../../constants/ceremonies/ceremony-type-codes";
import { CeremonyDetailsContextProps } from "../../../../context/ceremony-details-context";
import { RootContextProps } from "../../../../context/root-context";
import { CeremonyDateDTO } from "../../../../interfaces/ceremony-date";
import { CeremonyDatesService } from "../../../../services/ceremonies/ceremomy-dates.service";
import { DependencyService } from "../../../../services/dependencies/dependency.service";
import { getCeremonyPermission } from "../../../../utilities/ceremonies/ceremony-permission-helpers";
import { withRouter } from "../../../../utilities/with-router";
import { CommonTab } from "../common-tab/common-tab";

class CeremonyDates extends CommonTab<CeremonyDatesProps, CeremonyDatesState> {
    static tabName = 'dates';

    private ceremonyDatesService = DependencyService.getInstance().getDependency<CeremonyDatesService>(CeremonyDatesService.serviceName);

    constructor(props: CeremonyDatesProps) {
        super(props);

        this.state = {
            dates: [],
            canEditDates: false
        };
    }

    async dateUpdated(date: CeremonyDateDTO) {
        let newDates = cloneDeep(this.state.dates);

        let updateRequest = {
            id: date.id as number,
            code: date.code,
            date: date.date
        };

        const context = this.context as CeremonyDetailsContextProps;
        const createdDate = await this.ceremonyDatesService.update(context.ceremonyId as number, updateRequest, context.rootContext as RootContextProps);

        if (date.id) {
            let newDate = this.state.dates.filter(d => d.id == date.id)[0];
            newDate.date = date.date;
        } else {
            newDates.push(createdDate);
        }

        this.setState({ dates: newDates });
    }

    async componentDidMount() {
        this.setCurrentTab(CeremonyDates.tabName);

        const context = this.context as CeremonyDetailsContextProps;
        const dates = await this.ceremonyDatesService.getDates(context.ceremonyId as number, context.rootContext as RootContextProps);

        this.setState({
            dates: dates,
            canEditDates: getCeremonyPermission(context.ceremony.effectivePermissions, CeremonyFieldNames.Dates)?.canEdit || false
        });
    }

    render() {
        return (
            <div className="container-fluid p-0">
                {(this.context as CeremonyDetailsContextProps).ceremony.ceremonyTypeCode === CeremonyTypeCodes.Marriage ?
                    <MarriageDates dates={this.state.dates} canEdit={this.state.canEditDates} dateUpdated={this.dateUpdated.bind(this)} /> : ''}
            </div>
        );
    }
}

export default withRouter(CeremonyDates);

interface CeremonyDatesProps {

}

interface CeremonyDatesState {
    dates: CeremonyDateDTO[];
    canEditDates: boolean;
}