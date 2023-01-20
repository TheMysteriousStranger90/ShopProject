import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../account/account.service';
import { BasketService } from '../basket/basket.service';
import { Basket } from '../shared/models/basket';
import { OrderToCreate } from '../shared/models/order';
import { Address } from '../shared/models/user';
import { CheckoutService } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  constructor(private fb: FormBuilder, private accountService: AccountService,
              private checkoutService: CheckoutService, private toastr: ToastrService,
              private basketService: BasketService, private router: Router) { }

  ngOnInit(): void {
    this.getAddressFormValues();
  }

  checkoutForm = this.fb.group({
    addressForm: this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipcode: ['', Validators.required],
    }),
    deliveryForm: this.fb.group({
      deliveryMethod: ['', Validators.required]
    }),
    paymentForm: this.fb.group({
      nameOnCard: ['', Validators.required]
    })
  })

  getAddressFormValues() {
    this.accountService.getUserAddress().subscribe({
      next: address => {
        address && this.checkoutForm.get('addressForm')?.patchValue(address)
      }
    })
  }

  submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    if (!basket) return;
    const orderToCreate = this.getOrderToCreate(basket);
    if (!orderToCreate) return;
    this.checkoutService.createOrder(orderToCreate).subscribe({
      next: order => {
        this.toastr.success('Order created successfully');
        this.basketService.deleteLocalBasket();
        const navigationExtras: NavigationExtras = {state: order};
        this.router.navigate(['checkout/success'], navigationExtras);
      },
      error: error => {
        this.toastr.error(error.message);
        console.log(error);
      }
    })
  }

  private getOrderToCreate(basket: Basket): OrderToCreate | undefined {
    const deliveryMethodId = this.checkoutForm.get('deliveryForm')?.get('deliveryMethod')?.value;
    const shipToAddress = this.checkoutForm.get('addressForm')?.value as Address
    if (!deliveryMethodId || !shipToAddress) return;
    return {
      basketId: basket.id,
      deliveryMethodId: +deliveryMethodId,
      shipToAddress: shipToAddress
    }
  }
}
