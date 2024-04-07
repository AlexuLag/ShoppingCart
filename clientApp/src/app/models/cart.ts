import { CartItem } from "./cartItem"

export  class Cart {
    items: CartItem[]
    userId: number
    id: number
    constructor(items: CartItem[], userId:number , id : number )
    {
        this.items=items
        this.userId=userId 
        this.id= id

    }
}