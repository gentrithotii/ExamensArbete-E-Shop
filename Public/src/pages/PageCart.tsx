import { useContext } from 'react';
import { CartContext } from '../context/CartContext';
import React from 'react';

const PageCart = () => {
  const { cartItems } = useContext(CartContext);

  return (
    <div>
      {cartItems.map((cartItem) => (
        <div key={cartItem.id}>
          <h2>{cartItem.product.name}</h2>
          <p>Quantity: {cartItem.quantity}</p>
        </div>
      ))}
    </div>
  );
}

export default PageCart;
