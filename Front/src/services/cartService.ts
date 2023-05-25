// cartService.ts
import axios from 'axios';
import { CartItem } from "../types/cartItem";

export async function getCartItems(): Promise<CartItem[]> {
  try {
    const response = await axios.get("api/cartitems");
    return response.data;
  } catch (error) {
    throw new Error(`Failed to get cart items: ${error}`);
  }
}

export async function addItemToCartAsync(newItem: CartItem): Promise<CartItem> {
  try {
    const response = await axios.post("api/cartitems", newItem);
    return response.data;
  } catch (error) {
    throw new Error(`Failed to add item to cart: ${error}`);
  }
}

export async function removeItemFromCartAsync(itemId: number): Promise<void> {
  try {
    await axios.delete(`api/cartitems/${itemId}`);
  } catch (error) {
    throw new Error(`Failed to remove item from cart: ${error}`);
  }
}

