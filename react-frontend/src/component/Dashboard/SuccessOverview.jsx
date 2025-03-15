import React from 'react';

const SuccessOverview = () => {
  return (
    <div className="py-10 mt-4">
      <div className="container mx-auto px-6">
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-5">
          <div className="p-6 text-center  sm:border-r border-gray-400">
            <h3 className="text-4xl font-bold text-mainColor">500,000+</h3>
            <p className="text-headingText mt-4 text-xl">Successful Interviews</p>
          </div>
          <div className="p-6 text-center sm:border-r border-gray-400">
            <h3 className="text-4xl font-bold text-mainColor">25,000+</h3>
            <p className="text-headingText mt-4 text-xl">Job Offers</p>
          </div>
          <div className="p-6 text-center  sm:border-none border-gray-400">
            <h3 className="text-4xl font-bold text-mainColor">95%</h3>
            <p className="text-headingText mt-4 text-xl">Interview Success Rate</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SuccessOverview;


