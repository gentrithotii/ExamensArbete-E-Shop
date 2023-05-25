import React from 'react';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { ProductProvider } from './context/ProductContext';
import { CartProvider } from './context/CartContext';
import { OrderProvider } from './context/OrderContext';

import HomePage from './pages/HomePage';
import ProductPage from './pages/ProductPage';
import CartPage from './pages/PageCart';
import OrderPage from './pages/OrderPage';

function App() {
  return (
    <Router>
      <ProductProvider>
        <CartProvider>
          <OrderProvider>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/products" element={<ProductPage />} />
              <Route path="/cart" element={<CartPage />} />
              <Route path="/orders" element={<OrderPage />} />
            </Routes>
          </OrderProvider>
        </CartProvider>
      </ProductProvider>
    </Router>
  );
}

export default App;
