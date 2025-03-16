import React from 'react';

const Footer = () => {
  return (
    <footer className=" text-white py-8 mt-14 text-center">
      <div className="container mx-auto px-4">
        <h2 className="text-xl font-semibold mb-6 text-headingText">Follow Us!</h2>

        <p className="mx-auto w-full sm:w-1/2 mb-6 text-gray-500 text-sm">
          Top candidates worldwide trust Interviews Chat to land their dream jobs. Don’t miss out—join 15,000+ professionals and crack the code to interview success.
        </p>

        <div className="flex justify-center space-x-8 mb-6">
          <a href="/#" className="text-gray-600 text-sm">Blog</a>
          <a href="/#" className="text-gray-600 text-sm">Q&A</a>
          <a href="/#" className="text-gray-600 text-sm">Privacy Policy</a>
          <a href="/#" className="text-gray-600 text-sm">Terms and Conditions</a>
        </div>


        <p className="text-sm text-gray-400 mt-12 mb-10">
          &copy; 2025 MockTalent. All rights reserved.
        </p>
      </div>
    </footer>
  );
};

export default Footer;
