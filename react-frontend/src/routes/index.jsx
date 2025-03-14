import { BrowserRouter, Routes, Route} from "react-router-dom"
import Login from '../component/Auth/Login'
import Register from '../component/Auth/Register'
import ForgotPassword from '../component/Auth/ForgotPassword'
import Layout from '../layout/index'
const index = () => {
  return (
    <BrowserRouter>
      <Routes> 
          <Route index element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/forgot-pass" element={<ForgotPassword />} />
        <Route element={<Layout />}>
        
        </Route>  
      </Routes>
    </BrowserRouter>
  )
}

export default index
