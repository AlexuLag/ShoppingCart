import { Category } from "./category"

export interface Product {
  id: number
  code: string
  name: string
  description: string
  unitPrice: number
  imageUrl: string
  stock: number
  categories: Category[]
  quantity:number
  }
  