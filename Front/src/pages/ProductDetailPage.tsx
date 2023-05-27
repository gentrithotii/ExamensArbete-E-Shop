import { useContext, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { ProductContext } from '../context/ProductContext';
import { Product } from '../types/product';
import { getProductsWithId } from '../services/productService';
import { addProductToCart } from '../services/cartService';


const ProductDetailPage = () => {
    const { id = '' } = useParams<{ id?: string }>();
    const { products } = useContext(ProductContext);
    const [product, setProduct] = useState<Product | null>(null);


    useEffect(() => {
        const getProduct = async () => {
            const productId = parseInt(id);
            const product = await getProductsWithId(productId);
            setProduct(product ?? null);
            return product;
        }

        getProduct();
    }, [id, products]);


    if (!product) {
        return <div>Product not found</div>;
    }

    return (
        <div className="bg-white">
            <div className="pt-6">

                {/* Image */}
                <div className="mx-auto mt-6 w-full sm:px-6 lg:grid lg:w-full lg:grid-cols-3 lg:gap-x-8 lg:px-8">
                    <div className="aspect-h-4 aspect-w-3 hidden overflow-hidden rounded-lg lg:block">
                        <img
                            src={product.images[0].url}
                            alt={product.images[0].url}
                            className="h-full w-full object-cover object-center"
                        />
                    </div>
                </div>

                {/* Product  */}
                <div className="mx-auto w-full px-4 pb-16 pt-10 sm:px-6 lg:grid lg:w-full lg:grid-cols-3 lg:grid-rows-[auto,auto,1fr] lg:gap-x-8 lg:px-8 lg:pb-24 lg:pt-16">
                    <div className="lg:col-span-2 lg:border-r lg:border-gray-200 lg:pr-8">
                        <h1 className="text-2xl font-bold tracking-tight text-gray-900 sm:text-3xl">{product.name}</h1>
                    </div>

                    {/* Options */}
                    <div className="mt-4 lg:row-span-3 lg:mt-0">
                        <h2 className="sr-only">Product information</h2>
                        <p className="text-3xl tracking-tight text-gray-900">${product.price}</p>

                        <div className="mt-10">
                            <button
                                className="mt-10 flex w-full items-center justify-center rounded-md border border-transparent bg-indigo-600 px-8 py-3 text-base font-medium text-white hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
                                onClick={() => addProductToCart(parseInt(id))}
                            >
                                Add to bag
                            </button>
                        </div>
                    </div>

                    <div className="py-10 lg:col-span-2 lg:col-start-1 lg:border-r lg:border-gray-200 lg:pb-16 lg:pr-8 lg:pt-6">
                        {/* Description and details */}
                        <div>
                            <h3 className="sr-only">Description</h3>

                            <div className="space-y-6">
                                <p className="text-base text-gray-900">{product.description}</p>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    )


};

export default ProductDetailPage;
