import { MagnifyingGlassIcon, ShoppingBagIcon } from "@heroicons/react/24/outline";
import { useContext } from "react";
import { Link } from "react-router-dom";
import { ShoppingCartContext } from "../context/ShoppingCartContext";
import PageCart from "../pages/PageCart";

const ShopHeader = () => {
  const { isCartOpen, openCart, shoppingCart } = useContext(ShoppingCartContext);




  let cartItemsCount = 0;
  if (shoppingCart) {
    for (const item of shoppingCart.cartItems) {
      cartItemsCount += item.quantity;
    }
  }

  return (
    <header className="fixed top-0 z-40 w-full bg-white">
      <nav aria-label="Top" className="mx-auto w-full px-4">
        <div className="border-b border-gray-200">
          <div className="flex h-16 items-center">
            {/* Logo */}
            <div className="flex-shrink-0 ml-4">
              <Link to="/">
                <span className="sr-only">Your Company</span>
                <img
                  className="h-8 w-auto"
                  src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600"
                  alt=""
                />
              </Link>
            </div>

            {/* Navigation Links */}
            <div className="hidden lg:ml-8 lg:block lg:self-stretch">
              <div className="flex h-full space-x-8 items-center">
                <Link to="/" className="text-sm font-medium text-gray-700 hover:text-gray-800">Home</Link>
              </div>
            </div>

            {/* User Links */}
            <div className="ml-auto flex items-center space-x-4">
              <Link to="/login" className="text-sm font-medium text-gray-700 hover:text-gray-800">Sign in</Link>
              <span className="h-6 w-px bg-gray-200" aria-hidden="true" />
              <Link to="/register" className="text-sm font-medium text-gray-700 hover:text-gray-800 pl-4">Create account</Link>
            </div>

            {/* Search */}
            <div className="flex lg:ml-6">
              <Link to="/search" className="p-2 text-gray-400 hover:text-gray-500">
                <span className="sr-only">Search</span>
                <MagnifyingGlassIcon className="h-6 w-6" aria-hidden="true" />
              </Link>
            </div>

            {/* Cart */}
            <div className="ml-4 flow-root lg:ml-6">
              <button
                className="group -m-2 flex items-center p-2"
                onClick={openCart}
              >
                <ShoppingBagIcon
                  className="h-6 w-6 flex-shrink-0 text-gray-400 group-hover:text-gray-500"
                  aria-hidden="true"
                />
                <span className="ml-2 text-sm font-medium text-gray-700 group-hover:text-gray-800">{cartItemsCount}</span>
                <span className="sr-only">items in cart, view bag</span>
              </button>
            </div>
          </div>
        </div>
        {isCartOpen && <PageCart />}
      </nav>
    </header>
  );
};

export default ShopHeader;
