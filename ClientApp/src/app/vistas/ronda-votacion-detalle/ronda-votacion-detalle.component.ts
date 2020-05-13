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
  data: any;
  data2: any;
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

      this.cargarResultados();


    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }


  cargarResultados() {
    try {


      this.rondaVotacionService.getResultados(this.id).subscribe(response => {
        if (response.status === true) {
          const resultados = response.message;

          this.data = {
            labels: resultados.candidatos,
            datasets: [
              {
                data: resultados.votos,
                backgroundColor: this.paleta(resultados.candidatos.length)
              }],
          };

          this.data2 = {
            labels: resultados.candidatos,
            datasets: [
              {
                label: 'Total votos' + resultados.totalVotos,
                backgroundColor: '#42A5F5',
                borderColor: '#1E88E5',
                data: resultados.votos
              },

            ]
          };
        }
      });



    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }


  paleta(setsCount: number) {

    const gradient = {
      0: [255, 255, 255, 1],
      20: [255, 236, 179, 1],
      45: [232, 82, 133, 1],
      65: [106, 27, 154, 1],
      100: [0, 0, 0, 1]
    };

    const gradientKeys = Object.keys(gradient);
    gradientKeys.sort(function (a, b) {
      return +a - +b;
    });

    const chartColors = [];
    for (let i = 0; i < setsCount; i++) {
      const gradientIndex = (i + 1) * (100 / (setsCount + 1)); //Find where to get a color from the gradient
      for (let j = 0; j < gradientKeys.length; j++) {
        const gradientKey = Number(gradientKeys[j]);
        if (gradientIndex === +gradientKey) { //Exact match with a gradient key - just get that color
          chartColors[i] = 'rgba(' + gradient[gradientKey].toString() + ')';
          break;
        } else if (gradientIndex < +gradientKey) { //It's somewhere between this gradient key and the previous
          const prevKey = Number(gradientKeys[j - 1]);
          const gradientPartIndex = (gradientIndex - prevKey) / (gradientKey - prevKey); //Calculate where
          const color = [];
          for (let k = 0; k < 4; k++) { //Loop through Red, Green, Blue and Alpha and calculate the correct color and opacity
            color[k] = gradient[prevKey][k] - ((gradient[prevKey][k] - gradient[gradientKey][k]) * gradientPartIndex);
            if (k < 3) color[k] = Math.round(color[k]);
          }
          chartColors[i] = 'rgba(' + color.toString() + ')';
          break;
        }
      }
    }

    return chartColors;
  }

}

