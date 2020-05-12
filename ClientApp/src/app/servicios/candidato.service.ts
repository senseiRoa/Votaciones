import { environment } from '../../environments/environment';
import { Injectable, Inject } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class CandidatoService extends GenericService {


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http);
    this.apiURL = baseUrl + 'candidato/';
  }

  public async getAllByVotacionIdAsync(id: any): Promise<any> {
    return this.httpClient.get(this.apiURL + '/votacion/' + id).toPromise();
  }
}
