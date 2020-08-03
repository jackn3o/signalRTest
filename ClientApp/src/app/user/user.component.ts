import { Component, OnInit, Inject } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { HttpClient } from '@angular/common/http';
// import { MediaChange, MediaObserver } from "@angular/flex-layout";
// import { Subscription } from 'rxjs';



@Component({
  selector: 'app-home',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss', '../app.component.scss']
})

export class UserComponent implements OnInit {

  public hubConnection: HubConnection
  Products: Product[] = []

  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseurl: string) {

    this.getShoppingList()
  }

  ngOnInit() {
    this.hubConnection = new HubConnectionBuilder().withUrl("/productHub").build();

    this.hubConnection.on("refreshProducts", () => {
      this.getShoppingList()
    })

    this.hubConnection.start()
      .then(() => { console.log("Hub connection started") })
      .catch(e => { console.error(e) })
  }

  // ngOnDestroy() {
  //   this.watcher.unsubscribe();
  // }

  getShoppingList() {
    this.http.get<Product[]>(this.baseurl + 'api/shopping').subscribe(result => {
      this.Products = result
    }, error => console.error(error))
  }

}


interface Product {
  id: number,
  description: string,
  price: number,
  qty: number,
  isPublished: boolean
}