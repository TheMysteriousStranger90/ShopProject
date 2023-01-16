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
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';



@NgModule({
  declarations: [
    PagerComponent,
    PagingHeaderComponent,
    BasketSummaryComponent,
    OrderTotalsComponent,
    TextInputComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
  ],
  exports: [
    CarouselModule,
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    FormsModule,
    BasketSummaryComponent,
    OrderTotalsComponent,
    TextInputComponent
  ]
})
export class SharedModule { }
