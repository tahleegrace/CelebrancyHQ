import { PhoneNumberDTO } from "../../interfaces/phone-number";

export function getPhoneNumberDisplay(number: PhoneNumberDTO) {
    return (<a href={'tel:' + number.phoneNumber}>{`${number.phoneNumber} (${number.type}${number.isPrimary ? ' - primary' : ''})`}</a>);
}