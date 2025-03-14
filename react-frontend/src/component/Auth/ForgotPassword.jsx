import React, { useState } from 'react';

const ForgotPassword = () => {
  const [email, setEmail] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Password reset request sent for:', email);
  };

  return (
    <div className="w-full h-screen flex items-center justify-center hero">
      <div className="Main w-[90%] w-sm md:w-2/3 lg:w-[40%] p-5 flex-col flex items-center gap-3 rounded-xl shadow-slate-200 shadow-lg">
        <h3 className="text-secondary text-base font-bold mt-5">Forgot Password</h3>
        <p className="text-primary text-sm">Enter your email address to reset your password</p>

        <div className="w-2/3 flex flex-col gap-3">
          <div className="w-full flex items-center gap-2 p-2 rounded-xl icon__btn">
            <input
              type="email"
              placeholder="Email address"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="bg-transparent border-0 w-full outline-none text-sm md:text-base"
            />
          </div>
        </div>

        <button
          onClick={handleSubmit}
          className="py-2 w-2/3 bg-secondary rounded-xl mt-3 text-textcolor text-sm md:text-base mb-9"
        >
          Submit
        </button>
      </div>
    </div>
  );
};

export default ForgotPassword;
