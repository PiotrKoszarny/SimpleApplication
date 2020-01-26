import { Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr'
import { Message } from '../api/base';
import { environment } from 'src/environments/environment';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  hubConnection: HubConnection;

  constructor(
    // private hubConnectionBuilder: HubConnectionBuilder
  ) {

    

  }

  ng

  async sendMessage(message: Message) {
    // const result = await this.hubConnection.start();
    // console.log('Start!');
    // console.log(result);

    // this.hubConnection.on('BroadcastMessage', (x) => {
    //   console.log(x);
    // });
  }
}
