import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product';

import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute,
  private bcService: BreadcrumbService) {

  }

  ngOnInit(): void {
    this.loadProduct()
  }

  loadProduct() {
    this.shopService.getProduct(2).subscribe(product => {
      this.product = product;
    }, error => {
      console.log(error);
    });
  }
}
