import moment from "moment";

export function formatDate(date: Date) {
    return moment(date).format('dddd MMMM DD YYYY h:mm A');
}