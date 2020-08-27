import { NotificationRTService } from './../servicios/NotificationRT.service';
import { MessageRT } from './../model/MessageRT';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private messageService: MessageService, private notificationRTService: NotificationRTService) {
    // this.subscribeToEvents();
  }

  ngOnInit(): void {

  }




  private subscribeToEvents(): void {

    this.notificationRTService.NuevaRondaReceived.subscribe((message: MessageRT) => {
      this.messageService.add({ severity: message.type, summary: message.payload, detail: message.summary });
    });
  }
}
