import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { DialogComponent } from '../dialog/dialog.component';
import { Observable } from 'rxjs';

export interface Product {
  id: number,
  description: string,
  quantity: number,
  price: number,
  isPublished: boolean
}

@Component({
  selector: 'admin-component',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})

export class AdminComponent {
  Products: Product[] = [];
  Product: Product;

  constructor(public dialog: MatDialog, public http: HttpClient, @Inject('BASE_URL') public baseurl: string) {
    this.getList()
  }

  openDialog(id = null): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '400px',
      data: { id: id, description: "", quantity: 0, price: 0, isPublished: false }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getList();
    });
  }

  getList() {
    this.http.get<Product[]>(`${this.baseurl}api/Products`).subscribe(result => {
      this.Products = result
    }, error => console.error(error))
  }


}
// @Component({
//   selector: 'admin.component',
//   templateUrl: 'admin.new.component.html',
// })

// export class AdminNewDialogComponent {
//   constructor(
//     public dialogRef: MatDialogRef<AdminNewDialogComponent>,
//     @Inject(MAT_DIALOG_DATA) public data: Product) { }

//   onNoClick(): void {
//     this.dialogRef.close();
//   }

// }