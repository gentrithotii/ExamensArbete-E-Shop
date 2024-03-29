import { useContext } from 'react';
import { useParams } from 'react-router-dom';
import { ProductContext } from '../context/ProductContext';
import { ShoppingCartContext } from '../context/ShoppingCartContext';
import Loading from '../components/Loading';


const ProductDetailPage = () => {
    const { id = '' } = useParams<{ id?: string }>();
    const { products, loading } = useContext(ProductContext);
    const product = products.find(p => p.id === parseInt(id));
    const { addProductToCart } = useContext(ShoppingCartContext);

    const addProduct = () => {
        if (id) {
            addProductToCart(parseInt(id));
        }
    };

    if (!product) {
        return <div>Product not found</div>;
    }

    if (loading) {
        return <Loading />
    }
    return (
        <div className="bg-white" style={{ transform: 'scale(0.85)' }}>
            <div>

                {/* Image */}
                <div className="mx-auto mt-6 max-w-2xl sm:px-6 lg:grid lg:max-w-7xl lg:grid-cols-3 lg:gap-x-8 lg:px-8">
                    <div className="aspect-h-4 aspect-w-3 hidden overflow-hidden rounded-lg lg:block">
                        <img
                            src={product.images[0]?.url}
                            alt={product.images[0]?.url}
                            className="h-full w-full object-cover object-center"
                        />
                    </div>
                    <div className="hidden lg:grid lg:grid-cols-1 lg:gap-y-8">
                        <div className="aspect-h-2 aspect-w-3 overflow-hidden rounded-lg">
                            <img
                                src={product.images[1]?.url}
                                alt={product.images[1]?.url}
                                className="h-full w-full object-cover object-center"
                            />
                        </div>
                        <div className="aspect-h-2 aspect-w-3 overflow-hidden rounded-lg">
                            <img
                                src={product.images[2]?.url}
                                alt={product.images[2]?.url}
                                className="h-full w-full object-cover object-center"
                            />
                        </div>
                    </div>
                    <div className="aspect-h-5 aspect-w-4 lg:aspect-h-4 lg:aspect-w-3 sm:overflow-hidden sm:rounded-lg">
                        <img
                            src={product.images[3]?.url}
                            alt={product.images[3]?.url}
                            className="h-full w-full object-cover object-center"
                        />
                    </div>
                </div>

                {/* Product  */}
                <div className="mx-auto max-w-2xl px-4 pb-16 pt-10 sm:px-6 lg:grid lg:max-w-7xl lg:grid-cols-3 lg:grid-rows-[auto,auto,1fr] lg:gap-x-8 lg:px-8 lg:pb-24 lg:pt-16">
                    <div className="lg:col-span-2 lg:border-r lg:border-gray-200 lg:pr-8">
                        <h1 className="text-2xl font-bold tracking-tight text-gray-900 sm:text-3xl">{product.name}</h1>
                    </div>

                    {/* Price and button */}
                    <div className="mt-4 lg:row-span-3 lg:mt-0">
                        <h2 className="sr-only">Product information</h2>
                        <p className="text-3xl tracking-tight text-gray-900">Total Price: {product.price} $</p>
                        <button
                            onClick={addProduct}
                            className="mt-4 flex w-1/2 items-center justify-center rounded-md border border-transparent bg-indigo-600 px-4 py-2 text-base font-medium text-white hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
                        >
                            Add to bag
                        </button>
                    </div>

                    <div className="py-10 lg:col-span-2 lg:col-start-1 lg:border-r lg:border-gray-200 lg:pb-16 lg:pr-8 lg:pt-6">
                        {/* Description */}
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
