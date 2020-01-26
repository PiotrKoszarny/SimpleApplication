import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Message } from '../api/base';
import { ChatService } from './chat.service';
import { HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  messageControl: any;
  hubConnection: any;

  constructor(
    private formBuilder: FormBuilder,
    private chatService: ChatService
  ) {
    this.messageControl = this.formBuilder.control('');
  }

  ngOnInit() {
    const hubConnectionBuilder = new HubConnectionBuilder();
    hubConnectionBuilder.withUrl(`${environment.baseUrl}chat-hub`);
    this.hubConnection = hubConnectionBuilder.build();
    this.hubConnection.start();
    // this.sendMessage({ payload: 'asd' }).then(x => console.log(x));

    this.hubConnection.on('BroadcastMessage', (x) => {
        console.log(x);
      });
  }

  async sendMessage(){
    const message = <Message>{
      payload :this.messageControl.value
    }
    console.log(message);    
    await this.chatService.sendMessage(message);
  }
}
