import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './user.component.html',
  styleUrls: ['../app.component.scss']
})

export class UserComponent implements OnInit {
  public message: string = '';
  public messages: string[] = [];
  public hubConnection: HubConnection;

  ngOnInit() {
    this.hubConnection = new HubConnectionBuilder().withUrl("/echo").build();
    // this.hubConnection = new HubConnection("/echo");
    this.hubConnection.on("Send", (msg) => {
      this.messages.push(msg);
    })

    this.hubConnection.start()
      .then(() => { console.log("Hub connection started") })
      .catch(e => { console.error(e) })
  }

  echo() {
    this.hubConnection.invoke("Echo", this.message);
  }
}
