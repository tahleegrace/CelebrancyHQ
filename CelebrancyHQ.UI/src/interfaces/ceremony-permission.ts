export interface CeremonyPermissionDTO {
    field: string;
    canView: boolean;
    canEdit: boolean;
    canEditWithApproval: boolean;
    isApprover: boolean;
    canViewHistory: boolean;
}