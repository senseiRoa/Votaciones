import { VotanteModel } from "./VotanteModel";

export interface VotacionVotanteModel {
  id: string;
  idVotacion: string;
  idVotante: string;
  votante: VotanteModel;
}
