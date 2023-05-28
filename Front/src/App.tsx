import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { ProductProvider } from './context/ProductContext';
import { ShoppingCartProvider } from './context/ShoppingCartContext';
import { OrderProvider } from './context/OrderContext';
import ProductPageLayout from "./layouts/productPageLayout";
import PageCartLayout from "./layouts/pageCartLayout";
import ProductDetailPageLayout from "./layouts/productDetailsPageLayout";

function App() {
  return (
    <Router>
      <ShoppingCartProvider>
        <ProductProvider>
          <OrderProvider>
            <Routes>
              <Route path="/" element={<ProductPageLayout />} />
              <Route path="/cart" element={<PageCartLayout />} />
              <Route path="/products/:id" element={<ProductDetailPageLayout />} />
              {/* <Route path="/orders" element={<EmptyLayout />} /> */}
            </Routes>
          </OrderProvider>
        </ProductProvider>
      </ShoppingCartProvider>
    </Router>
  );
}

export default App;
