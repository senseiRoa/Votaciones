import { VotacionVotanteModel } from 'src/app/model/VotacionVotanteModel';
export interface RondaVotanteModel {
  id: string;
  idRondaVotacion: string;
  idVotacionVotante: string;
  votacionVotante: VotacionVotanteModel;
}

