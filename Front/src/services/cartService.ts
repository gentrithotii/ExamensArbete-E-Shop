// shoppingCartService.ts

import axios from "axios";
import { ShoppingCart } from "../types/shoppingCart";

export async function getShoppingCart(): Promise<ShoppingCart> {
   try {
    const response = await axios.get("/api/ShoppingCart");
 return response.data;
     } catch (error) {
    throw new Error(`Failed to get orders: ${error}`);
  }
}

export async function addProductToCart(id: number) {
  try {
    const response = await axios.post(`/api/ShoppingCart/add/${id}`);
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.error(`Error adding product to cart: ${error}`);
    throw error;
  }
}
