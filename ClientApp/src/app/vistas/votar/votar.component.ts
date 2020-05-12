import { RondaCandidatoModel } from './../../model/RondaCandidatoModel';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RondaVotacionService } from 'src/app/servicios/ronda-votacion.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-votar',
  templateUrl: './votar.component.html',
  styleUrls: ['./votar.component.css']
})
export class VotarComponent implements OnInit {

  id: any;
  candidatos: RondaCandidatoModel[];
  seleccion: string;
  constructor(
    private rutaActiva: ActivatedRoute,
    private messageService: MessageService,
    private rondaVotacionService: RondaVotacionService

  ) { }

  async ngOnInit() {
    await this.cargarDatos();
    this.id = this.rutaActiva.snapshot.params.id;
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

    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }


}
