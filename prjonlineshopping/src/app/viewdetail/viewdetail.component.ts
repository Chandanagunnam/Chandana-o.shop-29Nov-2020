import { Component, OnInit } from '@angular/core';
import { Products } from '../models/Products.model';
import { productservice } from '../services/productservice';
import { Router } from '@angular/router';
import { CartModel, UpdateCartModel } from '../models/Cart.model';


@Component({
  selector: 'app-viewdetail',
  templateUrl: './viewdetail.component.html',
  styleUrls: ['./viewdetail.component.css']
})
export class ViewdetailComponent implements OnInit {
  product: Products = new Products();
  cartModel: CartModel[] = new Array<CartModel>();
  updateCartModel: UpdateCartModel = new UpdateCartModel();
  constructor(private prodservice: productservice, private router: Router) { }

  ngOnInit(): void {
    let url = this.router.url;
    this.prodservice.getProductbyid(Number(url.split('/')[2])).subscribe((data: any) => {
      this.product = data;
    });
  }

  AddToCart(productModel) {
    debugger;
    if (!sessionStorage.getItem('userId')) {
      this.router.navigate(['login']);
      alert('Login first to add to Cart.');
      return;
    }
    let model = {
      ProductID: productModel.ProductID,
      TotalPrice: productModel.ProductPrice,
      Quantity: 1,
      UserID: sessionStorage.getItem('userId')
    };
    this.prodservice.AddToCart(model).subscribe((response: any) => {
      if (response == "Success") {
        alert('Product Successfully added to cart.');
      }
      else if(response =="ProductID Already Exists in Cart."){
        alert('Product Already Exists in Cart.Go to Cart to increase the Quantity');
      }
      else if(response =="Cart Quantity is more than the Product Quantity.Please Choose less quantity"){
        alert('Cart Quantity is more than the Product Quantity.Please Choose less quantity');
      }
      else{
        alert("Product Out Of Stock");
      }
    });
  }
  AddToWishlist(productModel) {
    debugger;
    if (!sessionStorage.getItem('userId')) {
      this.router.navigate(['login']);
      alert('Login first to add to Wishlist.');
      return;
    }
    let model = {
      ProductID: productModel.ProductID,
      UserID: sessionStorage.getItem('userId')
    };
    this.prodservice.AddToWishlist(model).subscribe((response: any) => {
      if (response == "Success") {
        alert('Product Successfully added to Wishlist.');
      }
      else{
        alert('Product already Present in the WishList..')
      }
    });
  }
  // onAddQuantity(product) {
  //   product.Quantity = product.Quantity + 1;
  //   product.TotalPrice = product.Quantity * product.ProductPrice;
  //   this.updateCartModel.ProductID = product.ProductID;
  //   this.updateCartModel.UserID = Number(sessionStorage.getItem('userId'));
  //   this.updateCartModel.Quantity = product.Quantity;
  //   this.updateCartModel.TotalPrice = product.TotalPrice;
  //   this.prodservice.UpdateCart(this.updateCartModel).subscribe((response: any) => {
  //     if (response == "Success") {
  //       alert("Cart updated Successfully");
  //     }
  //     else {
  //       alert(response);
  //     }
  //   });
  // }

  // onRemoveQuantity(product) {
  //   if (product.Quantity > 1) {
  //     product.Quantity = product.Quantity - 1;
  //     product.TotalPrice = product.Quantity * product.ProductPrice;
  //     this.updateCartModel.ProductID = product.ProductID;
  //     this.updateCartModel.UserID = Number(sessionStorage.getItem('userId'));
  //     this.updateCartModel.Quantity = product.Quantity;
  //     this.updateCartModel.TotalPrice = product.TotalPrice;
  //     this.prodservice.UpdateCart(this.updateCartModel).subscribe((response: any) => {
  //       if (response == "Success") {
  //         // alert("Cart updated Successfully");
  //       }
  //       else {
  //         alert(response);
  //       }
  //     });
  //   }
  // }


}
