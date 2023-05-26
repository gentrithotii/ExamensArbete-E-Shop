import React, { createContext, useEffect, useState } from "react";
import { Order } from "../types/order";
import { addOrderAsync, getOrders } from "../services/orderService";



interface OrderContextProps {
  orders: Order[];
  loading: boolean;
  error: string;
  createOrder: (newOrder: Order) => Promise<Order>;
}

export const OrderContext = createContext<OrderContextProps>({
  orders: [],
  loading: false,
  error: '',
  createOrder: async () => { throw new Error("createOrder function must be overridden"); }
});

interface OrderProviderProps {
  children: React.ReactNode;
}

export const OrderProvider: React.FC<OrderProviderProps> = ({ children }) => {
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchOrders = async () => {
      try {
        const orders = await getOrders();
        setOrders(orders);
        setLoading(false);
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('An unknown error occurred.');
        }
        setLoading(false);
      }
    }
    fetchOrders();
  }, []);

  const createOrder = async (newOrder: Order) => {
    try {
      const order = await addOrderAsync(newOrder);
      setOrders([...orders, order]);
      return order;
    } catch (err) {
      if (err instanceof Error) {
        setError(err.message);
      } else {
        setError('An unknown error occurred.');
      }
      throw err;
    }
  };


  return (
    <OrderContext.Provider value={{ orders, loading, error, createOrder }}>
      {children}
    </OrderContext.Provider>
  );
};
