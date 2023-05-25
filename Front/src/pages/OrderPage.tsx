import { useContext } from 'react';
import { OrderContext } from '../context/OrderContext';
import React from 'react';

const OrderPage = () => {
  const { orders } = useContext(OrderContext);

  return (
    <div>
      {orders.map((order) => (
        <div key={order.id}>
          <h2>Order #{order.id}</h2>
          <p>Total Price: {order.totalprice}</p>
          {order.orderItems.map((orderItem) => (
            <div key={orderItem.id}>
              <h3>{orderItem.product.name}</h3>
              <p>Quantity: {orderItem.quantity}</p>
            </div>
          ))}
        </div>
      ))}
    </div>
  );
}

export default OrderPage;
