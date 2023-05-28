import Header from '../components/ShopHeader';
import Footer from '../components/Footer';
import { ReactNode } from 'react';


interface Props {
    children: ReactNode;
}

const Layout: React.FC<Props> = ({ children }) => {
    return (
        <>
            <Header />
            {children}
            <Footer />
        </>
    );
};

export default Layout;