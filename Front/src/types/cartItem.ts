import { Product } from "./product";

export interface CartItem {
  id: number;
  quantity: number;
  productId: number;
  product: Product;
  totalPrice: number;
}
