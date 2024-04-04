import { createContext, useContext } from "react";
import ProductStore from "./productStore";
import CartStore from "./cartStore";

 interface Store{
        productStore : ProductStore
        cartStore: CartStore
}

export const store: Store = {
    productStore: new ProductStore(),
    cartStore: new CartStore()

}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext)
}