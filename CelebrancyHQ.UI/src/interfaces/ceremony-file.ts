import { CeremonyTypeFileCategoryDTO } from "./ceremony-type-file-category";
import { FileDTO } from "./file";

export interface CeremonyFileDTO {
    id: number;
    category: CeremonyTypeFileCategoryDTO;
    file: FileDTO;
    description?: string;
}