import React from 'react'
import { FaArrowRight } from "react-icons/fa";
import { CiVideoOn } from "react-icons/ci";
import hero from '../../assets/Hero.mp4'
import firsthero from '../../assets/firsthero.jpg'
import secondhero from '../../assets/secondhero.jpg'

const Dash = () => {
  return (
    <section className='flex flex-col md:flex-row justify-center items-center w-full px-4 py-3'>
      <div className='w-full md:w-1/2 px-8'>
        <div className='rounded-xl bg-textcolor w-fit p-2 mb-3'>
          <p className='bg-gradient-to-r from-purple-500 to-blue-500 bg-clip-text text-transparent text-base'>
            Best AI Tool for Interview Candidates
          </p>
        </div>
        <h1 className="font-bold text-4xl md:text-5xl mt-7 mb-7 leading-tight">
          Your Personal <span className='text-mainColor'>AI Interview</span> Coach
        </h1>
        <p className='text-primary text-base mt-3'>
          Double your chances of landing that job offer with our AI-powered interview prep. The No.1 AI Interview Copilot at Best Price
        </p>
        <div className='flex flex-wrap justify-start items-center mt-7'>
          <button className='bg-mainColor rounded-xl py-3 px-6 flex justify-center items-center mr-4 text-textcolor'>
            Get Started <FaArrowRight className='ml-2' />
          </button>
          <button className='bg-textcolor rounded-xl py-3 px-6 flex justify-center items-center text-secondary border border-solid border-gray'>
            Watch video <CiVideoOn className='ml-2' />
          </button>
        </div>
      </div>

      <div className='w-full md:w-1/2 text-center mt-7 p-4'>
        <video src={hero} className='rounded-xl w-full h-auto object-cover mb-4' autoPlay muted loop />
        
        <div className='flex justify-center items-center'>
          <img src={secondhero} alt="hero" className='rounded-xl w-[80%] md:w-[65%] object-cover mr-2' />
          <img src={firsthero} alt="hero" className='rounded-xl w-[10%] md:w-[10%] object-cover' />
        </div>
      </div>
    </section>
  )
}

export default Dash
