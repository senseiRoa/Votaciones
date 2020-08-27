import { MessageRT } from './../model/MessageRT';
import { EventEmitter, Injectable, Inject } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class NotificationRTService {

  NuevoVotoReceived = new EventEmitter<MessageRT>();
  NuevaRondaReceived = new EventEmitter<MessageRT>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;
  hubURL: string;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.hubURL = baseUrl + 'notify/';
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  // sendMessage(message: MessageRT) {
  //   this._hubConnection.invoke('NewMessage', message);
  // }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubURL)
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () { this.startConnection(); }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('NotificarNuevaRonda', (data: any) => {
      this.NuevaRondaReceived.emit(data);
    });
    this._hubConnection.on('NotificarVoto', (data: any) => {
      this.NuevoVotoReceived.emit(data);
    });
  }

}
