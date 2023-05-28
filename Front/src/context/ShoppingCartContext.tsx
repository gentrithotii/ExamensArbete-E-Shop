import React, { createContext, useState, useEffect } from "react";
import { ShoppingCart } from "../types/shoppingCart";
import { getShoppingCart, addProductToCart as serviceAddProductToCart, removeProductFromCart as serviceRemoveProductFromCart } from '../services/cartService';

interface ShoppingCartContextProps {
    shoppingCart: ShoppingCart | null;
    loading: boolean;
    error: string;
    addProductToCart: (productId: number) => Promise<void>;
    removeProductFromCart: (productId: number) => Promise<void>;
    isCartOpen: boolean;
    openCart: () => void;
    closeCart: () => void;
}

export const ShoppingCartContext = createContext<ShoppingCartContextProps>({
    shoppingCart: null,
    loading: true,
    error: '',
    // eslint-disable-next-line @typescript-eslint/no-empty-function
    addProductToCart: async () => { },
    // eslint-disable-next-line @typescript-eslint/no-empty-function
    removeProductFromCart: async () => { },
    isCartOpen: false,
    // eslint-disable-next-line @typescript-eslint/no-empty-function
    openCart: () => { },
    // eslint-disable-next-line @typescript-eslint/no-empty-function
    closeCart: () => { },
});

interface ShoppingCartProviderProps {
    children: React.ReactNode;
}

export const ShoppingCartProvider: React.FC<ShoppingCartProviderProps> = ({ children }) => {
    const [shoppingCart, setShoppingCart] = useState<ShoppingCart | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string>('');
    const [isCartOpen, setIsCartOpen] = useState(false);

    const openCart = () => {
        setIsCartOpen(true);
    };

    const closeCart = () => {
        setIsCartOpen(false);
    };

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

    const removeProductFromCart = async (productId: number) => {
        try {
            await serviceRemoveProductFromCart(productId);
            fetchShoppingCart();
        } catch (err) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError('An unknown error occurred.');
            }
        }
    }

    const addProductToCart = async (productId: number) => {
        try {
            await serviceAddProductToCart(productId);
            fetchShoppingCart();
        } catch (err) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError('An unknown error occurred.');
            }
        }
    }

    useEffect(() => {
        fetchShoppingCart();
    }, []);

    return (
        <ShoppingCartContext.Provider value={{ isCartOpen, openCart, closeCart, shoppingCart, loading, error, addProductToCart, removeProductFromCart }}>
            {children}
        </ShoppingCartContext.Provider>
    );
};
