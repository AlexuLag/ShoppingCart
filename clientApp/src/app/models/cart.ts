import { CartItem } from "./cartItem"

export  class Cart {
    items: CartItem[]
    userId: number
    constructor(items: CartItem[], userId:number  )
    {
        this.items=items
        this.userId=userId 

    }
}