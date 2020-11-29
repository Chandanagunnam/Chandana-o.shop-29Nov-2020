import { CartModel } from './Cart.model';

export class MyOrderModel {
    constructor() {
        this.OrderID = null;
        this.UserID = null;
        this.OrderTotal = 0;
        this.CartModel = null;
    }
    OrderID: number;
    UserID: number;
    OrderTotal: number;
    CartModel: CartModel[];
}
