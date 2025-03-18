import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const MockInterview = () => {
  const [position, setPosition] = useState('');
  const [techStack, setTechStack] = useState('');
  const [experience, setExperience] = useState('');
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    const interviewData = { 
      position, 
      techStack: techStack.split(',').map((tech) => tech.trim()), 
      experience: parseInt(experience) 
    };

    if (isNaN(interviewData.experience) || interviewData.experience <= 0) {
      setError('Please enter a valid number for years of experience.');
      setLoading(false);
      return;
    }

    try {
      const token = localStorage.getItem('authToken');
      const response = await axios.post(
        'http://localhost:5217/api/Interview/interviews',
        interviewData,
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );
      console.log('Interview added:', response.data);
      navigate('/interview');
    } catch (error) {
      setError(error.response?.data?.message || 'An error occurred while adding the interview.');
      console.error(error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen">
      <div className="w-[60%] p-6 space-y-6 rounded-lg shadow-md">
        <h1 className="text-2xl font-bold text-headingText text-center">Tell us more about your job interviewing</h1>
        <p className="text-sm text-gray-500 text-center">Add details about job position/role, job description, and years of experience</p>
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
              placeholder="Enter tech stack (comma separated)"
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
              type="button"
              className=" px-4 py-2 text-mainColor rounded"
              onClick={() => navigate("/interview")}
            >
              Cancel
            </button>
            <button
              type="submit"
              className=" px-4 py-2 bg-mainColor text-white rounded"
              disabled={loading}
            >
              {loading ? 'Loading...' : 'Start Interview'}
            </button>
          </div>
        </form>
        {error && <p className="text-red-500 text-xs text-center">{error}</p>}
      </div>
    </div>
  );
};

export default MockInterview;
