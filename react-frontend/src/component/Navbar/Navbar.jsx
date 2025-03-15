import { NavLink, useNavigate } from "react-router-dom";
import "./Header.css";
import { useState } from "react";
import { RxHamburgerMenu } from "react-icons/rx";
import { FaTimes } from 'react-icons/fa';

const Navbar = () => {
  const [open, setopen] = useState(false);
  const links = ["Dashboard", "Questions", "Upgrade", "How it Works?"];
  const navigate = useNavigate("");

  return (
    <header className="py-3.5 flex justify-between items-center">
      <RxHamburgerMenu
        className="text-mainColor px-6 text-3xl cursor-pointer md:hidden"
        onClick={() => setopen(!open)}
      />
      <h1 className=" px-6	ml-5 text-headingText font-extrabold	leading-relaxed	text-lg	">
        MockTalent
      </h1>
      <nav className="text-headingText px-6" style={{ left: open ? 0 : -400 }}>
        <FaTimes
          className="text-white cursor-pointer sm:hidden text-mainColor delete"
          onClick={() => setopen(!open)}
        />
        {links.map((ele) => {
          return (
            <NavLink
              onClick={() => setopen(!open)}
              className="p-2 hover:text-mainColor text-lg link font-medium text-sm"
              to="/"
              key={ele}
            >
              {ele}
            </NavLink>
          );
        })}
      </nav>

      <div className="text-headingText px-6">
        <button
          className="p-2 hover:text-mainColor text-lg link font-medium text-sm"
          onClick={() => navigate("/register")}
        >
          Register
        </button>
        <button
          className="hover:text-mainColor text-lg link font-medium text-sm"
          onClick={() => navigate("/login")}
        >
          Login
        </button>
      </div>
    </header>
  );
};

export default Navbar;