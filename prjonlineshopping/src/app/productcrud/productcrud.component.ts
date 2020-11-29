import { Component, OnInit } from '@angular/core';
import { categoryservice } from '../services/category.service';
import { productservice } from '../services/productservice';
import { Categories } from '../models/category.model';
import { Products } from '../models/Products.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Image } from '../models/image.model';
@Component({
  selector: 'app-productcrud',
  templateUrl: './productcrud.component.html',
  styleUrls: ['./productcrud.component.css']
})

export class ProductcrudComponent implements OnInit {
  categorylist: Categories[] = new Array<Categories>();
  products: Products[];
  prod: Products = new Products();
  error: string;
  deleteProductId: number;
  addUpdate: string = 'Add';
  selectedFile = null;
  imageUrl: string = '/assets/images/download.png';
  fileToUpload: File = null;
  mdlSampleIsOpen: boolean = false;
  productImages: Image[] = new Array<Image>();

  constructor(private prodservice: productservice, private catservice: categoryservice, private modalService: NgbModal) {

  }

  ngOnInit(): void {
    this.GetProducts();
    this.catservice.GetCategoryList().subscribe((response: any) => { this.categorylist = response; });
  }

  GetProducts() {
    this.prodservice.getProduct().subscribe((data: any) => {
      this.products = data;
    });
  }

  SaveProduct() {
    this.prodservice.insertProduct(this.prod).subscribe((response: any) => {
      if (response == 'Success') {
        this.prod = new Products();
        this.GetProducts();
        alert('Product Added Succesfully');
      }
      else if(response ="Product Quantity should not be in Negative Number"){
        alert('Product Quantity should not be in Negative Number');
      }
      else {
        this.error = response;
      }
    });
  }

  DeleteConfirmation(id) {
    this.deleteProductId = id;
  }

  DeleteProduct() {
    this.prodservice.deleteProduct(this.deleteProductId).subscribe((response: any) => {
      this.GetProducts();
    });
  }

  GetProductById(id) {
    this.prodservice.getProductbyid(id).subscribe((response: any) => {
      this.addUpdate = 'Update';
      this.prod = response;
    });
  }

  handleFileInput(file: FileList) {
    debugger;
    this.fileToUpload = file.item(0);
    var image: Image = {
      ImageID: 0,
      IsDefault: false,
      ProductID: this.prod.ProductID,
      ProductImage: this.fileToUpload.name
    }
    this.productImages.push(image);
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  SaveImages() {
    this.prodservice.insertProductImage(this.fileToUpload, this.prod.ProductID, true).subscribe((response: any) => {
      if (response == 'Success') {
        alert('ProductImage Saved Succesfully');
        var reader = new FileReader();
        reader.onload = (event: any) => {
          this.imageUrl = event.target.result;
        };
        reader.readAsDataURL(this.fileToUpload);
      }
      else {
        this.error = response;
      }
    });
  }

  open(content) {
    this.modalService.open(content);
  }

  openDeletePopup(contentdelete, id) {
    this.deleteProductId = id;
    this.modalService.open(contentdelete);
  }

}



