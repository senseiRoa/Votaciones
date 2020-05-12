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
}
