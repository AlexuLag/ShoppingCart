import { makeAutoObservable } from "mobx";
import { Cart } from "../models/cart";
import { Product } from "../models/product";

export default class CartStore {

    productsInCart: Cart[] = [];
    totalProducts : number=0;
    totalPrice: number =0;


    constructor() {
        makeAutoObservable(this)
    }

    addProductToCart = (product: Product, ammount: number) => {
        this.productsInCart.push(new Cart(product, ammount));
        this.totalProducts= this.totalProducts +ammount;
        product.stock =  product.stock -ammount;
        product.quantity = 0;
        this.getTotalPrice();
    }

    removeProductFromCart  = (cart: Cart)=>{
        
        this.productsInCart = this.productsInCart.filter (p=>p !=cart )
        cart.product.stock = cart.product.stock +cart.quantity
        this.totalProducts= this.totalProducts -cart.quantity;
        this.getTotalPrice();
    }

    updateProductStockFromCart=(products : Product[])=>{
      products.forEach(p=> {
            const quantity  = this.productsInCart.find(x =>x.product.id ==p.id)?.quantity            
            if (quantity!= undefined)
                p.stock =   p.stock - quantity
        })
        this.getTotalPrice();

  

    }

    getTotalPrice  =()=>{
        this.totalPrice = 0
        this.productsInCart.forEach(
            e=>{
                this.totalPrice+= e.quantity*e.product.unitPrice
            }
        )

    }



}