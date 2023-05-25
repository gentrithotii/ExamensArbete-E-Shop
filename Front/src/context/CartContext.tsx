import React, { createContext, useState, useEffect } from "react";
import { CartItem } from "../types/cartItem";
import * as cartService from '../services/cartService'; 

interface CartContextProps {
  cartItems: CartItem[];
  loading: boolean;
  error: string;
  addItemToCart: (newItem: CartItem) => Promise<CartItem>;
  removeItemFromCart: (itemId: number) => Promise<void>;
}

export const CartContext = createContext<CartContextProps>({
  cartItems: [],
  loading: false,
  error: '',
  addItemToCart: async () => { throw new Error("addItemToCart function must be overridden"); },
  removeItemFromCart: async () => { throw new Error("removeItemFromCart function must be overridden"); }
});

interface CartProviderProps {
  children: React.ReactNode;
}

export const CartProvider: React.FC<CartProviderProps> = ({ children }) => {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchCartItems = async () => {
      try {
        const items = await cartService.getCartItems();
        setCartItems(items);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    }
    fetchCartItems();
  }, []);

  const addItemToCart = async (newItem: CartItem) => {
    try {
      const item = await cartService.addItemToCartAsync(newItem);
      setCartItems([...cartItems, item]);
      return item;
    } catch (err) {
      setError(err.message);
      throw err;
    }
  };

  const removeItemFromCart = async (itemId: number) => {
    try {
      await cartService.removeItemFromCartAsync(itemId);
      setCartItems(cartItems.filter(item => item.id !== itemId));
    } catch (err) {
      setError(err.message);
      throw err;
    }
  };

  return (
    <CartContext.Provider value={{ cartItems, loading, error, addItemToCart, removeItemFromCart }}>
      {children}
    </CartContext.Provider>
  );
};
