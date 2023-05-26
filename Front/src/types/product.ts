import {Image} from "./image";

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  images: Image[];
}

