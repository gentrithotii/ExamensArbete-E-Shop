// cartService.ts
import axios from 'axios';
import { CartItem } from "../types/cartItem";

export async function getCartItems(): Promise<CartItem[]> {
  try {
    const response = await axios.get("/cart");
    return response.data;
  } catch (error) {
    throw new Error(`Failed to get cart items: ${error}`);
  }
}

export async function addItemToCartAsync(newItem: CartItem): Promise<CartItem> {
  try {
    const response = await axios.post("/cart", newItem);
    return response.data;
  } catch (error) {
    throw new Error(`Failed to add item to cart: ${error}`);
  }
}

export async function removeItemFromCartAsync(itemId: number): Promise<void> {
  try {
    await axios.delete(`/cart/${itemId}`);
  } catch (error) {
    throw new Error(`Failed to remove item from cart: ${error}`);
  }
}

