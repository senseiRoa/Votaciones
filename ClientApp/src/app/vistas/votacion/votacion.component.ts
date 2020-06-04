import { map } from 'rxjs/operators';
import { VotanteService } from './../../servicios/votante.service';
import { CandidatoService } from './../../servicios/candidato.service';
import { VotacionWrapperModel } from './../../model/VotacionWrapperModel';
import { MessageService, SelectItem } from 'primeng/api';
import { ResponseApi } from './../../model/response';
import { Component, OnInit } from '@angular/core';
import { VotacionService } from 'src/app/servicios/votacion.service';
import { VotacionModel } from 'src/app/model/VotacionModel';


@Component({
  selector: 'app-votacion',
  templateUrl: './votacion.component.html',
  styleUrls: ['./votacion.component.css']
})
export class VotacionComponent implements OnInit {
  es: any;
  displayDialog = false;
  entity: VotacionWrapperModel;
  votaciones: VotacionModel[];
  votantes: SelectItem[];
  candidatos: SelectItem[];
  constructor(private votacionService: VotacionService,
    private candidatoService: CandidatoService,
    private votanteService: VotanteService,
    private messageService: MessageService
  ) { }

  async ngOnInit() {
    this.es = this.votacionService.getLocale();
    await this.cargarVotaciones();

  }
  async cargarVotaciones() {
    try {
      const result = await this.votacionService.getAllAsync() as ResponseApi;
      if (result.status === true) {
        this.votaciones = result.message;
        this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se encontro (' + this.votaciones.length + ') Votacion(es)' });

      }
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }

  async showDialogToAdd() {

    this.displayDialog = true;
    this.entity = {} as VotacionWrapperModel;
    this.entity.votacion = {} as VotacionModel;
    try {
      const result = await this.votanteService.getAllAsync() as ResponseApi;
      this.votantes = result.message.map(v => ({ label: v.nombre, value: v.id }));


      const result2 = await this.candidatoService.getAllAsync() as ResponseApi;
      this.candidatos = result2.message.map(c => ({ label: c.nombre + ' - ' + c.descripcion, value: c.id }));
    } catch (error) {

      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }
  async save() {
    try {
      let guardar = true;
      //validamos
      if (this.entity.votacion.nombre === '') {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Nombre es requerido' });
        guardar = false;
      }
      if (this.entity.votacion.descripcion === '') {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Descripción es requerido' });
        guardar = false;
      }
      if (this.entity.votacion.fechaInicial === undefined) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Fecha Inicial es requerido' });
        guardar = false;
      }
      if (this.entity.votacion.fechaFinal === undefined) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Fecha Final es requerido' });
        guardar = false;
      }
      if (this.entity.votantes == null || this.entity.votantes === []) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Votantes es requerido' });
        guardar = false;
      }
      if (this.entity.candidatos == null || this.entity.candidatos === []) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Candidatos es requerido' });
        guardar = false;
      }
      if (guardar === true) {

        const result = await this.votacionService.createAsync(this.entity) as ResponseApi;
        if (result.status === true) {

          this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se creó correctamente la votación' });
          this.displayDialog = false;
          this.entity = null;
          await this.cargarVotaciones();

        } else {

          this.messageService.add({ severity: 'error', summary: 'error', detail: 'Hubo un error creando la votación' });
        }

      }

    } catch (error) {

      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }

}
