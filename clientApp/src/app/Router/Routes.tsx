import { RouteObject, Routes, createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import ProductDashboard from "../../features/products/dashboard/ProductDashboard";
import { HomePage } from "../../features/home/HomePage";

import CartDashboard from "../../features/products/dashboard/CartDashboard";

export const routes: RouteObject[] = [
    {
        path: '/',
        element : <App/>,
        children: [
            {path: '', element : <HomePage/>},
            {path: 'products', element : <ProductDashboard/>},
            {path: 'cart', element : <CartDashboard/>}
           
        
        ]
    },
]

export const router = createBrowserRouter(routes)
