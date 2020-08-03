import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';

export interface Product {
    id: number,
    description: string,
    quantity: number,
    price: number,
    isPublished: boolean
}

@Component({
    selector: 'app-root',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.scss']
})

export class DialogComponent implements OnInit {
    Product: Product
    Title: string
    IsLoading: boolean
    constructor(
        private http: HttpClient,
        public dialogRef: MatDialogRef<DialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Product,
        @Inject('BASE_URL') public baseurl: string) {

    }


    ngOnInit() {
        if (this.data.id) {
            this.getProductById(this.data.id).then(resp => {
                this.Product = resp
            }).finally(() => {
                this.IsLoading = false
            })
            this.Title = `Edit Product`

        } else {
            this.Product = this.data
            this.Title = 'Create New Product'
        }
    }


    getProductById(id: number) {
        this.IsLoading = true
        const promise = this.http.get<Product>(`${this.baseurl}api/Products/${id}`).toPromise()

        return promise
    }


    createNew() {
        this.http.post<Product>(`${this.baseurl}api/Products`, {
            description: this.Product.description,
            quantity: this.Product.quantity,
            price: this.Product.price,
            isPublished: this.Product.isPublished
        }).subscribe(data => {
            // this.postId = data.id;
            console.log(data)
        }, error => console.error(error))
    }

    updateRecord() {
        this.http.put<Product>(`${this.baseurl}api/Products/${this.Product.id}`, {
            description: this.Product.description,
            quantity: this.Product.quantity,
            price: this.Product.price,
            isPublished: this.Product.isPublished
        }).subscribe(data => {
            // this.postId = data.id;
            console.log(data)
        }, error => console.error(error))
    }

    onNoClick(): void {
        this.dialogRef.close();
    }

    onSaveClick() {
        if (this.Product.id) {
            this.updateRecord()
        } else {
            this.createNew()
        }
    }
}