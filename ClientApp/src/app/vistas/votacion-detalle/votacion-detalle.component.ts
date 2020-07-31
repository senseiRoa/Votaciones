import { RondaVotacionWrapperModel } from './../../model/RondaVotacionWrapperModel';
import { RondaVotacionService } from 'src/app/servicios/ronda-votacion.service';
import { VotacionVotanteModel } from 'src/app/model/VotacionVotanteModel';
import { VotacionCandidatoModel } from 'src/app/model/VotacionCandidatoModel';

import { VotacionModel } from 'src/app/model/VotacionModel';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VotacionService } from 'src/app/servicios/votacion.service';

import { ResponseApi } from 'src/app/model/response';
import { MessageService, SelectItem } from 'primeng/api';
import { RondaVotacionModel } from 'src/app/model/RondaVotacionModel';
import { RondaModel } from 'src/app/model/RondaModel';

@Component({
  selector: 'app-votacion-detalle',
  templateUrl: './votacion-detalle.component.html',
  styleUrls: ['./votacion-detalle.component.css']
})
export class VotacionDetalleComponent implements OnInit {
  id: string;
  votacion: VotacionModel;
  candidatos: VotacionCandidatoModel[];
  candidatosModal: SelectItem[];
  votantesModel: SelectItem[];
  votantes: VotacionVotanteModel[];
  rondas: RondaModel[];
  displayDialog: boolean;
  rondaEntity: RondaVotacionWrapperModel;
  constructor(private rutaActiva: ActivatedRoute,
    private messageService: MessageService,
    private votacionService: VotacionService,
    private rondaVotacionService: RondaVotacionService

  ) {

  }

  async ngOnInit() {
    this.id = this.rutaActiva.snapshot.params.id;
    await this.cargarVotacion();
  }
  async cargarVotacion() {
    try {
      const result = await this.votacionService.getByIdAsync(this.id) as ResponseApi;

      if (result.status === true) {
        this.votacion = result.message;

      }
      this.votacionService.getAllCandidatosByVotacionId(this.id).subscribe(response => {
        if (response.status === true) {
          this.candidatos = response.message;

        }
      });
      this.votacionService.getAllVotantesByVotacionId(this.id).subscribe(response => {
        if (response.status === true) {
          this.votantes = response.message;

        }
      });

      this.cargarrondas();
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }
  cargarrondas() {
    this.rondaVotacionService.getAllByVotacionId(this.id).subscribe(response => {
      if (response.status === true) {
        this.rondas = response.message;

      }
    });
  }
  async showDialogToAdd() {
    this.displayDialog = true;
    this.rondaEntity = {} as RondaVotacionWrapperModel;
    this.rondaEntity.rondavotacion = {} as RondaVotacionModel;
    this.rondaEntity.rondavotacion.idVotacion = this.id;
    try {

      this.candidatosModal = this.candidatos.map(c => ({ label: c.candidato.nombre, value: c.id }));
      this.votantesModel = this.votantes.map(v => ({ label: v.votante.nombre, value: v.id }));

      this.rondaEntity.votantes = this.votantesModel.map(v => v.value);
    } catch (error) {

      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }
  async save() {
    try {
      let guardar = true;
      //validamos
      if (this.rondaEntity.rondavotacion.descripcion === '') {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo descripción es requerido' });
        guardar = false;
      }

      if (this.rondaEntity.votantes == null || this.rondaEntity.votantes.length === 0) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo votantes es requerido' });
        guardar = false;
      }
      if (this.rondaEntity.candidatos == null || this.rondaEntity.candidatos.length === 0) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Candidatos es requerido' });
        guardar = false;
      }
      if (guardar === true) {

        const result = await this.rondaVotacionService.createAsync(this.rondaEntity) as ResponseApi;
        if (result.status === true) {

          this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se creó correctamente la votación' });
          this.displayDialog = false;
          this.rondaEntity = null;
          this.cargarrondas();

        } else {

          this.messageService.add({ severity: 'error', summary: 'error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
        }

      }

    } catch (error) {

      console.log(error);
      if (error.error.message) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: error.error.message });
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
      }
    }
  }
  async downloadReport() {
    try {
      const blob = await this.votacionService.downloadReport(this.id);
      const url = window.URL.createObjectURL(blob);
      window.open(url);

    } catch (error) {

      console.log(error);
      if (error.error.message) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: error.error.message });
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error Generando el reporte, intentelo de nuevo' });
      }
    }
  }
}


