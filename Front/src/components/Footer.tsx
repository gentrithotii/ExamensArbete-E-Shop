const Footer = () => {



    return (
        <div className="bg-gray-800 pt-10 px-8 text-white">
            <div className="container mx-auto">
                <div className="sm:flex mb-4">
                    <div className="sm:mb-0 mb-8 flex flex-col">
                        <a href="#" className="text-xl font-bold mb-2">About</a>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur quis auctor orci. Suspendisse vitae nisl tortor.</p>
                    </div>
                    <div className="flex flex-col ml-auto">
                        <a href="#" className="text-xl font-bold mb-2">Services</a>
                        <a href="#" className="mb-2">Service 1</a>
                        <a href="#" className="mb-2">Service 2</a>
                        <a href="#" className="mb-2">Service 3</a>
                    </div>
                    <div className="flex flex-col ml-12">
                        <a href="#" className="text-xl font-bold mb-2">Social</a>
                        <a href="#" className="mb-2">Facebook</a>
                        <a href="#" className="mb-2">Twitter</a>
                        <a href="#" className="mb-2">Instagram</a>
                    </div>
                </div>
                <div className="border-t border-gray-900 mt-8 pt-8 md:flex md:items-center md:justify-between">
                    <div className="flex justify-center md:order-2">
                        <a href="#" className="ml-6 text-sm font-semibold text-gray-400 no-underline">
                            Instagram
                        </a>
                        <a href="#" className="ml-6 text-sm font-semibold text-gray-400 no-underline">
                            Twitter
                        </a>
                        <a href="#" className="ml-6 text-sm font-semibold text-gray-400 no-underline">
                            Facebook
                        </a>
                    </div>
                    <div className="mt-8 md:mt-0 md:order-1">
                        <p className="text-center text-xs leading-7 text-gray-400">
                            © 2023 Your Company. All rights reserved.
                        </p>
                    </div>
                </div>
            </div>
        </div>

    );
};

export default Footer;