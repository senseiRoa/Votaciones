import { MessageService, SelectItem } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { VotacionModel } from 'src/app/model/VotacionModel';
import { ResponseApi } from 'src/app/model/response';
import { CandidatoModel } from 'src/app/model/CandidatoModel';
import { CandidatoService } from 'src/app/servicios/candidato.service';




@Component({
  selector: 'app-candidato',
  templateUrl: './candidato.component.html',
  styleUrls: ['./candidato.component.css']
})
export class CandidatoComponent implements OnInit {
  es: any;
  displayDialog = false;
  entity: CandidatoModel;

  candidatos: CandidatoModel[];
  constructor(
    private candidatoService: CandidatoService,
    private messageService: MessageService
  ) { }

  async ngOnInit() {
    this.es = this.candidatoService.getLocale();
    await this.cargarCandidatos();

  }
  async cargarCandidatos() {
    try {
      const result = await this.candidatoService.getAllAsync() as ResponseApi;
      if (result.status === true) {
        this.candidatos = result.message;
        this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se encontro (' + this.candidatos.length + ') Candidato(s)' });

      }
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }

  async showDialogToAdd() {

    this.displayDialog = true;
    this.entity = {} as CandidatoModel;
  }
  async save() {
    try {
      let guardar = true;
      //validamos
      if (this.entity.nombre === '') {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Nombre es requerido' });
        guardar = false;
      }
      if (this.entity.descripcion === '') {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El campo Descripción es requerido' });
        guardar = false;
      }

      if (guardar === true) {

        const result = await this.candidatoService.createAsync(this.entity) as ResponseApi;
        if (result.status === true) {

          this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se creó correctamente el registro del candidato' });
          this.displayDialog = false;
          this.entity = null;
          await this.cargarCandidatos();

        } else {

          this.messageService.add({ severity: 'error', summary: 'error', detail: 'Hubo un error creando el candidato' });
        }

      }

    } catch (error) {

      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }

}
