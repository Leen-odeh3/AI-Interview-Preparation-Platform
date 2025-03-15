import { BrowserRouter, Routes, Route} from "react-router-dom"
import Login from '../component/Auth/Login'
import Register from '../component/Auth/Register'
import ForgotPassword from '../component/Auth/ForgotPassword'
import Layout from '../layout/index'
import MainPage from "../component/Dashboard/MainPage"
import TakeInterview from "../component/TakeInterview.jsx/TakeInterview"
import MockInterview from "../component/TakeInterview.jsx/MockInterview"

const index = () => {
  return (
    <BrowserRouter>
      <Routes> 
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/forgot-pass" element={<ForgotPassword />} />
        <Route element={<Layout />}>
        <Route index element={<MainPage/>} />
        <Route path="/interview" element={<TakeInterview/>}/>
        <Route path="/interview/MockInterview" element={<MockInterview/>}/>
        </Route>  
      </Routes>
    </BrowserRouter>
  )
}

export default index
