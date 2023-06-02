import React, { createContext, useContext, useState } from "react";
import { Order } from "../types/order";
import { createOrderAsync } from "../services/orderService";
import { ShoppingCartContext } from "./ShoppingCartContext";




interface OrderContextProps {
  orders: Order[];
  // loading: boolean;
  error: string;
  createOrder: (id: number) => void;
}

export const OrderContext = createContext<OrderContextProps>({
  orders: [],
  // loading: false,
  error: '',
  createOrder: async () => { throw new Error("createOrder function must be overridden"); }
});

interface OrderProviderProps {
  children: React.ReactNode;
}

export const OrderProvider: React.FC<OrderProviderProps> = ({ children }) => {
  const [orders, setOrders] = useState<Order[]>([]);
  // const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');
  const { fetchShoppingCart } = useContext(ShoppingCartContext);

  // useEffect(() => {
  //   const fetchOrders = async () => {
  //     try {
  //       const orders = await getOrders();
  //       setOrders(orders);
  //       setLoading(false);
  //     } catch (err) {
  //       if (err instanceof Error) {
  //         setError(err.message);
  //       } else {
  //         setError('An unknown error occurred.');
  //       }
  //       setLoading(false);
  //     }
  //   }
  //   fetchOrders();
  // }, []);

  const createOrder = async (id: number) => {
    try {
      const order = await createOrderAsync(id);
      setOrders([...orders, order]);
      fetchShoppingCart();
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
    <OrderContext.Provider value={{ orders, error, createOrder }}>
      {children}
    </OrderContext.Provider>
  );
};
