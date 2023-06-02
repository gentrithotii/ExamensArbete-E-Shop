import React, { createContext, useState, useEffect } from "react";
import { Product } from "../types/product";
import { getProducts } from '../services/productService';

interface ProductContextProps {
  products: Product[];
  loading: boolean;
  error: string;
}

export const ProductContext = createContext<ProductContextProps>({
  products: [],
  loading: false,
  error: '',
});

interface ProductProviderProps {
  children: React.ReactNode;
}

export const ProductProvider: React.FC<ProductProviderProps> = ({ children }) => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const products = await getProducts();
        setProducts(products);
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
    fetchProducts();
  }, []);



  return (
    <ProductContext.Provider value={{ products, loading, error }}>
      {children}
    </ProductContext.Provider>
  );
};
