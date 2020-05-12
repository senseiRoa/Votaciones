import { VotacionCandidatoModel } from "./VotacionCandidatoModel";
export interface RondaCandidatoModel {
  id: string;
  idRondaVotacion: string;
  idVotacionCandidato: string;
  votacionCandidato: VotacionCandidatoModel;
  estadoRegistro: number;
}
