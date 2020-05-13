import { environment } from '../../environments/environment';
import { Injectable, Inject } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RondaVotacionService extends GenericService {


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http);
    this.apiURL = baseUrl + 'rondavotacion';
  }

  public getAllByVotacionId(id: string): Observable<any> {
    return this.httpClient.get(this.apiURL + '/votacion/' + id);
  }
  public getAllCandidatosByRondaId(id: any): Observable<any> {
    return this.httpClient.get(this.apiURL + '/' + id + '/candidatos');
  }


  public async createVotoAsync(entity: any): Promise<any> {
    const reqHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    const entityJson = JSON.stringify(entity);
    return await this.httpClient.post<any>(this.apiURL + '/voto', entityJson, { headers: reqHeaders }).toPromise();
  }


}
