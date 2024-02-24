import { Component, OnInit, inject } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  products : Product[] = [];
  shopService :ShopService = inject(ShopService);
  ngOnInit(): void {
    this.shopService.getProduct().subscribe({
next : response => this.products = response.data,
error : error => console.log(error)
    });
  }

}
