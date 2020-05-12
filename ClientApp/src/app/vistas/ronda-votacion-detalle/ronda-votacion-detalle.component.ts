import { MessageService } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RondaVotacionService } from 'src/app/servicios/ronda-votacion.service';
import { ResponseApi } from 'src/app/model/response';
import { RondaVotacionModel } from 'src/app/model/RondaVotacionModel';
import { RondaCandidatoModel } from 'src/app/model/RondaCandidatoModel';


@Component({
  selector: 'app-ronda-votacion-detalle',
  templateUrl: './ronda-votacion-detalle.component.html',
  styleUrls: ['./ronda-votacion-detalle.component.css']
})
export class RondaVotacionDetalleComponent implements OnInit {
  id: any;
  ronda: RondaVotacionModel;
  candidatos: RondaCandidatoModel[];

  constructor(private rutaActiva: ActivatedRoute,
    private rondaVotacionService: RondaVotacionService,
    private messageService: MessageService
  ) {


  }

  async ngOnInit() {
    this.id = this.rutaActiva.snapshot.params.id;
    await this.cargarRonda();
  }

  async cargarRonda() {
    try {
      const result = await this.rondaVotacionService.getByIdAsync(this.id) as ResponseApi;

      if (result.status === true) {
        this.ronda = result.message;

      }
      this.rondaVotacionService.getAllCandidatosByRondaId(this.id).subscribe(response => {
        if (response.status === true) {
          this.candidatos = response.message;

        }
      });


    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }
}
