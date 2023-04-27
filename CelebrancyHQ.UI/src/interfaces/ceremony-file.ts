import { CeremonyTypeFileCategoryDTO } from "./ceremony-type-file-category";
import { FileDTO } from "./file";

export interface CeremonyFileDTO {
    id: number;
    additionalData: any;
    category: CeremonyTypeFileCategoryDTO;
    file: FileDTO;
    description: string | null | undefined;
}