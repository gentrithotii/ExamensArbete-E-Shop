// cartService.ts
import axios from 'axios';
import { CartItem } from "../types/cartItem";

export async function getCartItems(): Promise<CartItem[]> {
  try {
    const response = await axios.get("/api/cart");
    return response.data;
  } catch (error) {
    throw new Error(`Failed to get cart items: ${error}`);
  }
}

export async function addItemToCartAsync(newItem: CartItem): Promise<CartItem> {
  try {
    const response = await axios.post("/api/cart", newItem);
    return response.data;
  } catch (error) {
    throw new Error(`Failed to add item to cart: ${error}`);
  }
}

export async function removeItemFromCartAsync(itemId: number): Promise<void> {
  try {
    await axios.delete(`/api/cart/${itemId}`);
  } catch (error) {
    throw new Error(`Failed to remove item from cart: ${error}`);
  }
}

