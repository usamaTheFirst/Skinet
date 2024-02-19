import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';
import { Product } from './models/product';
import { Pagination } from './models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
 
})



export class AppComponent implements OnInit {
  title = 'SkiNet';
  products :Product[] =[];
  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>("https://localhost:5001/api/products?PageSize=50").subscribe({
      next: response=> this.products = response.data,// what to do next
      error:error=>console.log(error),
      complete:()=>{
        console.log("Request completed");

      }
    })
  }
}
