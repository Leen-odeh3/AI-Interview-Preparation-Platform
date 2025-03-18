
import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function InterviewPage() {
  const [interviews, setInterviews] = useState([
    { id: 1, position: "Frontend Developer", techStack: "React, Tailwind CSS", experience: 3 },
    { id: 2, position: "Backend Developer", techStack: "Node.js, Express", experience: 5 },
  ]);

  const navigate = useNavigate("");
  const handleAddInterview = () => {
    navigate("/interview/MockInterview")
  };

  return (
    <div className="p-6 space-y-6">
      <div className="flex justify-between items-center mb-5">
        <div>
        <h1 className="text-2xl font-bold text-headingText">Interviews</h1>
        <p className="text-gray-500">Create and start your AI Mockup Interview</p>
        </div>

        <button 
          onClick={handleAddInterview} 
          className="px-4 py-2 bg-mainColor text-white rounded">
          Add Interview
        </button>
      </div>

      <section className="space-y-4">
      <p className="text-headingText mt-4 font-semibold">Previous Mock Interview</p>
        {interviews.length > 0 ? (
          interviews.map((interview) => (
            <div key={interview.id} className="p-4 border rounded-lg shadow-sm">
              <h2 className="text-xl font-semibold">{interview.position}</h2>
              <p className="text-gray-600">Tech Stack: {interview.techStack}</p>
              <p className="text-gray-600">Experience: {interview.experience} years</p>
            </div>
          ))
        ) : (
          <p className="text-gray-500">No interviews found.</p>
        )}
      </section>
    </div>
  );
} 