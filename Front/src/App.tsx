import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { ProductProvider } from './context/ProductContext';
import { ShoppingCartProvider } from './context/ShoppingCartContext';
import { OrderProvider } from './context/OrderContext';

import ProductPage from './pages/ProductPage';
import CartPage from './pages/PageCart';
import OrderPage from './pages/OrderPage';
import ProductDetailPage from './pages/ProductDetailPage';
import ShopHeader from './components/ShopHeader';

function App() {
  return (
    <Router>
      <ShoppingCartProvider>
        <ProductProvider>
          <OrderProvider>
            <ShopHeader />
            <Routes>
              <Route path="/" element={<ProductPage />} />
              <Route path="/cart" element={<CartPage />} />
              <Route path="/products/:id" element={<ProductDetailPage />} />
              <Route path="/orders" element={<OrderPage />} />
            </Routes>
          </OrderProvider>
        </ProductProvider>
      </ShoppingCartProvider>
    </Router>
  );
}

export default App;
