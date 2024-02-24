import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/Pagination';
import { ShopService } from './shop/shop.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
 
})



export class AppComponent implements OnInit {
  title = 'SkiNet';
  products :Product[] =[];
  // constructor(private http: HttpClient){}

  ngOnInit(): void {

  }
}
