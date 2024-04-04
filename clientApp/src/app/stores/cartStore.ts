import { makeAutoObservable } from "mobx";
import { Cart } from "../models/cart";
import { Product } from "../models/product";

export default class CartStore {

    productsInCart: Cart[] = [];


    constructor() {
        makeAutoObservable(this)
    }

    addProductToCart = (product: Product, ammount: number) => {
        this.productsInCart.push(new Cart(product, ammount));
    }


}