import { Order } from "./order";
import { Product } from "./product";

export interface OrderItem {
  id: number;
  quantity: number;
  productId: number;
  orderId: number;
  product: Product;
  order: Order;
}