import { useContext } from 'react';
import { ProductContext } from '../context/ProductContext';
import React from 'react';

const ProductPage = () => {
  const { products } = useContext(ProductContext);



  return (
    <div>
      {products.map((product) => (
        <div key={product.id}>
          <h2>{product.name}</h2>
          <p>{product.description}</p>
          <p>{product.price}</p>
          {product.images.map((image) => (
            <img src={image.url} alt={product.name} key={image.id} />
          ))}
        </div>
      ))}
    </div>
  );
}

export default ProductPage;
