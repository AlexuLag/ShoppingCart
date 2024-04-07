import { makeAutoObservable } from "mobx";
import { Cart } from "../models/cart";
import { Product } from "../models/product";
import agent from "../api/agent";

export default class CartStore {

    productsInCart: Cart[] = [];
    totalProducts : number=0;
    totalPrice: number =0;


    constructor() {
        makeAutoObservable(this)
    }

    addProductToCart = (product: Product, ammount: number) => {

        var existsProduct =  this.productsInCart.find(p=> p.product.id==product.id);
        if (existsProduct!=null)      
            existsProduct.quantity+=ammount
        else      
            this.productsInCart.push(new Cart(product, ammount));
        this.totalProducts= this.totalProducts +ammount;
        product.stock =  product.stock -ammount;
        product.quantity = 0;
        this.getTotalPrice();
        //add store to local storage using localstorage 
        localStorage.setItem('cart',JSON.stringify(this) )   

    }

    removeProductFromCart  = (cart: Cart)=>{
        
        this.productsInCart = this.productsInCart.filter (p=>p !=cart )
        cart.product.stock = cart.product.stock +cart.quantity
        this.totalProducts= this.totalProducts -cart.quantity;
        this.getTotalPrice();
        //add store to local storage using localstorage  
        localStorage.setItem('cart',JSON.stringify(this) )   
    }

    updateProductStockFromCart=(products : Product[])=>{
        //load first from local storage, cart state and then continue with operation
     
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

    loadCartFromStorage =()=>{
        var  cartFromStorage = localStorage.getItem('cart')
        if( cartFromStorage!=null)
        {
            var cart  = JSON.parse(cartFromStorage) as CartStore
            this.productsInCart = cart.productsInCart
            this.totalProducts = cart.totalProducts 
        }

    }

    createOrder = ()=>{
        agent.Orders.create(this.productsInCart)
    }

}