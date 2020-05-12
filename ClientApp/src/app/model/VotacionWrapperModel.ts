import { VotacionModel } from "./VotacionModel";

export interface VotacionWrapperModel {
  votacion: VotacionModel;
  votantes: string[];
  candidatos: string[];
}
