import { RondaVotacionModel } from "./RondaVotacionModel";

export interface RondaVotacionWrapperModel {
  rondavotacion: RondaVotacionModel;
  candidatos: string[];
  votantes: string[];
}
