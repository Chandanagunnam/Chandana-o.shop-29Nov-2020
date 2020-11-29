export class Products {
    constructor() {
        this.ProductID = 0;
        this.ProductCode = '';
        this.ProductName = '';
        this.ProductDescription = '';
        this.Brand = '';
        this.Quantity = 0;
        this.ProductPrice = 0;
        this.InStock = true;
        this.CategoryID = 0;
        this.CreatedDate = null;
        this.ModifiedBy = '';
        this.ModifiedDate = null;
        this.CategoryName = '';
        this.Image = null;
    }
    ProductID: number;
    ProductCode: string;
    ProductName: string;
    ProductDescription?: string;
    Brand: string;
    Quantity: number;
    ProductPrice: number;
    InStock: boolean;
    CategoryID?: number;
    CreatedDate: Date;
    ModifiedBy: string;
    ModifiedDate: Date;
    CategoryName: string;
    Image: File;
}