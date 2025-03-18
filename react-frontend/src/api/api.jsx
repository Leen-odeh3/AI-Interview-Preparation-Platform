import axios from 'axios';

const API_URL = "http://localhost:5217/api/auth"; 

export const login = async (email, password) => {
  try {
    const response = await axios.post(`${API_URL}/login`, { email, password });
    
    const token = response.data.token;
    
    return token;
  } catch (error) {
    throw error.response?.data || "An error occurred during login.";
  }
};

export const register = async (email, password, firstName, lastName) => {
  try {
    const response = await axios.post(`${API_URL}/register`, { email, password, firstName, lastName });
    return response.data;
  } catch (error) {
    throw error.response?.data || "An error occurred during registration.";
  }
};
