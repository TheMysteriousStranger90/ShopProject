import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {PaginationModule} from 'ngx-bootstrap/pagination';

import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BasketSummaryComponent } from './basket-summary/basket-summary.component';
import {RouterModule} from '@angular/router';
import { OrderTotalsComponent } from './order-totals/order-totals.component';



@NgModule({
  declarations: [
    PagerComponent,
    PagingHeaderComponent,
    BasketSummaryComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    CarouselModule,
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    ReactiveFormsModule,
    FormsModule,
    BasketSummaryComponent,
    OrderTotalsComponent
  ]
})
export class SharedModule { }
