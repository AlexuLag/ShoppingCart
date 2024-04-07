import { makeAutoObservable, runInAction } from "mobx";

import agent from "../api/agent";

import { Cart } from "../models/cart";

export default class OrderStore {
    
        orders  : Cart[]  = [];

    constructor() {
       
        makeAutoObservable(this)      

    }

   
    getAllOrder = async (userId: number) =>{
        const result =  await agent.Orders.list(userId);
        runInAction (()=>{
            this.orders = result;
        })
           

    }

}