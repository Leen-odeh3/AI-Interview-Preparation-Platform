import { MdAlternateEmail } from "react-icons/md";
import { FaFingerprint } from "react-icons/fa";
import { FaRegEye, FaRegEyeSlash } from "react-icons/fa";
import { useState } from "react";
import { useNavigate } from 'react-router-dom';
import { AiFillGithub, AiFillLinkedin } from "react-icons/ai";

const Login = () => {
  const [showPassword, setShowPassword] = useState(false);
  const togglePasswordView = () => setShowPassword(!showPassword);
  const navigate = useNavigate();

  const handleClick = () => {
    navigate('/register');
  };

  const forgotPass = () => {
    navigate('/forgot-pass');
  };

  return (
    <div className="w-full h-screen flex items-center justify-center hero ">
      <div className="Main w-[90%] w-sm md:w-2/3 lg:w-[40%] p-5 flex-col flex items-center gap-3 rounded-xl shadow-slate-200 shadow-lg child">
        <h3 className="text-secondary text-base font-bold mt-5">Sign in to ai-mock-interview</h3>
        <p className=" text-primary text-sm">Welcome back! Please sign in to continue</p>
        <div className="w-1/2 lg:w-2/3 flex gap-2">
          <div className="p-2 md:px-6 lg:px-8 cursor-pointer rounded-xl flex items-center gap-2 icon__btn">
            <AiFillGithub style={{ color: '#181717' }} className="text-lg md:text-xl" />
            <span className="text-sm md:text-base font-medium">GitHub</span>
          </div>

          <div className="p-2 md:px-6 lg:px-8 cursor-pointer rounded-xl flex items-center gap-2 icon__btn">
            <AiFillLinkedin style={{ color: '#0077B5' }} className="text-lg md:text-xl" />
            <span className="text-sm md:text-base font-medium">LinkedIn</span>
          </div>
        </div>

        <h3 className="font-lora text-xs md:text-sm px-4 text-gray-500">
          Or
        </h3>

        <div className="w-2/3 flex flex-col gap-3">
          <div className="w-full flex items-center gap-2 p-2 rounded-xl icon__btn">
            <MdAlternateEmail />
            <input
              type="email"
              placeholder="Email address"
              className="bg-transparent border-0 w-full outline-none text-sm md:text-base"
            />
          </div>

          <div className="w-full flex items-center gap-2 p-2 rounded-xl relative icon__btn">
            <FaFingerprint />
            <input
              type={showPassword ? "password" : "text"}
              placeholder="Password"
              className="bg-transparent border-0 w-full outline-none text-sm md:text-base"
            />
            {showPassword ? (
              <FaRegEyeSlash
                className="absolute right-5 cursor-pointer"
                onClick={togglePasswordView}
              />
            ) : (
              <FaRegEye
                className="absolute right-5 cursor-pointer"
                onClick={togglePasswordView}
              />
            )}
          </div>
        </div>

        <button className=" py-2 w-2/3 bg-secondary rounded-xl mt-3 text-textcolor text-sm md:text-base mb-9">
          Login
        </button>

        <p className="text-xs md:text-sm text-gray-500 text-center">
          Don't have an account? 
          <span className="text-primary">
            <button className="cursor-pointer px-2" onClick={handleClick}> Sign up</button>
          </span>
        </p>
        <p className="text-xs md:text-sm text-gray-500 text-center mb-2">
          <span className="text-primary">
            <button className="cursor-pointer px-2" onClick={forgotPass}> forgot password?</button>
          </span>
        </p>
      </div>
    </div>
  );
};

export default Login;