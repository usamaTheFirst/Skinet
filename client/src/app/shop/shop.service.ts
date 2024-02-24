import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Pagination } from '../shared/models/Pagination';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl :string ="https://localhost:5001/api/";
http :HttpClient = inject(HttpClient);
  constructor() { }
  getProduct(){
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products?pageSize=50');
  }
}
