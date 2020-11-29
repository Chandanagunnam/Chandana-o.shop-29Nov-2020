import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ProductcrudComponent } from './productcrud/productcrud.component';
import { ForgotpasswordComponent } from 'src/app/forgotpassword/forgotpassword.component';
import { CartComponent } from './components/shopping-cart/cart/cart.component';
import { ShoppingCartComponent } from '../app/components/shopping-cart/shopping-cart.component';
import { ViewdetailComponent } from './viewdetail/viewdetail.component';
import { CompareproductsComponent } from './compareproducts/compareproducts.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { RetailercrudComponent } from './retailercrud/retailercrud.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: ShoppingCartComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'productcrud', component: ProductcrudComponent },
  { path: 'forgotpassword', component: ForgotpasswordComponent },
  { path: 'cart', component: CartComponent },
  { path: 'viewdetail/:id', component: ViewdetailComponent },
  { path: 'compare', component: CompareproductsComponent },
  { path: 'wishlist', component: WishlistComponent },
  { path: 'admin', component: RetailercrudComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
