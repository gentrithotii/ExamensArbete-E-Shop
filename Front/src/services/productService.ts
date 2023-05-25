import axios from 'axios';

const BASE_URL = 'http://localhost:7052'; 

export const getProducts = async () => {
  try {
    const response = await axios.get(`api/products`);
    return response.data;
  } catch (error) {
    console.error(`Error getting products: ${error}`);
    throw error;
  }
}
