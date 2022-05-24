import * as _ from "lodash";

export class SessionStorage {
    getItem<ItemType>(key: string): ItemType | null {
        const item = sessionStorage.getItem(key);

        if (!_.isNil(item)) {
            return JSON.parse(item);
        }

        return null;
    }

    setItem<ItemType>(key: string, data: ItemType ) {
        sessionStorage.setItem(key, JSON.stringify(data))
    }
}