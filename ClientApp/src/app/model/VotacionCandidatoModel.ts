import { CandidatoModel } from "./CandidatoModel";

export interface VotacionCandidatoModel {
  id: string;
  idVotacion: string;
  idCandidato: string;
  candidato: CandidatoModel;
}
