import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop/shop.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Errors'}},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule),
    data: {breadcrumb: 'Shop'}
  },
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule),
    data: {breadcrumb: 'Basket'}
  },
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule), data: {breadcrumb: 'Checkout'}
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
  },
  {path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule), data: {breadcrumb: {skip: true}}},
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
