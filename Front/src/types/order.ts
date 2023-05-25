import { OrderItem } from "./orderItem";

export interface Order {
  id: number;
  totalprice: number;
  orderItems: OrderItem[];
}