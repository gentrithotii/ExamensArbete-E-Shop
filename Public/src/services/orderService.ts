import axios from 'axios';
import { Order } from "../types/order";

export async function getOrders(): Promise<Order[]> {
  try {
    const response = await axios.get("/api/orders");
    return response.data;
  } catch (error) {
    throw new Error(`Failed to get orders: ${error}`);
  }
}

export async function addOrderAsync(newOrder: Order): Promise<Order> {
  try {
    const response = await axios.post("/api/orders", newOrder);
    return response.data;
  } catch (error) {
    throw new Error(`Failed to create order: ${error}`);
  }
}
