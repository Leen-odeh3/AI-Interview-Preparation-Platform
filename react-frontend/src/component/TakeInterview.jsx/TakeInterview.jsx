import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

export default function InterviewPage() {
  const [interviews, setInterviews] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const navigate = useNavigate();

  useEffect(() => {
    const fetchInterviews = async () => {
      try {
        const token = localStorage.getItem("authToken");
        const response = await axios.get("http://localhost:5217/api/Interview/interviews", {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setInterviews(response.data);
      } catch (error) {
        setError("An error occurred while fetching interviews.");
      } finally {
        setLoading(false);
      }
    };

    fetchInterviews();
  }, []);

  const handleAddInterview = () => {
    navigate("/interview/MockInterview");
  };

  return (
    <div className="p-6 space-y-6">
      <div className="flex justify-between items-center mb-5">
        <div>
          <h1 className="text-2xl font-bold text-headingText">Interviews</h1>
          <p className="text-gray-500">Create and start your AI Mockup Interview</p>
        </div>

        <button onClick={handleAddInterview} className="px-4 py-2 bg-mainColor text-white rounded">
          Add Interview
        </button>
      </div>

      <section className="space-y-4">
        <p className="text-headingText mt-4 font-semibold">Previous Mock Interviews</p>
        {loading ? (
          <p>Loading...</p>
        ) : error ? (
          <p className="text-red-500">{error}</p>
        ) : interviews.length > 0 ? (
          interviews.map((interview) => (
            <div key={interview.id} className="p-4 border rounded-lg shadow-sm">
              <h2 className="text-xl font-semibold">{interview.position}</h2>
              <p className="text-gray-600">Tech Stack: {interview.techStack.join(", ")}</p>
              <p className="text-gray-600">Experience: {interview.yearsOfExperience} years</p>
            </div>
          ))
        ) : (
          <p className="text-gray-500">No interviews found.</p>
        )}
      </section>
    </div>
  );
}
