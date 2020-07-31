import { environment } from '../../environments/environment';
import { Injectable, Inject } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class VotacionService extends GenericService {



  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http);
    this.apiURL = baseUrl + 'votacion';
  }


  public getAllCandidatosByVotacionId(id: any): Observable<any> {
    return this.httpClient.get(this.apiURL + '/' + id + '/candidatos');
  }
  public getAllVotantesByVotacionId(id: any): Observable<any> {
    return this.httpClient.get(this.apiURL + '/' + id + '/votantes');
  }

  public async downloadReport(id: string): Promise<Blob> {

    const url = this.apiURL + '/' + id + '/reporte';
    const file = await this.http.post<Blob>(url, null, { responseType: 'blob' as 'json' }).toPromise();
    return file;
  }
}
