import { CartItem } from "./cartItem";

export interface ShoppingCart {
  id: number;
  cartItems: CartItem[];
  totalPrice: number;
}
