import { Pipe, PipeTransform } from '@angular/core';
import {Products} from 'src/app/models/Products.model';

@Pipe({
name : 'productfilter'
})

export class ProductfilterPipe implements PipeTransform
{
transform(productList:any=[],searchTerm:string) :any[] {
 

 
if(!productList || !searchTerm){

 
return productList

 
}

 
 

 
return productList.filter(pro=>pro.ProductName.toLowerCase().indexOf(searchTerm.toLowerCase())!==-1
                            ||
                            pro.ProductDescription.toLowerCase().indexOf(searchTerm.toLowerCase())!==-1);

}
}