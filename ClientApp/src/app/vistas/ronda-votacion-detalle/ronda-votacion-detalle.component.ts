import { MessageService } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RondaVotacionService } from 'src/app/servicios/ronda-votacion.service';
import { ResponseApi } from 'src/app/model/response';
import { RondaVotacionModel } from 'src/app/model/RondaVotacionModel';
import { RondaCandidatoModel } from 'src/app/model/RondaCandidatoModel';
import { RondaVotanteModel } from 'src/app/model/RondaVotanteModel';
import { RondaVotanteWrapper } from 'src/app/model/RondaVotanteWrapper';


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
  votantes: RondaVotanteModel[];
  votantesEstadoVotos: RondaVotanteWrapper[];
  showResult = false;
  optionsC: any;

  constructor(private rutaActiva: ActivatedRoute,
    private rondaVotacionService: RondaVotacionService,
    private messageService: MessageService,
    private router: Router
  ) {


    this.optionsC = {
      scales: {
        xAxes: [{
          display: true,
          ticks: {
            beginAtZero: true,
            stepSize: 1,
          }
        }]
      }
    };
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

      this.rondaVotacionService.getAllVotantesByRondaId(this.id).subscribe(response => {
        if (response.status === true) {
          this.votantes = response.message;


        }
      });

      this.cargarResultados();


    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }
  cargarvotantespendientes() { }

  cargarResultados() {
    try {
      // todo: mensaje de error
      this.rondaVotacionService.getAllVotantesPendientesByRondaId(this.id).subscribe(response => {

        if (response.status === true) {
          this.votantesEstadoVotos = response.message;
          this.showResult = this.votantesEstadoVotos.filter(i => i.estadoVoto === false).length === 0;
          if (this.showResult === true) {

            this.rondaVotacionService.getResultados(this.id).subscribe(response => {
              if (response.status === true) {
                const respuesta = response.message;

                let candidatosArray = [];
                let votosArray = [];

                respuesta.resultados.forEach(x => {
                  candidatosArray.push(x.candidato);
                  votosArray.push(x.votos);
                });


                this.data = {
                  labels: candidatosArray,
                  datasets: [
                    {
                      data: votosArray,
                      backgroundColor: this.paleta(candidatosArray.length)
                    }],

                };



                this.data2 = {
                  labels: candidatosArray,
                  datasets: [
                    {
                      label: 'Total votos: ' + respuesta.totalVotos,
                      backgroundColor: '#42A5F5',
                      borderColor: '#1E88E5',
                      data: votosArray
                    },

                  ],

                };


              }
            });
          }
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

  copyMessage() {
    console.log(this.router);
    const val = this.getUrl();
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = val;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
  }
  getUrl(): string {
    return `${document.location.origin}/voto/${this.id}`;
  }
  retornar() {
    this.router.navigate([`votacion/${this.ronda.idVotacion}`]);
  }

}

