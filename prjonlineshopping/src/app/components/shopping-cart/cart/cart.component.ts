import { Component, OnInit } from '@angular/core';
import { productservice } from '../../../services/productservice';
import { CartModel, UpdateCartModel } from '../../../models/Cart.model';
import { MyOrderModel } from '../../../models/MyOrder.model';
import { Orderservice } from 'src/app/services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartTotal = 0;
  cartModel: CartModel[] = new Array<CartModel>();
  updateCartModel: UpdateCartModel = new UpdateCartModel();
  deletecartid: number;
  myOrderDetailModel: MyOrderModel = new MyOrderModel();

  constructor(private router: Router,private prodservice: productservice, private orderservice: Orderservice) { }

  ngOnInit(): void {
    this.getcartproduct();
  }
  getcartproduct(){
    let userId = Number(sessionStorage.getItem('userId'));
    this.prodservice.getCartProduct(userId).subscribe((data: any) => {
      this.cartModel = data;
      this.cartTotal = 0;
      this.cartModel.forEach(item => {
        this.cartTotal += item.TotalPrice;
      });
    });
  }

  onAddQuantity(cartItem) {
    cartItem.Quantity = cartItem.Quantity + 1;
    cartItem.TotalPrice = cartItem.Quantity * cartItem.ProductPrice;
    this.updateCartModel.ProductID = cartItem.ProductID;
    this.updateCartModel.UserID = Number(sessionStorage.getItem('userId'));
    this.updateCartModel.Quantity = cartItem.Quantity;
    this.updateCartModel.TotalPrice = cartItem.TotalPrice;
    this.UpdateCart();
  }

  onRemoveQuantity(cartItem) {
    if (cartItem.Quantity > 1) {
      cartItem.Quantity = cartItem.Quantity - 1;
      cartItem.TotalPrice = cartItem.Quantity * cartItem.ProductPrice;
      this.updateCartModel.ProductID = cartItem.ProductID;
      this.updateCartModel.UserID = Number(sessionStorage.getItem('userId'));
      this.updateCartModel.Quantity = cartItem.Quantity;
      this.updateCartModel.TotalPrice = cartItem.TotalPrice;
      this.UpdateCart();
    }
  }

  UpdateCart() {
    this.prodservice.UpdateCart(this.updateCartModel).subscribe((response: any) => {
      if (response == "Success") {
        alert("Cart updated Successfully");
        this.cartTotal = 0;
        this.cartModel.forEach(item => {
          this.cartTotal += item.TotalPrice;
        });
      }
      else {
        alert(response);
      }
    });
  }

  handleRemoveFromCart(id) {
    this.prodservice.RemovefromCart(this.deletecartid = id).subscribe((response: any) => {
      if (response == 'Success') {
        alert('Product successfully removed from Cart');
    this.getcartproduct();
      }
    });
  }

  Checkout() {
    this.myOrderDetailModel.OrderTotal = this.cartTotal;
    this.myOrderDetailModel.UserID = Number(sessionStorage.getItem('userId'));
    this.myOrderDetailModel.CartModel = this.cartModel;
    this.orderservice.PlaceOrder(this.myOrderDetailModel).subscribe((response: any) => {
      if (response == 'Success') {
        alert('Order Placed Succesfully');
        this.router.navigate(['home']);
        // debugger;
        // return this.handleRemoveFromCart(this.deletecartid);
      }
      else if(response == 'Cart is Empty'){
        alert('Cart is Empty')
      }
      else{
        alert('Please Choose Less Quantity');
      }
    });
  }
}
