import { CeremonyPermissionDTO } from "../../interfaces/ceremony-permission";

export function getCeremonyPermission(permissions: CeremonyPermissionDTO[], field: string): CeremonyPermissionDTO {
    return permissions.filter(p => p.field === field)[0];
}