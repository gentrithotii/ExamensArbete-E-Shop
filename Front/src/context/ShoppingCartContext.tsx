import React, { createContext, useState, useEffect } from "react";
import { ShoppingCart } from "../types/shoppingCart";
import { getShoppingCart } from '../services/cartService';

interface ShoppingCartContextProps {
    shoppingCart: ShoppingCart | null;
    loading: boolean;
    error: string;
}

export const ShoppingCartContext = createContext<ShoppingCartContextProps>({
    shoppingCart: null,
    loading: true,
    error: '',
});

interface ShoppingCartProviderProps {
    children: React.ReactNode;
}

export const ShoppingCartProvider: React.FC<ShoppingCartProviderProps> = ({ children }) => {
    const [shoppingCart, setShoppingCart] = useState<ShoppingCart | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>('');

    useEffect(() => {
        const fetchShoppingCart = async () => {
            try {
                const cart = await getShoppingCart();
                setShoppingCart(cart);
                setLoading(false);
            } catch (err) {
                if (err instanceof Error) {
                    setError(err.message);
                } else {
                    setError('An unknown error occurred.');
                }
                setLoading(false);
            }
        };
        fetchShoppingCart();
    }, []);

    return (
        <ShoppingCartContext.Provider value={{ shoppingCart, loading, error }}>
            {children}
        </ShoppingCartContext.Provider>
    );
};
