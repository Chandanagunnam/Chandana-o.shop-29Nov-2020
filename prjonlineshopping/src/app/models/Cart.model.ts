export class CartModel {
    CartID: number;
    ProductDescription: string;
    ProductCode: string;
    ProductName: string;
    Quantity: number;
    ProductID: number;
    ProductPrice: number;
    TotalPrice: number;
}

export class UpdateCartModel {
    constructor() {
        this.UserID = 0;
        this.Quantity = 0;
        this.ProductID = 0;
        this.TotalPrice = 0;
    }
    UserID: number;
    Quantity: number;
    ProductID: number;
    TotalPrice: number;
}
