import { CommonPage } from "../../common-page/common-page";

export class MyCeremonies extends CommonPage<MyCeremoniesProps, MyCeremoniesState> {
    static pageName = 'my-ceremonies';

    constructor(props: MyCeremoniesProps) {
        super(props);
    }

    componentDidMount() {
        this.setCurrentPage(MyCeremonies.pageName);
    }

    render() {
        return (
            <main>
                <h1>My Ceremonies</h1>
                <div>Insert my ceremonies content here</div>
            </main>
        );
    }
}

interface MyCeremoniesProps {

}

interface MyCeremoniesState {

}