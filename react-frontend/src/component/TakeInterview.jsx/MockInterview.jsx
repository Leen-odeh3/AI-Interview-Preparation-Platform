import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const MockInterview = () => {
  const [position, setPosition] = useState('');
  const [techStack, setTechStack] = useState('');
  const [experience, setExperience] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    const interviewData = { position, techStack, experience: parseInt(experience) };
    console.log('New Interview:', interviewData);
  };

  const navigate = useNavigate();
  return (
    <div className="flex justify-center items-center min-h-screen">
      <div className="w-[60%] p-6 space-y-6 rounded-lg shadow-md">
        <h1 className="text-2xl font-bold text-headingText text-center">Tell us more about your job interviwing</h1>
        <p className="text-sm text-gray-500 text-center">Add Details about job position/role , job description and years of experiance </p>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label htmlFor="position" className="block text-sm font-semibold text-gray-700">Job Position</label>
            <input
              type="text"
              id="position"
              value={position}
              onChange={(e) => setPosition(e.target.value)}
              placeholder="Enter position"
              className="w-full p-2 border border-gray-300 rounded"
              required
            />
          </div>

          <div>
            <label htmlFor="techStack" className="block text-sm font-semibold text-gray-700">Tech Stack</label>
            <input
              type="text"
              id="techStack"
              value={techStack}
              onChange={(e) => setTechStack(e.target.value)}
              placeholder="Enter tech stack"
              className="w-full p-2 border border-gray-300 rounded"
              required
            />
          </div>

          <div>
            <label htmlFor="experience" className="block text-sm font-semibold text-gray-700">Years of Experience</label>
            <input
              type="number"
              id="experience"
              value={experience}
              onChange={(e) => setExperience(e.target.value)}
              placeholder="Enter years of experience"
              className="w-full p-2 border border-gray-300 rounded"
              required
            />
          </div>

          <div className="mt-4 flex justify-end items-center">
        
            <button
              type="submit"
              className=" px-4 py-2 text-mainColor rounded"
              onClick={()=>navigate("/interview")}
            >
              Cancel
            </button>  
              <button
              type="submit"
              className=" px-4 py-2  bg-mainColor text-white rounded"
            >
              start Interview
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default MockInterview;
