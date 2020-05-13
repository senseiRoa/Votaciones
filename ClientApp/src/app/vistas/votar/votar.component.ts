import { RondaCandidatoModel } from './../../model/RondaCandidatoModel';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RondaVotacionService } from 'src/app/servicios/ronda-votacion.service';
import { MessageService } from 'primeng/api';
import { VotoWrapperModel } from 'src/app/model/VotoWrapperModel';

@Component({
  selector: 'app-votar',
  templateUrl: './votar.component.html',
  styleUrls: ['./votar.component.css']
})
export class VotarComponent implements OnInit {

  id: any;
  ocupado = false;
  candidatos: RondaCandidatoModel[];
  seleccion: string;
  constructor(
    private rutaActiva: ActivatedRoute,
    private messageService: MessageService,
    private rondaVotacionService: RondaVotacionService,
    private router: Router

  ) { }

  async ngOnInit() {
    this.id = this.rutaActiva.snapshot.params.id;
    await this.cargarDatos();
  }
  async cargarDatos() {

    this.rondaVotacionService.getAllCandidatosByRondaId(this.id).subscribe(response => {
      if (response.status === true) {
        this.candidatos = response.message;
      }
    });
  }

  async save() {
    try {
      if (this.seleccion) {

        this.ocupado = true;
        const voto = {} as VotoWrapperModel;
        voto.CandidatoId = this.seleccion === 'null' ? null : this.seleccion;
        voto.rondaId = this.id;
        const rta = await this.rondaVotacionService.createVotoAsync(voto);
        if (rta) {
          this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Se ha realizado correctamente la votación' });
        }
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Debe seleccionar una opción' });
        return;
      }

    } catch (responseError) {
      console.log(responseError);
      if (responseError.status === 400) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: responseError.error.message });
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
      }
    } finally {

      setTimeout(() => {
        this.ocupado = false;
        this.router.navigate(['']);
      }, 3000);
    }
  }


}
