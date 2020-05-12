import { environment } from '../../environments/environment';
import { Injectable, Inject } from '@angular/core';
import { GenericService } from './generic.service';
import { HttpClient, HttpBackend } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VotanteService extends GenericService {


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http);
    this.apiURL = baseUrl + 'votante/';
  }

}
