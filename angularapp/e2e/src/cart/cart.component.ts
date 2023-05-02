import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartService } from 'src/app/service/cart.service';




@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
products:any = [];
allproducts:any =0;
constructor(private cartservice:CartService){}
ngOnInit():void{
 this.cartservice.getProducts().subscribe((res: any)=>{
 this.products=res;
 this.allproducts = this.cartservice.getTotalAmount();
 })
}
removeProduct(item:any){
 this.cartservice.removeCartData(item);
}

removeAllProduct(){
  this.cartservice.removeAllCart();
}

getProducts()
{
this.cartservice.getProducts().subscribe((res: any) => {
  console.log(res);
  this.products = res;
}, )
} 

}
  
    
   

